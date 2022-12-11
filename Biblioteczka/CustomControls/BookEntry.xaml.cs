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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblioteczka.Windows;
using Biblioteczka.MVVM;

namespace Biblioteczka.CustomControls
{
    /// <summary>
    /// Interaction logic for BookEntry.xaml
    /// </summary>
    public partial class BookEntry : UserControl
    {
        BookViewModel viewModel;

        public BookEntry(int ordinal, BookViewModel bookViewModel)
        {
            InitializeComponent();

            viewModel = bookViewModel;
            DataContext = viewModel;

            ordinalLabel.Content = ordinal;
        }

        public BookEntry()
        {
            InitializeComponent();

            ordinalLabel.Content = "Lp.";
            ordinalLabel.FontWeight = FontWeights.Bold;
            ordinalLabel.Foreground = Brushes.Black;
            ordinalLabel.FontSize = 14;

            authorLabel.Text = "Autor";
            authorLabel.FontWeight = FontWeights.Bold;
            authorLabel.Foreground = Brushes.Black;
            authorLabel.FontSize = 14;

            titleLabel.Text = "Tytuł";
            titleLabel.FontWeight = FontWeights.Bold;
            titleLabel.Foreground = Brushes.Black;
            titleLabel.FontSize = 14;

            categoryLabel.Text = "Gatunek";
            categoryLabel.FontWeight = FontWeights.Bold;
            categoryLabel.Foreground = Brushes.Black;
            categoryLabel.FontSize = 14;

            openDetailsButton.Visibility = Visibility.Hidden;
        }

        // Event raised when window with book details has been closed
        // Functions are being attached to this event in MainWindow class and used to refresh book list
        public delegate void UpdateView();
        public event UpdateView DetailsWindowClosed;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new BookDetails(viewModel)).ShowDialog();
            DetailsWindowClosed?.Invoke();
        }
    }
}
