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
    public class datPasajero
    {
        public string CreaPasajero(entPasajero entPasajero)
        {
            string devPasajero = "";
            var comando = new SqlCommand("dbo.stpCreaPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", entPasajero.nombre);
            comando.Parameters.AddWithValue("@apellido", entPasajero.apellido);
            comando.Parameters.AddWithValue("@telefono", entPasajero.telefono);
            comando.Parameters.AddWithValue("@idTipoPasajero", entPasajero.idTipoPasajero);
         

            try
            {
                devPasajero = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devPasajero = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devPasajero;



        }
        public DataTable MuestraPasajero()
        {
            DataTable dtPasajero = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpMuestraPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader drPasajero = comando.ExecuteReader();
            dtPasajero.Load(drPasajero);
            Conexion.CierraConexion();
            return dtPasajero;
        }

        public string EliminaPasajero(int idPasajero)
        {
            string devPasajero = "";
            var comando = new SqlCommand("dbo.stpEliminaPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPasajero", idPasajero);
            try
            {
                devPasajero = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devPasajero = ex.Message;
                throw;
            }
            Conexion.CierraConexion();
            return devPasajero;
        }

        public string ModificaPasajero(entPasajero entPasajero)
        {
            string devPasajero = "";
            var comando = new SqlCommand("dbo.stpEditaPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPasajero", entPasajero.idPasajero);
            comando.Parameters.AddWithValue("@nombre", entPasajero.nombre);
            comando.Parameters.AddWithValue("@apellido", entPasajero.apellido);
            comando.Parameters.AddWithValue("@telefono", entPasajero.telefono);
            comando.Parameters.AddWithValue("@idTipoPasajero", entPasajero.idTipoPasajero);
            // comando.Parameters.AddWithValue("@bActivo", entPasajero.bActivo);



            try
            {
                devPasajero = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devPasajero = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devPasajero;
        }

        public DataTable ConsultaPasajero(int idPasajero)
        {
            DataTable dtPasajero = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpConsultaPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPasajero", idPasajero);
            SqlDataReader drPasajero = comando.ExecuteReader();
            dtPasajero.Load(drPasajero);
            Conexion.CierraConexion();
            return dtPasajero;
        }

    }
}
