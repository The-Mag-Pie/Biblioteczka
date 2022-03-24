﻿using System;
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

namespace Biblioteczka.CustomControls
{
    /// <summary>
    /// Interaction logic for BookEntry.xaml
    /// </summary>
    public partial class BookEntry : UserControl
    {
        public BookEntry(int counter, bool header = false)
        {
            InitializeComponent();

            if (header)
            {
                counterText.Content = "Lp.";
                counterText.FontWeight = FontWeights.Bold;
                counterText.Foreground = Brushes.Black;
                counterText.FontSize = 14;

                authorText.Content = "Autor";
                authorText.FontWeight = FontWeights.Bold;
                authorText.Foreground = Brushes.Black;
                authorText.FontSize = 14;

                titleText.Content = "Tytuł";
                titleText.FontWeight = FontWeights.Bold;
                titleText.Foreground = Brushes.Black;
                titleText.FontSize = 14;

                categoryText.Content = "Gatunek";
                categoryText.FontWeight = FontWeights.Bold;
                categoryText.Foreground = Brushes.Black;
                categoryText.FontSize = 14;

                buttonDetails.Visibility = Visibility.Hidden; 
            }
            else
            {
                counterText.Content = counter;
                authorText.Content = "Adam Mickiewicz";
                titleText.Content = "Pan Tadeusz";
                categoryText.Content = "Lektura";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new BookDetails()).ShowDialog();
        }
    }
}
