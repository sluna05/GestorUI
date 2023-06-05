using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Datos
{
    public class dTienda:ConexionDao
    {
        public DataTable GetTienda()
        {
            using(var cnn =GetConexion())
            {
                cnn.Open();
                using (var cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = @"Select Id,Nombre,IsActivo from Tienda where IsActivo=1
                                            union  select  0,'--SELECCIONE TIENDA--',1 order by 1";
                    cmd.CommandType = CommandType.Text;
                    var Rider = cmd.ExecuteReader();
                    var Tab = new DataTable();
                    Tab.Load(Rider);
                    return Tab;
                }
            }
        }
    }
}
