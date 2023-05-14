using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public abstract class ConexionDao
    {
        protected SQLiteConnection GetConexion()
        {
            return new SQLiteConnection("Data Source=Store_db.db");
        }
    }
}
