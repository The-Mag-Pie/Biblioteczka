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
    /// Interaction logic for EditEntry.xaml
    /// </summary>
    public partial class EditEntry : Window
    {
        BookViewModel viewModel;
        BookViewModel mainViewModel;

        public EditEntry(BookViewModel bookViewModel)
        {
            InitializeComponent();

            mainViewModel = bookViewModel;
            viewModel = bookViewModel.Clone();
            DataContext = viewModel;

            bookCategory.ItemsSource = DbRead.GetCategories();
            bookCategory.SelectedItem = viewModel.CategoryName;
        }

        //private void SetImage(Uri uri)
        //{
        //    BitmapImage bitmapImage = new BitmapImage();
        //    bitmapImage.DownloadCompleted += (s, e) =>
        //    {
        //        int stride = bitmapImage.PixelWidth * 4;
        //        int size = bitmapImage.PixelHeight * stride;
        //        byte[] pixels = new byte[size];
        //        bitmapImage.CopyPixels(pixels, stride, 0);

        //        int firstPixelIndex = 1 * stride + 4 * 1;

        //        bookImage.Source = bitmapImage;
        //        imageGrid.Background = new SolidColorBrush(Color.FromArgb(
        //            pixels[firstPixelIndex + 3],
        //            pixels[firstPixelIndex + 0],
        //            pixels[firstPixelIndex + 1],
        //            pixels[firstPixelIndex + 2]));
        //    };

        //    bitmapImage.BeginInit();
        //    bitmapImage.UriSource = uri;
        //    bitmapImage.EndInit();
        //}

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

                //bookImage.Source = new BitmapImage(new Uri(ofd.FileName));
                viewModel.Image = image;
            }
        }

        private void ebookFindButton_Click(object sender, RoutedEventArgs e)
        {
            bookEbook.Text = WebBrowserSelectLink.CreateEbookWindow("tytul ksiazki").SavedLink;
        }

        private void audiobookFindButton_Click(object sender, RoutedEventArgs e)
        {
            bookAudiobook.Text = WebBrowserSelectLink.CreateAudiobookWindow("tytul ksiazki").SavedLink;
        }

        private void movieFindButton_Click(object sender, RoutedEventArgs e)
        {
            bookMovie.Text = WebBrowserSelectLink.CreateFilmAdaptationWindow("tytul ksiazki").SavedLink;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            mainViewModel.Update(viewModel);
            Close();
        }
    }
}
