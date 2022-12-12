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
        public long ID;
        public string Title;
        public string Author;
        public string Description;
        public string? EbookLink;
        public string? AudiobookLink;
        public string? MovieLink;
        public BitmapImage? Image = null;
        public string CategoryName;
    }
}
