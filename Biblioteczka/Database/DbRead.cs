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
        public static List<Book> GetBooks(string partialSqlString)
        {
            try
            {
                using SqliteConnection dbConn = DbConnection.CreateConnection();
                SqliteCommand cmd = dbConn.CreateCommand();

                return GetBooksListFromDatabase(cmd, partialSqlString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new();
            }
        }

        // partialSqlString parameter contains optional sort and order SQL clauses (can be empty)
        private static List<Book> GetBooksListFromDatabase(SqliteCommand cmd, string partialSqlString)
        {
            var list = new List<Book>();

            string cmdText = "SELECT *, (SELECT Name FROM Categories WHERE ID = B.Category_ID) AS CategoryName FROM Books B " + partialSqlString;
            var reader = GetDataReader(cmdText, cmd);

            while (reader != null && reader.Read())
            {
                var book = new Book();
                book.ID = (long)reader["ID"];
                book.Title = (string)reader["Title"];
                book.Author = (string)reader["Author"];
                book.Description = (string)reader["Description"];
                book.EbookLink = reader["EbookLink"] is not DBNull ? (string)reader["EbookLink"] : null;
                book.AudiobookLink = reader["AudiobookLink"] is not DBNull ? (string)reader["AudiobookLink"] : null;
                book.MovieLink = reader["MovieLink"] is not DBNull ? (string)reader["MovieLink"] : null;
                book.Image = reader["Image"] is not DBNull ? ByteArrayToImage((byte[])reader["Image"]) : null;
                book.CategoryName = (string)reader["CategoryName"];
                list.Add(book);
            }
            return list;
        }

        public static List<string> GetCategories()
        {
            try
            {
                using SqliteConnection dbConn = DbConnection.CreateConnection();
                SqliteCommand cmd = dbConn.CreateCommand();

                return GetCategoriesListFromDatabase(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new();
            }
        }

        private static List<string> GetCategoriesListFromDatabase(SqliteCommand cmd)
        {
            var list = new List<string>();

            string cmdText = "SELECT Name FROM Categories;";
            var reader = GetDataReader(cmdText, cmd);

            while (reader != null && reader.Read())
            {
                list.Add((string)reader["Name"]);
            }
            return list;
        }

        private static SqliteDataReader GetDataReader(string commandText, SqliteCommand cmd)
        {
            cmd.CommandText = commandText;
            return cmd.ExecuteReader();
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
    }
}
