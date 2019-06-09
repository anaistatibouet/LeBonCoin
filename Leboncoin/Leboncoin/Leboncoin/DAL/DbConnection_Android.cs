using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Leboncoin.DAL;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DbConnection_Android))]
namespace Leboncoin.DAL
{
    public class DbConnection_Android : IDbConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbname = "leboncoin.db";
            var path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), dbname);
            return new SQLiteConnection(path);
        }
    }
}
