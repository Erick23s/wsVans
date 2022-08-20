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
    public class datStatusReserva
    {
        public string CreaTipoPasajero(entTipoPasajero entTipoPasajero)
        {
            string devTipoPasajero = "";
            var comando = new SqlCommand("dbo.stpCreaTipoPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", entTipoPasajero.nombre);



            try
            {
                devTipoPasajero = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devTipoPasajero = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devTipoPasajero;



        }
        public DataTable MuestraTipoPasajero()
        {
            DataTable dtTipoPasajero = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpMuestraTipoPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader drTipoPasajero = comando.ExecuteReader();
            dtTipoPasajero.Load(drTipoPasajero);
            Conexion.CierraConexion();
            return dtTipoPasajero;
        }

        public string EliminaTipoPasajero(int idTipoPasajero)
        {
            string devTipoPasajero = "";
            var comando = new SqlCommand("dbo.stpEliminaTipoPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idTipoPasajero", idTipoPasajero);
            try
            {
                devTipoPasajero = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devTipoPasajero = ex.Message;
                throw;
            }
            Conexion.CierraConexion();
            return devTipoPasajero;
        }

        public string ModificaTipoPasajero(entTipoPasajero entTipoPasajero)
        {
            string devTipoPasajero = "";
            var comando = new SqlCommand("dbo.stpEditaTipoPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idTipoPasajero", entTipoPasajero.idTipoPasajero);
            comando.Parameters.AddWithValue("@nombre", entTipoPasajero.nombre);



            try
            {
                devTipoPasajero = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devTipoPasajero = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devTipoPasajero;
        }

        public DataTable ConsultaTipoPasajero(int idTipoPasajero)
        {
            DataTable dtTipoPasajero = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpConsultaTipoPasajero", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idTipoPasajero", idTipoPasajero);
            SqlDataReader drTipoPasajero = comando.ExecuteReader();
            dtTipoPasajero.Load(drTipoPasajero);
            Conexion.CierraConexion();
            return dtTipoPasajero;
        }
    }
}
