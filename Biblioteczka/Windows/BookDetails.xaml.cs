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
    public partial class BookDetails : Window
    {
        private static readonly string EbookButtonEnabledText = "Dostępny E-book!";
        private static readonly string EbookButtonDisabledText = "E-book niedostępny";
        private static readonly string AudiobookButtonEnabledText = "Dostępny Audiobook!";
        private static readonly string AudiobookButtonDisabledText = "Audiobook niedostępny";
        private static readonly string FilmButtonEnabledText = "Dostępna adaptacja filmowa!";
        private static readonly string FilmButtonDisabledText = "Adapacja filmowa niedostępna";

        BookViewModel viewModel;

        public BookDetails(BookViewModel bookViewModel)
        {
            InitializeComponent();

            viewModel = bookViewModel;
            DataContext = viewModel;

            ConfigureButtons();
        }

        private void ConfigureButtons()
        {
            // If property is empty, then the button is blocked for user (disabled).
            if (viewModel.EbookLink == null)
            {
                buttonEbook.Content = EbookButtonDisabledText;
                buttonEbook.IsEnabled = false;
            }
            // If property contains some data, then the button is enabled and clickable.
            else
            {
                buttonEbook.Content = EbookButtonEnabledText;
                buttonEbook.IsEnabled = true;
            }

            if (viewModel.AudiobookLink == null)
            {
                buttonAudiobook.Content = AudiobookButtonDisabledText;
                buttonAudiobook.IsEnabled = false;
            }
            else
            {
                buttonAudiobook.Content = AudiobookButtonEnabledText;
                buttonAudiobook.IsEnabled = true;
            }

            if (viewModel.MovieLink == null)
            {
                buttonFilm.Content = FilmButtonDisabledText;
                buttonFilm.IsEnabled = false;
            }
            else
            {
                buttonFilm.Content = FilmButtonEnabledText;
                buttonFilm.IsEnabled = true;
            }
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć książkę?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                viewModel.Delete();
                Close();
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            (new EditEntry(viewModel)).ShowDialog();
            ConfigureButtons();
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
