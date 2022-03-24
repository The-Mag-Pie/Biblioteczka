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

namespace Biblioteczka.Windows
{
    /// <summary>
    /// Interaction logic for BookDetails.xaml
    /// </summary>
    public partial class BookDetails : Window
    {
        public BookDetails()
        {
            InitializeComponent();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            (new EditEntry()).ShowDialog();
        }

        private void buttonEbook_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserNoControls.CreateEbookWindow("Pan Tadeusz", "https://xd.pl");
        }

        private void buttonAudiobook_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserNoControls.CreateAudiobookWindow("Pan Tadeusz", "https://itaka.pl");
        }

        private void buttonFilm_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserNoControls.CreateFilmAdaptationWindow("Pan Tadeusz", "https://netflix.com");
        }
    }
}
