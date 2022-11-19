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
using Microsoft.Win32;
using Biblioteczka.MVVM;
using Biblioteczka.Database;
using System.IO;

namespace Biblioteczka.Windows
{
    /// <summary>
    /// Interaction logic for NewEntry.xaml
    /// </summary>
    public partial class NewEntry : Window
    {
        BookViewModel viewModel;

        public NewEntry()
        {
            InitializeComponent();

            viewModel = new BookViewModel(new Book());
            DataContext = viewModel;

            bookCategory.ItemsSource = DbRead.GetCategories();
            ((List<string>)bookCategory.ItemsSource).Insert(0, "Wybierz kategorię...");
            bookCategory.SelectedIndex = 0;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectImageButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pliki obrazów (*.BMP; *.JPG; *.PNG, *.GIF)| *.BMP; *.JPG; *.PNG; *.GIF";
            if (ofd.ShowDialog() == true)
            {
                Stream stream = ofd.OpenFile();
                stream.Seek(0, SeekOrigin.Begin);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();

                viewModel.Image = image;
            }
        }

        private void ebookFindButton_Click(object sender, RoutedEventArgs e)
        {
            string link = WebBrowserWithLinkSelection.CreateEbookWindow(viewModel.Title).SavedLink;
            viewModel.EbookLink = link == "" ? viewModel.EbookLink : link;
        }

        private void audiobookFindButton_Click(object sender, RoutedEventArgs e)
        {
            string link = WebBrowserWithLinkSelection.CreateAudiobookWindow(viewModel.Title).SavedLink;
            viewModel.AudiobookLink = link == "" ? viewModel.AudiobookLink : link;
        }

        private void movieFindButton_Click(object sender, RoutedEventArgs e)
        {
            string link = WebBrowserWithLinkSelection.CreateFilmAdaptationWindow(viewModel.Title).SavedLink;
            viewModel.MovieLink = link == "" ? viewModel.MovieLink : link;
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            string errorText = "";

            if (bookEbook.Text.Length > 0)
                try
                {
                    new Uri(bookEbook.Text);
                }
                catch
                {
                    errorText = "BŁĄD! Niepoprawny link do e-booka!";
                }
            if (bookAudiobook.Text.Length > 0)
                try
                {
                    new Uri(bookAudiobook.Text);
                }
                catch
                {
                    errorText = "BŁĄD! Niepoprawny link do audiobooka!";
                }
            if (bookMovie.Text.Length > 0)
                try
                {
                    new Uri(bookMovie.Text);
                }
                catch
                {
                    errorText = "BŁĄD! Niepoprawny link do adaptacji filmowej!";
                }

            if (bookTitle.Text.Length == 0)
                errorText = "BŁĄD! Nie podano tytułu książki!";
            else if (bookAuthor.Text.Length == 0)
                errorText = "BŁĄD! Nie podano autora książki!";
            else if (bookCategory.SelectedIndex == 0)
                errorText = "BŁĄD! Nie wybrano kategorii książki!";
            else if (bookDescription.Text.Length == 0)
                errorText = "BŁĄD! Nie podano opisu książki!";

            if (errorText.Length > 0)
            {
                MessageBox.Show(errorText);
                return;
            }
            else
            {
                viewModel.Create();
                Close();
            }
        }

        private void bookCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bookCategory.SelectedItem != null)
                viewModel.CategoryName = bookCategory.SelectedItem.ToString();
        }
    }
}
