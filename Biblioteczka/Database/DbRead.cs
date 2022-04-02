using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteczka.MVVM;
using Microsoft.Data.Sqlite;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows;

namespace Biblioteczka.Database
{
    public static class DbRead
    {
        public static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            SqliteConnection? dbConn = null;

            try
            {
                dbConn = DbConnection.CreateConnection();

                SqliteCommand cmd = dbConn.CreateCommand();
                cmd.CommandText = "SELECT *, (SELECT Name FROM Categories WHERE ID = B.Category_ID) AS CategoryName FROM Books B;";

                SqliteDataReader reader = cmd.ExecuteReader();

                Book book;
                while (reader != null && reader.Read())
                {
                    book = new Book();
                    book.ID = (long)reader["ID"];
                    book.Title = (string)reader["Title"];
                    book.Author = (string)reader["Author"];
                    book.Description = (string)reader["Description"];
                    book.EbookLink = reader["EbookLink"] is not DBNull ? (string)reader["EbookLink"] : null;
                    book.AudiobookLink = reader["AudiobookLink"] is not DBNull ? (string)reader["AudiobookLink"] : null;
                    book.MovieLink = reader["MovieLink"] is not DBNull ? (string)reader["MovieLink"] : null;
                    book.Image = reader["Image"] is not DBNull ? ByteArrayToImage((byte[])reader["Image"]) : null;
                    book.CategoryName = (string)reader["CategoryName"];
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConn?.Close();
            }

            return books;
        }

        public static BitmapImage ByteArrayToImage(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(bytes);
            memoryStream.Seek(0, SeekOrigin.Begin);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = memoryStream;
            image.EndInit();
            return image;
        }

        public static List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            SqliteConnection? dbConn = null;

            try
            {
                dbConn = DbConnection.CreateConnection();

                SqliteCommand cmd = dbConn.CreateCommand();
                cmd.CommandText = "SELECT Name FROM Categories;";

                SqliteDataReader reader = cmd.ExecuteReader();

                while (reader != null && reader.Read())
                {
                    categories.Add((string)reader["Name"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConn?.Close();
            }

            return categories;
        }
    }
}
