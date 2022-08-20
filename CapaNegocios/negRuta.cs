
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
    public class negRuta
    {
        datRuta datRuta = new datRuta();
        public string CreaRuta(entRuta entRuta)
        {

            return datRuta.CreaRuta(entRuta);
        }
        public DataTable MuestraRuta()
        {
            return datRuta.MuestraRuta();
        }

        public string EliminaRuta(int idRuta)
        {
            return datRuta.EliminaRuta(idRuta);
        }

        public string ModificaRuta(entRuta entRuta)
        {

            return datRuta.ModificaRuta(entRuta);
        }
        public DataTable ConsultaRuta(int idRuta)
        {

            return datRuta.ConsultaRuta(idRuta);
        }

        
            public List<entRuta> ListaRuta()
            {
            string jSonEnviar = "";
            List<entRuta> lstRuta = new List<entRuta>();
            try
            {
                negRuta negRuta = new negRuta();
                DataTable dtRuta = negRuta.MuestraRuta();
                lstRuta = (from DataRow dr in dtRuta.Rows
                           select new entRuta()
                           {
                               idRuta = Convert.ToInt32(dr["idRuta"]),
                               nombre = dr["nombre"].ToString(),
                               descripcion = dr["descripcion"].ToString(),
                               horaSalida = dr["horaSalida"].ToString(),
                               horaLlegada = dr["horaLlegada"].ToString()
                               // bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                           }).ToList();
           
            }

            catch (Exception ex)
            {
               



            }
            return lstRuta;


        }
    }
}
