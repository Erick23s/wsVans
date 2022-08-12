
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
    }
}
