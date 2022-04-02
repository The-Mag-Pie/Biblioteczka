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
using Biblioteczka.MVVM;

namespace Biblioteczka.Windows
{
    /// <summary>
    /// Interaction logic for BookDetails.xaml
    /// </summary>
    public partial class BookDetails : Window
    {
        BookViewModel viewModel;

        public BookDetails(BookViewModel bookViewModel)
        {
            InitializeComponent();

            viewModel = bookViewModel;
            DataContext = viewModel;

            if (viewModel.EbookLink == null)
            {
                buttonEbook.Content = "E-book niedostępny";
                buttonEbook.IsEnabled = false;
            }
            if (viewModel.AudiobookLink == null)
            {
                buttonAudiobook.Content = "Audiobook niedostępny";
                buttonAudiobook.IsEnabled = false;
            }
            if (viewModel.MovieLink == null)
            {
                buttonFilm.Content = "Adapacja filmowa niedostępna";
                buttonFilm.IsEnabled = false;
            }
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
            WebBrowserNoControls.CreateEbookWindow(viewModel.Title, viewModel.EbookLink);
        }

        private void buttonAudiobook_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserNoControls.CreateAudiobookWindow(viewModel.Title, viewModel.AudiobookLink);
        }

        private void buttonFilm_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserNoControls.CreateFilmAdaptationWindow(viewModel.Title, viewModel.MovieLink);
        }
    }
}
