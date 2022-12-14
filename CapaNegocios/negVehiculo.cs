using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class negVehiculo
    {
        datVehiculo datVehiculo = new datVehiculo();
        public string CreaVehiculo(entVehiculo entVehiculo)
        {

            return datVehiculo.CreaVehiculo(entVehiculo);
        }
        public DataTable MuestraVehiculo()
        {
            return datVehiculo.MuestraVehiculo();
        }

        public string EliminaVehiculo(int idVehiculo)
        {
            return datVehiculo.EliminaVehiculo(idVehiculo);
        }

        public string ModificaVehiculo(entVehiculo entVehiculo)
        {

            return datVehiculo.ModificaVehiculo(entVehiculo);
        }
        public DataTable ConsultaVehiculo(int idVehiculo)
        {

            return datVehiculo.ConsultaVehiculo(idVehiculo);
        }

        public  List<entVehiculo> ListaVehiculo ()
        {
            string jSonEnviar = "";
            List<entVehiculo> lstVehiculo = new List<entVehiculo>();
            try
            {
                negVehiculo negVehiculo = new negVehiculo();
                DataTable dtVehiculo = negVehiculo.MuestraVehiculo();
                lstVehiculo = (from DataRow dr in dtVehiculo.Rows
                               select new entVehiculo()
                               {
                                   idVehiculo = Convert.ToInt32(dr["idVehiculo"]),
                                   matricula = dr["matricula"].ToString(),
                                   modelo = dr["modelo"].ToString(),
                                   marca = dr["marca"].ToString(),
                                   capacidad = Convert.ToInt32(dr["capacidad"]),
                                   descripcion = dr["descrìpcion"].ToString()
                                   // bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                               }).ToList();
           
            }

            catch (Exception ex)
            {
                



            }
            return lstVehiculo;
         

        }
    }
}
