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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdateBookList();
            categoryComboBox.ItemsSource = DbRead.GetCategories();
        }

        private void UpdateBookList()
        {
            entryStackPanel.Children.Clear();
            int i = 0;
            BookEntry entry;
            foreach (Book book in DbRead.GetBooks())
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
    }
}
