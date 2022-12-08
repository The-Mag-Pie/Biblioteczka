using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
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

        public static void UploadImageBlob(BitmapImage image, SqliteConnection dbConnection, long rowID)
        {
            using (SqliteBlob writeStream = new SqliteBlob(dbConnection, "Books", "Image", rowID))
            {
                // Before copying to output stream, we need to set position to begin in the input stream
                image.StreamSource.Seek(0, SeekOrigin.Begin);
                image.StreamSource.CopyTo(writeStream);
            }
        }
    }
}
