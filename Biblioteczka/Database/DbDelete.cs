using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Biblioteczka.MVVM;
using System.Windows;

namespace Biblioteczka.Database
{
    public static class DbDelete
    {
        public static bool DeleteBook(Book book)
        {
            try
            {
                using SqliteConnection dbConn = DbConnection.CreateConnection();
                SqliteCommand sqlCommand = dbConn.CreateCommand();

                TryDeleteBook(book, sqlCommand);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static void TryDeleteBook(Book book, SqliteCommand sqlCommand)
        {
            if (ExecuteCommand(GenerateSqlString(book), sqlCommand) != 1)
            {
                throw new Exception("Błąd podczas usuwania książki.");
            }
        }

        private static string GenerateSqlString(Book book)
        {
            return $"DELETE FROM Books WHERE ID = {book.ID};";
        }

        private static int ExecuteCommand(string commandText, SqliteCommand sqlCommand)
        {
            sqlCommand.CommandText = commandText;
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
