using System;
using System.IO;
using System.Linq;
using Feedbackapp.Model;
using SQLite;
using static System.Environment;

namespace Feedbackapp.Functions
{
    public class SQLiteFunctions
    {
        private static readonly string connectionString = Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), @"SqLiteDatabase.db3");
        private static SQLiteConnection SQLiteConnection { get; set; }

        static SQLiteFunctions()
        {
            CreateTables();
        }

        public static void CreateTables()
        {
            if (!File.Exists(connectionString))
                File.Create(connectionString);

            SQLiteConnection = new SQLite.SQLiteConnection(connectionString);

            SQLiteConnection.CreateTable<User>(CreateFlags.AutoIncPK | CreateFlags.ImplicitIndex);
        }

        public static void InsertUser(object obj)
        {
            if (obj is User usr)
                SQLiteConnection.Insert(usr);
        }

        public static User SelectUser(object obj)
        {
            var lsUser = SQLiteConnection.Table<User>().ToList();

            return lsUser.Where(p => p.Email == ((User)obj).Email && p.Password == ((User)obj).Password).FirstOrDefault();
        }
    }
}
