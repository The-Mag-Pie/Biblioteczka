using Biblioteczka.MVVM;

namespace BiblioteczkaTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
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
    }
}