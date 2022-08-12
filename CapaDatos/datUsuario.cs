using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class datUsuario
    {
        public string CreaUsuario(entUsuario entUsuario)
        {
            string devUsuario = "";
            var comando = new SqlCommand("dbo.stpCreaUsuario", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", entUsuario.usuario);
            comando.Parameters.AddWithValue("@nombre", entUsuario.nombre);
            comando.Parameters.AddWithValue("@correo", entUsuario.correo);
            comando.Parameters.AddWithValue("@clave", entUsuario.clave);


            try
            {
                devUsuario = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devUsuario = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devUsuario;



        }
        public DataTable MuestraUsuario()
        {
            DataTable dtUsuario = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpMuestraUsuario", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader drUsuario = comando.ExecuteReader();
            dtUsuario.Load(drUsuario);
            Conexion.CierraConexion();
            return dtUsuario;
        }

        public string EliminaUsuario(int idUsuario)
        {
            string devUsuario = "";
            var comando = new SqlCommand("dbo.stpEliminaUsuario", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            try
            {
                devUsuario = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devUsuario = ex.Message;
                throw;
            }
            Conexion.CierraConexion();
            return devUsuario;
        }

        public string ModificaUsuario(entUsuario entUsuario)
        {
            string devUsuario = "";
            var comando = new SqlCommand("dbo.stpEditaUsuario", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idUsuario", entUsuario.idUsuario);
            comando.Parameters.AddWithValue("@usuario", entUsuario.usuario);
            comando.Parameters.AddWithValue("@nombre", entUsuario.nombre);
            comando.Parameters.AddWithValue("@correo", entUsuario.correo);
            comando.Parameters.AddWithValue("@clave", entUsuario.clave);
            // comando.Parameters.AddWithValue("@bActivo", entUsuario.bActivo);



            try
            {
                devUsuario = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devUsuario = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devUsuario;
        }

        public DataTable ConsultaUsuario(int idUsuario)
        {
            DataTable dtUsuario = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpConsultaUsuario", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            SqlDataReader drUsuario = comando.ExecuteReader();
            dtUsuario.Load(drUsuario);
            Conexion.CierraConexion();
            return dtUsuario;
        }
    }
}
