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


            string dbFilePath = Environment.CurrentDirectory + "\\Resources\\database.db";

            SqliteConnection dbConn = new SqliteConnection($"Data Source={dbFilePath}");
            dbConn.Open();
            MessageBox.Show(dbConn.State.ToString());

            SqliteCommand command = dbConn.CreateCommand();
            command.CommandText = "SELECT *, (SELECT Name FROM Categories WHERE ID = B.Category_ID) AS Category_Name FROM Books B;";
            SqliteDataReader reader = command.ExecuteReader();

            entryStackPanel.Children.Add(new BookEntry(0, true));
            //int i = 1;
            while (reader.Read())
            {
                MemoryStream stream = new MemoryStream((byte[])reader["Image"]);
                stream.Seek(0, SeekOrigin.Begin);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
                //bookshelfImage.Source = image;
                break;
            }

            dbConn.Close();

            
            for (int i = 1; i <= 50; i++)
            {
                entryStackPanel.Children.Add(new BookEntry(i));
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new EditEntry()).ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (new BookDetails()).ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WebBrowserNoControls.CreateAudiobookWindow("jakiś tytuł", "https://facebook.com");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WebBrowserNoControls.CreateEbookWindow("tytuł xd", "https://1.1.1.1");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            WebBrowserNoControls.CreateFilmAdaptationWindow("hehehe", "https://youtube.com");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            WebBrowserSelectLink browser = WebBrowserSelectLink.CreateEbookWindow("pan tadeusz");
            MessageBox.Show(browser.SavedLink);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            WebBrowserSelectLink browser = WebBrowserSelectLink.CreateAudiobookWindow("ogniem i mieczem");
            MessageBox.Show(browser.SavedLink);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            WebBrowserSelectLink browser = WebBrowserSelectLink.CreateFilmAdaptationWindow("wesele");
            MessageBox.Show(browser.SavedLink);
        }
    }
}
