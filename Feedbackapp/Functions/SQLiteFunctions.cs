using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Feedbackapp.Model;
using SQLite;
using static System.Environment;

namespace Feedbackapp.Functions
{
    public class SQLiteFunctions
    {
        private static readonly string connectionString = Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), @"SqLiteDatabase.db3");
        private static SQLiteAsyncConnection SQLiteConnection { get; set; }

        static SQLiteFunctions()
        {
            CreateTables();
        }

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

        public async static Task<User> SelectUser(object obj)
        {
            var lsUser = await SQLiteConnection.Table<User>().ToListAsync();

            //lambda expression - LinQ - pesquisa dentro da lista se um usuario (objeto P) tem propriedades iguais ao obj passado como parametro
            return lsUser.Where(p => p.Email == ((User)obj).Email && p.Password == ((User)obj).Password).FirstOrDefault();

            //LinQ expression - SQL dentro do C#
            //var ienumUser = from p in lsUser where p.Email == ((User)obj).Email && p.Password == ((User)obj).Password select p;
        }
    }
}
