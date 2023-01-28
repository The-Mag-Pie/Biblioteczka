using Biblioteczka.MVVM;
using Biblioteczka.Windows;
using System.Windows.Controls;

namespace BiblioteczkaTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_ViewModelCloning()
        {
            var book = new Book()
            {
                ID = 1,
                Title = "Testowy tytuł",
                Author = "Autor test",
                Description = "Jakiś opis aaaaaaaaaaaaaaaaaaaaaaaaaa",
                EbookLink = "https://po.edu.pl",
                MovieLink = "https://youtube.com",
                CategoryName = "kategoria"
            };

            var viewModel = new BookViewModel(book);
            var clonedBook = viewModel.Clone().Book;

            Assert.Equivalent(book, clonedBook, strict: true);
        }

        [StaFact]
        public void Test_AudiobookBrowser()
        {
            string title = "Przykładowy tytuł okna audiobook";
            var browser_audiobook = WebBrowserWithLinkSelection.CreateAudiobookWindow(title);
            while (browser_audiobook.IsVisible == false)
            {
                // waiting for window to be visible
            }

            var saveButton = (Button)browser_audiobook.FindName("buttonSave");
            saveButton.RaiseEvent(new System.Windows.RoutedEventArgs(Button.ClickEvent));

            Assert.Contains(title, browser_audiobook.Title);
            Assert.Equal("https://librivox.org/", browser_audiobook.SavedLink);
        }

        [StaFact]
        public void Test_EbookBrowser()
        {
            string title = "Przykładowy tytuł okna ebook";
            var browser_ebook = WebBrowserWithLinkSelection.CreateEbookWindow(title);
            while (browser_ebook.IsVisible == false)
            {
                // waiting for window to be visible
            }

            var saveButton = (Button)browser_ebook.FindName("buttonSave");
            saveButton.RaiseEvent(new System.Windows.RoutedEventArgs(Button.ClickEvent));

            Assert.Contains(title, browser_ebook.Title);
            Assert.Equal("https://1lib.pl/", browser_ebook.SavedLink);
        }

        [StaFact]
        public void Test_FilmAdaptationBrowser()
        {
            string title = "Przykładowy tytuł okna ebook";
            var browser_film_adaptation = WebBrowserWithLinkSelection.CreateFilmAdaptationWindow(title);
            while (browser_film_adaptation.IsVisible == false)
            {
                // waiting for window to be visible
            }

            var saveButton = (Button)browser_film_adaptation.FindName("buttonSave");
            saveButton.RaiseEvent(new System.Windows.RoutedEventArgs(Button.ClickEvent));

            Assert.Contains(title, browser_film_adaptation.Title);
            Assert.Equal("https://www.filmweb.pl/", browser_film_adaptation.SavedLink);
        }
    }
}