using System;
using System.IO;
using Feedbackapp.Model;
using SQLite;
using static System.Environment;

namespace Feedbackapp.Functions
{
    public class SQLiteFunctions
    {
        private static readonly string connectionString = Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), @"SqLiteDatabase.db3");
        private static SQLiteAsyncConnection SQLiteConnection { get; set; }

        public static void CreateTables()
        {
            if (!File.Exists(connectionString))
                File.Create(connectionString);

            SQLiteConnection = new SQLite.SQLiteAsyncConnection(connectionString);

            SQLiteConnection.CreateTableAsync<User>(CreateFlags.AutoIncPK | CreateFlags.ImplicitIndex);
        }

        public static void InsertUser(object obj)
        {
            if (obj is User usr)
                SQLiteConnection.InsertAsync(usr);
        }
    }
}
