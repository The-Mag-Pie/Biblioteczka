using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Biblioteczka.MVVM;
using Microsoft.Data.Sqlite;

namespace Biblioteczka.Database
{
    public static class DbCreate
    {
        public static bool CreateBook(Book book)
        {
            bool isCreated = false;
            string sqlInsertString =
                $@"
                    INSERT INTO Books (Title, Author, Description, EbookLink, AudiobookLink, MovieLink, Image, Category_ID) VALUES (
                        '{book.Title}',
                        '{book.Author}',
                        '{book.Description}',
                        {(book.EbookLink != null ? $"'{book.EbookLink}'" : "null")},
                        {(book.AudiobookLink != null ? $"'{book.AudiobookLink}'" : "null")},
                        {(book.MovieLink != null ? $"'{book.MovieLink}'" : "null")},
                        {(book.Image != null ? $"zeroblob({book.Image.StreamSource.Length})" : "null")},
                        (SELECT ID From Categories WHERE Name LIKE '{book.CategoryName}')
                    );
                ";

            SqliteConnection dbConn = null;

            try
            {
                dbConn = DbConnection.CreateConnection();

                SqliteCommand sqlCommand = dbConn.CreateCommand();

                sqlCommand.CommandText = sqlInsertString;
                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    isCreated = true;

                    // Get an ID of inserted row (newly added book)
                    sqlCommand.CommandText = "SELECT last_insert_rowid();";
                    long bookID = (long)sqlCommand.ExecuteScalar();

                    if (book.Image != null)
                    {
                        DbConnection.UploadImageBlob(book.Image, dbConn, bookID);
                    }

                    book.ID = bookID;
                }
                else
                {
                    throw new Exception("Błąd podczas tworzenia nowej książki.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isCreated = false;
            }
            finally
            {
                dbConn?.Close();
            }
            return isCreated;
        }
    }
}
