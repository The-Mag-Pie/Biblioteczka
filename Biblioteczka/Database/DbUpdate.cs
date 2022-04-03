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
        public static void UpdateBook(Book book)
        {
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

            Clipboard.SetText(sqlUpdateString);

            MessageBox.Show(sqlUpdateString);

            SqliteConnection dbConn = null;

            try
            {
                dbConn = DbConnection.CreateConnection();

                SqliteCommand cmd = dbConn.CreateCommand();
                cmd.CommandText = sqlUpdateString;

                MessageBox.Show(cmd.ExecuteNonQuery().ToString());

                if (book.Image != null)
                {
                    using (SqliteBlob writeStream = new SqliteBlob(dbConn, "Books", "Image", book.ID))
                    {
                        book.Image.StreamSource.CopyTo(writeStream);
                    }
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
        }
    }
}
