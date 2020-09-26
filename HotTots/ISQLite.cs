using SQLite;

namespace HotTots
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
