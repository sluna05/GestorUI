﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Entidades;

namespace Datos
{
    public class Permisos:ConexionDao
    {
        public void Registrar(Modelo permiso)
        {
            using (var cnn = GetConexion())
            {
                cnn.Open();
                using (var cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = @"Insert into Permisos(Nombre,IsActivo) values(@name,@state)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@name", permiso._Nombre);
                    cmd.Parameters.AddWithValue("@state", permiso._state);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actulizar(Modelo permiso)
        {
            using (var cnn = GetConexion())
            {
                cnn.Open();
                using (var cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = @"Update Permisos Set Nombre=@name,IsActivo=@state where Id=@id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", permiso._Id);
                    cmd.Parameters.AddWithValue("@name", permiso._Nombre);
                    cmd.Parameters.AddWithValue("@state", permiso._state);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
