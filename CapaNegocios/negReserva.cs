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
    public class negReserva
    {
      
            datReserva datReserva = new datReserva();
            public string CreaReserva(entReserva entReserva)
            {

                return datReserva.CreaReserva(entReserva);
            }
            public DataTable MuestraReserva()
            {
                return datReserva.MuestraReserva();
            }

            public string EliminaReserva(int idReserva)
            {
                return datReserva.EliminaReserva(idReserva);
            }

            public string ModificaReserva(entReserva entReserva)
            {

                return datReserva.ModificaReserva(entReserva);
            }
            public DataTable ConsultaReserva(int idReserva)
            {

                return datReserva.ConsultaReserva(idReserva);
            }

        
    }
}
