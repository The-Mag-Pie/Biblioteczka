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
            try
            {
                using SqliteConnection dbConn = DbConnection.CreateConnection();
                SqliteCommand sqlCommand = dbConn.CreateCommand();

                TryInsertBook(book, sqlCommand, dbConn);

                dbConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static void TryInsertBook(Book book, SqliteCommand sqlCommand, SqliteConnection dbConn)
        {
            if (ExecuteCommand(GenerateSqlString(book), sqlCommand) == 1)
            {
                // Get an ID of inserted row (newly added book)
                book.ID = GetLastInsertedRowID(sqlCommand);

                UploadImage(book, dbConn);
            }
            else
            {
                throw new Exception("Błąd podczas tworzenia nowej książki.");
            }
        }

        private static string GenerateSqlString(Book book)
        {
            return 
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
        }

        private static int ExecuteCommand(string commandText, SqliteCommand sqlCommand)
        {
            sqlCommand.CommandText = commandText;
            return sqlCommand.ExecuteNonQuery();
        }

        private static long GetLastInsertedRowID(SqliteCommand sqlCommand)
        {
            sqlCommand.CommandText = "SELECT last_insert_rowid();";
            return (long)sqlCommand.ExecuteScalar();
        }

        private static void UploadImage(Book book, SqliteConnection dbConn)
        {
            if (book.Image != null)
            {
                DbConnection.UploadImageBlob(book.Image, dbConn, book.ID);
            }
        }
    }
}
