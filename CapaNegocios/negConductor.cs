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
    public class negConductor
    {
        datConductor datconductor = new datConductor();
        public string CreaConductor(entConductor entconductor)
        {

            return datconductor.CreaConductor(entconductor);
        }
        public DataTable MuestraConductor()
        {
            return datconductor.MuestraConductor();
        }

        public string EliminaConductor(int idConductor)
        {
            return datconductor.EliminaConductor(idConductor);
        }

        public string ModificaConductor(entConductor entconductor)
        {

            return datconductor.ModificaConductor(entconductor);
        }
        public DataTable ConsultaConductor(int idConductor)
        {

            return datconductor.ConsultaConductor(idConductor);
        }

    }
}
