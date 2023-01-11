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
            try
            {
                using SqliteConnection dbConn = DbConnection.CreateConnection();
                SqliteCommand cmd = dbConn.CreateCommand();

                TryUpdateBook(book, cmd, dbConn);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static void TryUpdateBook(Book book, SqliteCommand sqlCommand, SqliteConnection dbConn)
        {
            if (ExecuteCommand(GenerateSqlString(book), sqlCommand) == 1)
            {
                if (book.Image != null)
                {
                    DbConnection.UploadImageBlob(book.Image, dbConn, book.ID);
                }
            }
            else
            {
                throw new Exception("Błąd podczas aktualizowania danych książki.");
            }
        }

        private static string GenerateSqlString(Book book)
        {
            return
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
        }

        private static int ExecuteCommand(string commandText, SqliteCommand sqlCommand)
        {
            sqlCommand.CommandText = commandText;
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
