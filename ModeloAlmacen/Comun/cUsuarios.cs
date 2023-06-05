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
    public class cUsuarios
    {
        dUsuarios obj = new dUsuarios();
        public bool cLogin(string usuario,string password,int tienda)
        {
            return obj.IniciarSesion(usuario, password, tienda);
        }
        public void RegistrarUsuario(Usuarios user)
        {
            obj.NuevoUsuario(user);
        }
        public DataTable GetUsuarios()
        {
            return obj.TabUsuarios();
        }
    }
}
