using SQLite;

namespace CalcSW_XForms.Halpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
