using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Comun
{
    public class cTienda
    {
        public List<Modelo> GetTienda()
        {
            dTienda obj = new dTienda();
            var datos = obj.GetTienda();
            var Lista = new List<Modelo>();
            foreach (DataRow item in datos.Rows)
            {
                var tienda = new Modelo {
                    Id = Convert.ToInt32(item[0]),
                    Nombre =item[1].ToString(),
                    state =Convert.ToByte(item[2])};
                Lista.Add(tienda);
            }
            return Lista;
        }
    }
}
