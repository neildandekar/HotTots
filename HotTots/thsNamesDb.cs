using HotTots.Droid.Model;
using HotTots.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HotTots
{
    public class thsNamesDb
    {
        private SQLiteConnection _connection;
        public thsNamesDb()
        {
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, "hottots.db");
            _connection = new SQLiteConnection(path );
            _connection.CreateTable<thsNames>();
        }
        public IEnumerable<thsNames> GetStudents()
        {
            return (from t in _connection.Table<thsNames>()
                    select t).ToList();
        }

    }
}
