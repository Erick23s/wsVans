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
    public class negPasajero
    {
        datPasajero datPasajero = new datPasajero();
        public string CreaPasajero(entPasajero entPasajero)
        {

            return datPasajero.CreaPasajero(entPasajero);
        }
        public DataTable MuestraPasajero()
        {
            return datPasajero.MuestraPasajero();
        }

        public string EliminaPasajero(int idPasajero)
        {
            return datPasajero.EliminaPasajero(idPasajero);
        }

        public string ModificaPasajero(entPasajero entPasajero)
        {

            return datPasajero.ModificaPasajero(entPasajero);
        }
        public DataTable ConsultaPasajero(int idPasajero)
        {

            return datPasajero.ConsultaPasajero(idPasajero);
        }

        public  List<entPasajero> ListaPasajero ()
        {
            string jSonEnviar = "";
            List<entPasajero> lstPasajero = new List<entPasajero>();
            //List<entTipoPasajero> lstTipoPasajero = new List<entTipoPasajero>();

            //int idPasajero = sidPasajero == "" ? 0 : Convert.ToInt32(sidPasajero);


            try
            {


                negPasajero negPasajero = new negPasajero();
                negTipoPasajero negtipopasajero = new negTipoPasajero();
                DataTable dtPasajero =  negPasajero.MuestraPasajero();
                lstPasajero = (from DataRow dr in dtPasajero.Rows
                               select new entPasajero()
                               {
                                   idPasajero = Convert.ToInt32(dr["idPasajero"]),
                                   nombre = dr["nombre"].ToString(),
                                   apellido = dr["apellido"].ToString(),
                                   telefono = dr["telefono"].ToString(),
                                   idTipoPasajero = Convert.ToInt32(dr["idTipoPasajero"])
                                   // bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                               }).ToList();
               
            
            }

            catch (Exception ex)
            {
            


            }
            return lstPasajero;

        }

    }
}
