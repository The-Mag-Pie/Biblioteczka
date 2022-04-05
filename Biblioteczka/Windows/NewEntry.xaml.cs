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
            viewModel.EbookLink = WebBrowserSelectLink.CreateEbookWindow(viewModel.Title).SavedLink;
        }

        private void audiobookFindButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AudiobookLink = WebBrowserSelectLink.CreateAudiobookWindow(viewModel.Title).SavedLink;
        }

        private void movieFindButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.MovieLink = WebBrowserSelectLink.CreateFilmAdaptationWindow(viewModel.Title).SavedLink;
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Create();
            Close();
        }

        private void bookCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bookCategory.SelectedItem != null)
                viewModel.CategoryName = bookCategory.SelectedItem.ToString();
        }
    }
}
