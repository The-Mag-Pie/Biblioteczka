using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Biblioteczka.Database;
using Microsoft.Data.Sqlite;

namespace Biblioteczka.MVVM
{
    public class BookViewModel : INotifyPropertyChanged
    {
        Book _book;

        public BookViewModel(Book book)
        {
            _book = book;
        }

        public Book Book { get { return _book; } }
        public long ID { get { return _book.ID; } }
        public string Title
        {
            get { return _book.Title; }
            set
            {
                if (Book.Title != value)
                {
                    Book.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Author
        {
            get { return _book.Author; }
            set
            {
                if (Book.Author != value)
                {
                    Book.Author = value;
                    OnPropertyChanged("Author");
                }
            }
        }
        public string Description
        {
            get { return _book.Description; }
            set
            {
                if (Book.Description != value)
                {
                    Book.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string? EbookLink
        {
            get { return _book.EbookLink; }
            set
            {
                if (Book.EbookLink != value)
                {
                    Book.EbookLink = value != "" ? value : null;
                    OnPropertyChanged("EbookLink");
                }
            }
        }
        public string? AudiobookLink
        {
            get { return _book.AudiobookLink; }
            set
            {
                if (Book.AudiobookLink != value)
                {
                    Book.AudiobookLink = value != "" ? value : null;
                    OnPropertyChanged("AudiobookLink");
                }
            }
        }
        public string? MovieLink
        {
            get { return _book.MovieLink; }
            set
            {
                if (Book.MovieLink != value)
                {
                    Book.MovieLink = value != "" ? value : null;
                    OnPropertyChanged("MovieLink");
                }
            }
        }
        public BitmapImage? Image
        {
            get { return _book.Image; }
            set
            {
                if (Book.Image != value)
                {
                    Book.Image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
        public string CategoryName
        {
            get { return _book.CategoryName; }
            set
            {
                if (Book.CategoryName != value)
                {
                    Book.CategoryName = value;
                    OnPropertyChanged("CategoryName");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BookViewModel Clone()
        {
            Book clonedBook = new Book();
            clonedBook.ID = ID;
            clonedBook.Title = Title;
            clonedBook.Author = Author;
            clonedBook.Description = Description;
            clonedBook.EbookLink = EbookLink;
            clonedBook.AudiobookLink = AudiobookLink;
            clonedBook.MovieLink = MovieLink;
            clonedBook.Image = Image;
            clonedBook.CategoryName = CategoryName;
            return new BookViewModel(clonedBook);
        }

        public void Update(BookViewModel editedViewModel)
        {
            if (DbUpdate.UpdateBook(editedViewModel.Book))
            {
                Title = editedViewModel.Title;
                Author = editedViewModel.Author;
                Description = editedViewModel.Description;
                EbookLink = editedViewModel.EbookLink;
                AudiobookLink = editedViewModel.AudiobookLink;
                MovieLink = editedViewModel.MovieLink;
                Image = editedViewModel.Image;
                CategoryName = editedViewModel.CategoryName;

                MessageBox.Show("Dane książki zostały pomyślnie zaktualizowane.");
            }
            else
            {
                MessageBox.Show("Błąd podczas aktualizowania danych książki!");
            }
        }

        public void Create()
        {
            if (DbCreate.CreateBook(Book))
            {
                MessageBox.Show("Nowa książka została utworzona pomyślnie.");
            }
            else
            {
                MessageBox.Show("Błąd podczas dodawania nowej książki!");
            }
        }
    }
}
