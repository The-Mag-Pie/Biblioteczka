﻿using System;
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
            bool isDeleted = false;

            SqliteConnection dbConn = null;

            try
            {
                dbConn = DbConnection.CreateConnection();

                SqliteCommand cmd = dbConn.CreateCommand();
                cmd.CommandText = sqlDeleteString;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    isDeleted = true;
                }
                else
                {
                    throw new Exception("Błąd podczas usuwania książki.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isDeleted = false;
            }
            finally
            {
                dbConn?.Close();
            }
            return isDeleted;
        }

        private static void TryDeleteBook(Book book, SqliteCommand sqlCommand, SqliteConnection dbConn)
        {
            if (cmd.ExecuteNonQuery() != 1)
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
