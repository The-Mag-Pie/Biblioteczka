using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Biblioteczka.MVVM
{
    public class Book
    {
        private long _id;
        private string _title;
        private string _author;
        private string _description;
        private string? _ebookLink;
        private string? _audiobookLink;
        private string? _movieLink;
        private BitmapImage? _image;
        private string _categoryName;

        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string? EbookLink
        {
            get { return _ebookLink; }
            set { _ebookLink = value; }
        }

        public string? AudiobookLink
        {
            get { return _audiobookLink; }
            set { _audiobookLink = value; }
        }

        public string? MovieLink
        {
            get { return _movieLink; }
            set { _movieLink = value; }
        }

        public BitmapImage? Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
    }
}
