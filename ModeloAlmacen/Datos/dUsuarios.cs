using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using System.Data.SQLite;

namespace Datos
{
    public class dUsuarios:ConexionDao
    {
        public void ValidarPermiso(int IdRol,int IdPermiso)
        {
            using (var cnn = GetConexion())
            {
                cnn.Open();
                using(var cmd = new SQLiteCommand())
                {
                 
                        cmd.Connection = cnn;
                        cmd.CommandText = @"SELECT ax.Id,
                                                   p.Nombre,
                                                   ax.IsActivo
                                              FROM AuxPermiRol ax
                                                   INNER JOIN
                                                   Permisos p ON p.Id = ax.IdPermiso
                                             WHERE ax.IdRol = @rol AND
                                                   ax.IdPermiso = @permiso AND
                                                   ax.IsActivo = 1";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@rol", IdRol);
                        cmd.Parameters.AddWithValue("@permiso", IdPermiso);
                        var Rider = cmd.ExecuteReader();
                        if (Rider.HasRows)
                        {
                            Cache.ValorPermiso= true;
                        }else
                        {
                            Cache.ValorPermiso = false;
                        }         
                }
            }
        }
        public bool IniciarSesion(string user, string pass, int tienda)
        {
            using (var cnn = GetConexion())
            {
                cnn.Open();
                using (var comando = new SQLiteCommand())
                {
                    comando.Connection = cnn;
                    comando.CommandText = @"SELECT u.IdUsu,
                                                   u.Login,
                                                   u.IdRol,
                                                   r.Nombre AS Rol,
                                                   e.IdTienda,
                                                   t.Nombre AS Tienda
                                              FROM Usuarios u
                                                   INNER JOIN
                                                   Empleados e ON u.IdEmp = e.Id
                                                   INNER JOIN
                                                   Tienda t ON t.Id = e.IdTienda
                                                   INNER JOIN
                                                   Roles r ON r.Id = u.IdRol
                                             WHERE u.Login = @usu AND 
                                                   Password = @pass AND 
                                                   u.IsActivo = 'ACTIVO' AND 
                                                   e.IdTienda = @tienda";
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@tienda", tienda);
                    comando.Parameters.AddWithValue("@usu", user);
                    comando.Parameters.AddWithValue("@pass", pass);
                    var rider = comando.ExecuteReader();
                    if (rider.HasRows)
                    {
                        while (rider.Read())
                        {
                            Cache.IdUsuario = rider.GetInt32(0);
                            Cache.Usuario = rider.GetString(1);
                            Cache.IdRol = rider.GetInt32(2);
                            Cache.Rol = rider.GetString(3);
                            Cache.IdTienda = rider.GetInt32(4);
                            Cache.Tienda = rider.GetString(5);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public string NuevoUsuario(Usuarios user)
        {
            using (var cnn = GetConexion())
            {
                cnn.Open();
                using(var cmd= new SQLiteCommand())
                {
                    try
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = @"Insert into Usuarios(IdEmpleado,IdRol,Login,Password,IsActivo)
                                                      values(@empleado,@rol,@login,@clave,@estado)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@empleado", user.IdEmp);
                        cmd.Parameters.AddWithValue("@rol", user.IdRol);
                        cmd.Parameters.AddWithValue("@login", user.Login);
                        cmd.Parameters.AddWithValue("@clave", user.Password);
                        cmd.Parameters.AddWithValue("@estado", user.Estado);
                        cmd.ExecuteNonQuery();
                        return "Operacion exitosa";
                    }
                    catch (Exception)
                    {
                        return "No se pudo ejecutar la operacion...";
                    }
                    
                }
            }
        }     
        public void EditarUsuario(Usuarios user)
        {
            using(var conexion = GetConexion())
            {
                conexion.Open();
                using(var sql=new SQLiteCommand())
                {
                    sql.Connection = conexion;
                    sql.CommandText = "Update Usuarios set IdRol=@rol,IsActivo=@estado where Id=@id";
                    sql.CommandType = CommandType.Text;
                    sql.Parameters.AddWithValue("@rol", user.IdRol);
                    sql.Parameters.AddWithValue("@estado", user.Estado);
                    sql.ExecuteNonQuery();
                }
            }
        }
        public DataTable TabUsuarios()
        {
            using(var cnn = GetConexion())
            {
                cnn.Open();
                using(var cmd= new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = @"SELECT u.IdUsu,
                                               e.Nombres,
                                               e.Apellidos,
                                               u.Login,
                                               r.Nombre,
                                               u.IsActivo
                                          FROM Usuarios u
                                               INNER JOIN
                                               Empleados e ON e.Id = u.IdUsu
                                               INNER JOIN
                                               Roles r ON r.Id = u.IdRol";
                    var Rider = cmd.ExecuteReader();
                    var Tab = new DataTable();
                    Tab.Load(Rider);
                    return Tab;
                }
            }
        }

    }
}