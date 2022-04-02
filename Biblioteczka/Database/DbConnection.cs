﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Biblioteczka.Database
{
    public static class DbConnection
    {
        public static SqliteConnection CreateConnection()
        {
            string dbFilePath = $"{Environment.CurrentDirectory}\\Resources\\database.db";

            SqliteConnection dbConn = new SqliteConnection($"Data Source={dbFilePath}");
            dbConn.Open();
            while (dbConn.State == System.Data.ConnectionState.Connecting)
            {
                // waiting
            }
            return dbConn.State == System.Data.ConnectionState.Open ? dbConn : throw new DbConnectionException();
        }

        public sealed class DbConnectionException : Exception
        {
            public DbConnectionException() : base("Error during connecting to database.") { }
        }
    }
}
