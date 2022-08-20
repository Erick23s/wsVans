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
    public class negTipoPasajero
    {
        datTipoPasajero datTipoPasajero = new datTipoPasajero();
        public string CreaTipoPasajero(entTipoPasajero entTipoPasajero)
        {

            return datTipoPasajero.CreaTipoPasajero(entTipoPasajero);
        }
        public DataTable MuestraTipoPasajero()
        {
            return datTipoPasajero.MuestraTipoPasajero();
        }

        public string EliminaTipoPasajero(int idTipoPasajero)
        {
            return datTipoPasajero.EliminaTipoPasajero(idTipoPasajero);
        }

        public string ModificaTipoPasajero(entTipoPasajero entTipoPasajero)
        {

            return datTipoPasajero.ModificaTipoPasajero(entTipoPasajero);
        }
        public DataTable ConsultaTipoPasajero(int idTipoPasajero)
        {

            return datTipoPasajero.ConsultaTipoPasajero(idTipoPasajero);
        }


        public List<entTipoPasajero> ListaTipoPasajero(/*string sidTipoPasajero*/)
        {
            string jSonEnviar = "";
            List<entTipoPasajero> lstTipoPasajero = new List<entTipoPasajero>();
            //int idTipoPasajero = sidTipoPasajero == "" ? 0 : Convert.ToInt32(sidTipoPasajero);
            try
            {

                negTipoPasajero negTipoPasajero = new negTipoPasajero();
                DataTable dtTipoPasajero = negTipoPasajero.MuestraTipoPasajero();
                lstTipoPasajero = (from DataRow dr in dtTipoPasajero.Rows
                                   select new entTipoPasajero()
                                   {
                                       idTipoPasajero = Convert.ToInt32(dr["idTipoPasajero"]),
                                       nombre = dr["nombre"].ToString(),
                                       bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                                   }).ToList();

                //JSON.Clear();
                //JSON.Add("1Error", false);
                //JSON.Add("cError", "");
                //JSON.Add("LstTipoPasajero", lstTipoPasajero);
                //jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }


            catch (Exception ex)
            {
                //JSON.Clear();
                //JSON.Add("1Error", true);
                //JSON.Add("cError", ex.Message);
                //JSON.Add("LstTipoPasajero", "");



            }
            return lstTipoPasajero;
            //jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            //Context.Response.Clear();
            //Context.Response.Write(jSonEnviar);
            //Context.Response.Flush();
            //Context.Response.End();

        }

       
        
    }
}
