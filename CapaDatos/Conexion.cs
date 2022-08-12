using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CapaDatos
{
    internal class Conexion
    {

        const string CadenaConexion = @"data source=ERICK; initial catalog=dbvans; integrated security=true";
        private static readonly SqlConnection conexion = new SqlConnection(CadenaConexion);
        public static SqlConnection AbreConexion()
        {
            try
            {
                conexion.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return conexion;

        }
        public static void CierraConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
