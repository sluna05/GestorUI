using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using Datos;

namespace Comun
{
    public class cPermisos
    {
        Permisos obj = new Permisos();
        public void Registrar(Modelo permiso)
        {
            obj.Registrar(permiso);
        }
        public void Actualizar(Modelo permiso)
        {
            obj.Actulizar(permiso);
        }
        public List<Modelo> GetPermisos()
        {
            var Datos = obj.TabPermisos();
            var Lista = new List<Modelo>();
            foreach (DataRow item in Datos.Rows)
            {
                var Per = new Modelo
                {
                    _Id = Convert.ToInt32(item[0]),
                    _Nombre = item[1].ToString(),
                    _state = Convert.ToByte(item[2])
                };
                Lista.Add(Per);
            }
            return Lista;
        }
    }
}
