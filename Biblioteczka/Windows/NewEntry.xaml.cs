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

namespace Biblioteczka.Windows
{
    /// <summary>
    /// Interaction logic for NewEntry.xaml
    /// </summary>
    public partial class NewEntry : Window
    {
        public NewEntry()
        {
            InitializeComponent();
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
                bookImage.Source = new BitmapImage(new Uri(ofd.FileName));
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
    }
}
