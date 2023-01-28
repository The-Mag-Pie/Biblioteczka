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
    public partial class WebBrowserWithLinkSelection : Window
    {
        public static WebBrowserWithLinkSelection CreateAudiobookWindow(string bookTitle)
        {
            WebBrowserWithLinkSelection browser = new WebBrowserWithLinkSelection(bookTitle + " - Znajdź audiobook", new Uri("https://librivox.org/"));
            browser.Show();
            return browser;
        }

        public static WebBrowserWithLinkSelection CreateEbookWindow(string bookTitle)
        {
            WebBrowserWithLinkSelection browser = new WebBrowserWithLinkSelection(bookTitle + " - Znajdź e-book", new Uri("https://1lib.pl/"));
            browser.Show();
            return browser;
        }

        public static WebBrowserWithLinkSelection CreateFilmAdaptationWindow(string bookTitle)
        {
            WebBrowserWithLinkSelection browser = new WebBrowserWithLinkSelection(bookTitle + " - Znajdź adaptację filmową", new Uri("https://www.filmweb.pl/"));
            browser.Show();
            return browser;
        }

        private string _savedLink = "";
        public string SavedLink { get { return _savedLink; } }

        public WebBrowserWithLinkSelection(string title, Uri uri)
        {
            InitializeComponent();
            Title = title;
            webView.Source = uri;
        }

        private void WebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            uriTextBox.Text = webView.Source.ToString();
            Cursor = Cursors.Arrow;

            if (webView.CanGoBack) buttonBack.IsEnabled = true;
            else buttonBack.IsEnabled = false;

            if (webView.CanGoForward) buttonForward.IsEnabled = true;
            else buttonForward.IsEnabled = false;
        }

        private void webView_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            Cursor = Cursors.Wait;
        }

        private void webView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoBack) webView.GoBack();
        }

        private void buttonForward_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoForward) webView.GoForward();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            if (uriTextBox.Text.Length > 0)
                try
                {
                    // Because WebView library does not support URIs without HTTP prefix, it must be added in code
                    if (uriTextBox.Text.StartsWith("http") == false)
                        uriTextBox.Text = uriTextBox.Text.Insert(0, "http://");
                    webView.Source = new Uri(uriTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("BŁĄD! Podano błędny link");
                }
        }

        private void uriTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonLoad.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            webView.Reload();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            _savedLink = webView.Source.ToString();
            Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
