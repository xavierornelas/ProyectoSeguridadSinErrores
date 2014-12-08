using PuntoDeVenta.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.DAO
{
    public class DAOContrasena_fecha
    {
        public void InsertContrasena_fecha(contrasena_fecha contrasena)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();
                //Checar tabla de abonos cliente
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO contrasena_fecha ([id_usuario],[fecha]) Values (" + contrasena.id_usuario + ",'" + contrasena.fecha + "')";

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public contrasena_fecha GetContrasena_fecha(int id)
        {
            contrasena_fecha usuario = null;

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM contrasena_fecha WHERE id_usuario=" + id + ";";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new contrasena_fecha(
                    int.Parse(reader["id_usuario"].ToString()),
                    reader["fecha"].ToString()
                    
                    );
            }

            return usuario;
        }
        public void ModifyContrasena_fecha(contrasena_fecha usuario)
        {
            SqlCeConnection conn = null;
            try
            {
                conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
                conn.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "UPDATE usuarios SET contrasena='" + usuario.Contrasenia + "',privilegios='" + usuario.Privilegios + "', nombre='" + usuario.Nombre + "' WHERE id=" + usuario.Id;
                cmd.CommandText = "UPDATE contrasena_fecha SET fecha='" + usuario.fecha + "' WHERE id_usuario=" + usuario.id_usuario;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }
        public int ObtenerDias(int id)
        {
            contrasena_fecha usuario = null;

            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\DB\DB_local.sdf");
            conn.Open();

            //commands represent a query or a stored procedure
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM contrasena_fecha WHERE id_usuario=" + id + ";";
            SqlCeDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new contrasena_fecha(
                    int.Parse(reader["id_usuario"].ToString()),
                    reader["fecha"].ToString()

                    );
            }

            DateTime date1 = DateTime.Now;
            DateTime date2 = Convert.ToDateTime(usuario.fecha);
            TimeSpan ts = date1 - date2;
            return ts.Days;
        }
    }
}
