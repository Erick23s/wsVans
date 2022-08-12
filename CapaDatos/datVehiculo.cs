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
    public class datVehiculo
    {
        public string CreaVehiculo(entVehiculo entVehiculo)
        {
            string devVehiculo = "";
            var comando = new SqlCommand("dbo.stpCreaVehiculo", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@matricula", entVehiculo.matricula);
            comando.Parameters.AddWithValue("@modelo", entVehiculo.modelo);
            comando.Parameters.AddWithValue("@marca", entVehiculo.marca);
            comando.Parameters.AddWithValue("@capacidad", entVehiculo.capacidad);
            comando.Parameters.AddWithValue("@descrìpcion", entVehiculo.descripcion);

            try
            {
                devVehiculo = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devVehiculo = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devVehiculo;



        }
        public DataTable MuestraVehiculo()
        {
            DataTable dtVehiculo = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpMuestraVehiculo", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader drVehiculo = comando.ExecuteReader();
            dtVehiculo.Load(drVehiculo);
            Conexion.CierraConexion();
            return dtVehiculo;
        }

        public string EliminaVehiculo(int idVehiculo)
        {
            string devVehiculo = "";
            var comando = new SqlCommand("dbo.stpEliminaVehiculo", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idVehiculo", idVehiculo);
            try
            {
                devVehiculo = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devVehiculo = ex.Message;
                throw;
            }
            Conexion.CierraConexion();
            return devVehiculo;
        }

        public string ModificaVehiculo(entVehiculo entVehiculo)
        {
            string devVehiculo = "";
            var comando = new SqlCommand("dbo.stpEditaVehiculo", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idVehiculo", entVehiculo.idVehiculo);
            comando.Parameters.AddWithValue("@matricula", entVehiculo.matricula);
            comando.Parameters.AddWithValue("@modelo", entVehiculo.modelo);
            comando.Parameters.AddWithValue("@marca", entVehiculo.marca);
            comando.Parameters.AddWithValue("@capacidad", entVehiculo.capacidad);
            comando.Parameters.AddWithValue("@descrìpcion", entVehiculo.descripcion);
            // comando.Parameters.AddWithValue("@bActivo", entVehiculo.bActivo);



            try
            {
                devVehiculo = comando.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                devVehiculo = ex.Message;
                throw;
            }

            Conexion.CierraConexion();
            return devVehiculo;
        }

        public DataTable ConsultaVehiculo(int idVehiculo)
        {
            DataTable dtVehiculo = new DataTable();
            SqlCommand comando = new SqlCommand("dbo.stpConsultaVehiculo", Conexion.AbreConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idVehiculo", idVehiculo);
            SqlDataReader drVehiculo = comando.ExecuteReader();
            dtVehiculo.Load(drVehiculo);
            Conexion.CierraConexion();
            return dtVehiculo;
        }
    }
}
