using SQLite;
using System;
using System.IO;

namespace HotTots.Droid
{
    class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }
        public SQLiteConnection GetConnection()
        {
            var fileName = "hottots.db";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}