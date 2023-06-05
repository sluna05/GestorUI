using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Cache
    {
        public static int IdUsuario { get; set; }
        public static string Usuario { get; set; }
        public static int IdRol { get; set; }
        public static string Rol { get; set; }
        public static int IdTienda { get; set; }
        public static string Tienda { get; set; }
        //Validacion de permiso
        public static bool ValorPermiso { get; set; }

        //Tamaño del panel contenedor
        public static int alto { get; set; }
        public static int ancho { get; set; }
    }
}
