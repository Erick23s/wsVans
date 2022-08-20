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
    public class datRuta
    {
        public string CreaRuta(entRuta entRuta)
        {
            string devRuta = "";
            var comando = new SqlCommand("dbo.stpCreaRutas", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", entRuta.nombre);
            comando.Parameters.AddWithValue("@descripcion", entRuta.descripcion);
            comando.Parameters.AddWithValue("@horaSalida", entRuta.horaSalida);
            comando.Parameters.AddWithValue("@horaLlegada", entRuta.horaLlegada);


            try
            {
                devRuta = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devRuta = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devRuta;



        }
        public DataTable MuestraRuta()
        {
            DataTable dtRuta = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpMuestraRutas", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader drRuta = comando.ExecuteReader();
            dtRuta.Load(drRuta);
            Conexion.CierraConexion();
            return dtRuta;
        }

        public string EliminaRuta(int idRuta)
        {
            string devRuta = "";
            var comando = new SqlCommand("dbo.stpEliminaRutas", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idRuta", idRuta);
            try
            {
                devRuta = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devRuta = ex.Message;
                throw;
            }
            Conexion.CierraConexion();
            return devRuta;
        }

        public string ModificaRuta(entRuta entRuta)
        {
            string devRuta = "";
            var comando = new SqlCommand("dbo.stpEditaRutas", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idRuta", entRuta.idRuta);
            comando.Parameters.AddWithValue("@nombre", entRuta.nombre);
            comando.Parameters.AddWithValue("@descripcion", entRuta.descripcion);
            comando.Parameters.AddWithValue("@horaSalida", entRuta.horaSalida);
            comando.Parameters.AddWithValue("@horaLlegada", entRuta.horaLlegada);

            // comando.Parameters.AddWithValue("@bActivo", entRuta.bActivo);



            try
            {
                devRuta = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devRuta = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devRuta;
        }

        public DataTable ConsultaRuta(int idRuta)
        {
            DataTable dtRuta = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpConsultaRutas", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idRuta", idRuta);
            SqlDataReader drRuta = comando.ExecuteReader();
            dtRuta.Load(drRuta);
            Conexion.CierraConexion();
            return dtRuta;
        }
    }
}
