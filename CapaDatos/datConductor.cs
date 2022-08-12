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
    public class datConductor
    {

        public string CreaConductor(entConductor entconductor)
        {
            string devConductor = "";
            var comando = new SqlCommand("dbo.stpCreaConductor", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", entconductor.nombre);
            comando.Parameters.AddWithValue("@apellido", entconductor.apellido);
            comando.Parameters.AddWithValue("@telefono", entconductor.telefono);
          //  comando.Parameters.AddWithValue("@bActivo", entconductor.bActivo);

            try
            {
                devConductor = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devConductor = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devConductor;



        }
        public DataTable MuestraConductor()
        {
            DataTable dtConductor = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpMuestraConductor", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader drConductor = comando.ExecuteReader();
            dtConductor.Load(drConductor);
            Conexion.CierraConexion();
            return dtConductor;
        }

        public string EliminaConductor(int idConductor)
        {
            string devConductor = "";
            var comando = new SqlCommand("dbo.stpEliminaConductor", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idConductor", idConductor);
            try
            {
                devConductor = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devConductor = ex.Message;
                throw;
            }
            Conexion.CierraConexion();
            return devConductor;
        }

        public string ModificaConductor(entConductor entconductor)
        {
            string devConductor = "";
            var comando = new SqlCommand("dbo.stpEditaConductor", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idConductor", entconductor.idConductor);
            comando.Parameters.AddWithValue("@nombre", entconductor.nombre);
            comando.Parameters.AddWithValue("@apellido", entconductor.apellido);
            comando.Parameters.AddWithValue("@telefono", entconductor.telefono);
           // comando.Parameters.AddWithValue("@bActivo", entconductor.bActivo);



            try
            {
                devConductor = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devConductor = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devConductor;
        }

        public DataTable ConsultaConductor(int idConductor)
        {
            DataTable dtConductor = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpConsultaConductor", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idConductor", idConductor);
            SqlDataReader drConductor = comando.ExecuteReader();
            dtConductor.Load(drConductor);
            Conexion.CierraConexion();
            return dtConductor;
        }

    }
}
