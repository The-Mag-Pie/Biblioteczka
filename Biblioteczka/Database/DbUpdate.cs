using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Biblioteczka.MVVM;
using Microsoft.Data.Sqlite;

namespace Biblioteczka.Database
{
    public static class DbUpdate
    {
        public static bool UpdateBook(Book book)
        {
            bool isUpdated = false;
            string sqlUpdateString =
                $@"
                    UPDATE Books SET
                        Title = '{book.Title}',
                        Author = '{book.Author}',
                        Description = '{book.Description}',
                        EbookLink = {(book.EbookLink != null ? $"'{book.EbookLink}'" : "null")},
                        AudiobookLink = {(book.AudiobookLink != null ? $"'{book.AudiobookLink}'" : "null")},
                        MovieLink = {(book.MovieLink != null ? $"'{book.MovieLink}'" : "null")},
                        Image = {(book.Image != null ? $"zeroblob({book.Image.StreamSource.Length})" : "null")},
                        Category_ID = (SELECT ID From Categories WHERE Name LIKE '{book.CategoryName}')
                    WHERE ID = {book.ID};
                ";

            SqliteConnection dbConn = null;

            try
            {
                dbConn = DbConnection.CreateConnection();

                SqliteCommand cmd = dbConn.CreateCommand();
                cmd.CommandText = sqlUpdateString;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    isUpdated = true;
                }

                if (book.Image != null)
                {
                    DbConnection.UploadImageBlob(book.Image, dbConn, book.ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isUpdated = false;
            }
            finally
            {
                dbConn?.Close();
            }
            return isUpdated;
        }
    }
}
