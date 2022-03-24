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
    /// Interaction logic for WebBrowserNoControls.xaml
    /// </summary>
    public partial class WebBrowserNoControls : Window
    {
        public static void CreateAudiobookWindow(string bookTitle, string uri)
        {
            (new WebBrowserNoControls(bookTitle + " - Audiobook", new Uri(uri))).Show();
        }

        public static void CreateEbookWindow(string bookTitle, string uri)
        {
            (new WebBrowserNoControls(bookTitle + " - E-book", new Uri(uri))).Show();
        }

        public static void CreateFilmAdaptationWindow(string bookTitle, string uri)
        {
            (new WebBrowserNoControls(bookTitle + " - Adaptacja filmowa", new Uri(uri))).Show();
        }

        public WebBrowserNoControls(string title, Uri uri)
        {
            InitializeComponent();
            Title = title;
            webView.Source = uri;
        }

        private void WebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            uriTextBox.Text = webView.Source.ToString();
            Cursor = Cursors.Arrow;
        }

        private void webView_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            Cursor = Cursors.Wait;
        }

        private void webView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
        }

        private void reloadButtonClick(object sender, RoutedEventArgs e)
        {
            webView.Reload();
        }

        private void copyButtonClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(uriTextBox.Text);
        }
    }
}
