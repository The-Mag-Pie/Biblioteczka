using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using Biblioteczka.CustomControls;
using Biblioteczka.Database;
using Biblioteczka.MVVM;
using Microsoft.Data.Sqlite;
using System.IO;

namespace Biblioteczka.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> categories = DbRead.GetCategories();
            categories.Insert(0, "Wszystkie");
            categoryComboBox.ItemsSource = categories;
            categoryComboBox.SelectedIndex = 0;
            categoryComboBox.SelectionChanged += comboBox_SelectionChanged;

            sortComboBox.SelectedIndex = 0;
            sortComboBox.SelectionChanged += comboBox_SelectionChanged;

            UpdateBookList();
        }

        private void UpdateBookList()
        {
            string partialSqlString = $"WHERE (Title LIKE '%{searchBox.Text}%' OR Author LIKE '%{searchBox.Text}%')";

            if (categoryComboBox.SelectedIndex > 0)
                partialSqlString += $" AND Category_ID = (SELECT ID FROM Categories WHERE Name LIKE '{categoryComboBox.SelectedItem}')";

            partialSqlString += " ORDER BY ";
            switch (sortComboBox.SelectedIndex)
            {
                case 0:
                    partialSqlString += "Author";
                    break;

                case 1:
                    partialSqlString += "Author DESC";
                    break;

                case 2:
                    partialSqlString += "Title";
                    break;

                case 3:
                    partialSqlString += "Title DESC";
                    break;

                case 4:
                    partialSqlString += "Date_added";
                    break;

                case 5:
                    partialSqlString += "Date_added DESC";
                    break;
            }
            partialSqlString += ";";

            entryStackPanel.Children.Clear();
            entryStackPanel.Children.Add(new BookEntry());
            int i = 0;
            BookEntry entry;
            foreach (Book book in DbRead.GetBooks(partialSqlString))
            {
                entry = new BookEntry(++i, new BookViewModel(book));
                entry.DetailsWindowClosed += UpdateBookList;
                entryStackPanel.Children.Add(entry);
            }
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AboutCreatorButtonClick(object sender, RoutedEventArgs e)
        {
            (new AboutCreator()).Show();
        }

        private void CreateNewEntryButtonClick(object sender, RoutedEventArgs e)
        {
            (new NewEntry()).ShowDialog();
            UpdateBookList();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBookList();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBookList();
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateBookList();
        }
    }
}
