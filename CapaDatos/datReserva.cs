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
    public class datReserva
    {
        public string CreaReserva(entReserva entReserva)
        {
            string devReserva = "";
            var comando = new SqlCommand("dbo.stpCreaReserva", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdRuta", entReserva.idRuta);
            comando.Parameters.AddWithValue("@idPasajero", entReserva.idPasajero);
            comando.Parameters.AddWithValue("@idVehiculo", entReserva.idVehiculo);
            comando.Parameters.AddWithValue("@Asiento", entReserva.Asiento);
            //comando.Parameters.AddWithValue("@horaReserva", entReserva.horaReserva);


            try
            {
                devReserva = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devReserva = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devReserva;



        }
        public DataTable MuestraReserva()
        {
            DataTable dtReserva = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpMuestraReserva", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader drReserva = comando.ExecuteReader();
            dtReserva.Load(drReserva);
            Conexion.CierraConexion();
            return dtReserva;
        }

        public string EliminaReserva(int idReserva)
        {
            string devReserva = "";
            var comando = new SqlCommand("dbo.stpEliminaReserva", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idReserva", idReserva);
            try
            {
                devReserva = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devReserva = ex.Message;
                throw;
            }
            Conexion.CierraConexion();
            return devReserva;
        }

        public string ModificaReserva(entReserva entReserva)
        {
            string devReserva = "";
            var comando = new SqlCommand("dbo.stpEditaReserva", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idReserva", entReserva.idReserva);
            comando.Parameters.AddWithValue("@idPasajero", entReserva.idPasajero);
            comando.Parameters.AddWithValue("@IdRuta", entReserva.idRuta);
            comando.Parameters.AddWithValue("@idvehiculo", entReserva.idVehiculo);
            comando.Parameters.AddWithValue("@Asiento", entReserva.Asiento);
            //comando.Parameters.AddWithValue("@horaReserva", entReserva.horaReserva);
            // comando.Parameters.AddWithValue("@bActivo", entReserva.bActivo);



            try
            {
                devReserva = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devReserva = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devReserva;
        }

        public DataTable ConsultaReserva(int idReserva)
        {
            DataTable dtReserva = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpConsultaReserva", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idReserva", idReserva);
            SqlDataReader drReserva = comando.ExecuteReader();
            dtReserva.Load(drReserva);
            Conexion.CierraConexion();
            return dtReserva;
        }
    }
}
