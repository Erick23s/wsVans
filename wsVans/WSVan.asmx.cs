using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CapaEntidades;
using CapaNegocios;
using System.Data;
using System.Web.Script.Serialization;

namespace wsVans
{
    /// <summary>
    /// Summary description for WSVan
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WSVan : System.Web.Services.WebService
    {
        Dictionary<string, object> JSON = new Dictionary<string, object>();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public void ListaConductor(string sidConductor)
        {
            string jSonEnviar = "";
            List<entConductor> lstConductor = new List<entConductor>();
            int idconductor = sidConductor == "" ? 0 : Convert.ToInt32(sidConductor);
            

            try
            {
                
                negConductor negConductor = new negConductor();

                
                DataTable dtConductor = idconductor != 0 ? negConductor.ConsultaConductor(idconductor) : negConductor.MuestraConductor();
                lstConductor = (from DataRow dr in dtConductor.Rows
                            select new entConductor()
                            {
                                idConductor = Convert.ToInt32(dr["idConductor"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                telefono = dr["telefono"].ToString() ,                          
                               bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                            }).ToList();
                JSON.Clear();
                JSON.Add("1Error", false);
                JSON.Add("cError", "");
                JSON.Add("LstConductor", lstConductor);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }

            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("1Error", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("LstConductor", "");



            }
            jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();

        }

        [WebMethod]
        public void EliminaConductor(int idConductor)
        {
            try
            {
                negConductor negConductor = new negConductor();
                string Eliminado = negConductor.EliminaConductor(idConductor);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Conductor", Eliminado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Conductor", "");
                throw;
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void ConsultaConductor(int idConductor)
        {
            string jSonEnviar = "";
            List<entConductor> lstConductor = new List<entConductor>();
            try
            {
                negConductor negConductor = new negConductor();
                DataTable dtConductor = negConductor.ConsultaConductor(idConductor);

                lstConductor = (from DataRow dr in dtConductor.Rows
                            select new entConductor()
                            {
                                idConductor = Convert.ToInt32(dr["idConductor"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                            }).ToList();
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("sError", "");
                JSON.Add("Conductor", lstConductor);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("sError", ex.Message);
                JSON.Add("Conductor", "");

            }
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void GuardaConductor(string sidConductor, string snombre, string sapellido, string stelefono)
        {

            try
            {
                int idConductor = sidConductor == "" ? 0 : Convert.ToInt32(sidConductor); 
                negConductor negConductor = new negConductor();
                entConductor entConductor = new entConductor();
                entConductor.idConductor = idConductor;
                entConductor.nombre = snombre;
                entConductor.apellido = sapellido;
                entConductor.telefono = stelefono;
              

                string Guardado = idConductor != 0 ? negConductor.ModificaConductor(entConductor) : negConductor.CreaConductor(entConductor);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Conductor", Guardado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Conductor", "");
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        /*---------------------------------------PASAJERO-----------------------------------------------------------*/
        [WebMethod]
        public void ListaPasajero(string sidPasajero)
        {
            string jSonEnviar = "";
            List<entPasajero> lstPasajero = new List<entPasajero>();
            List<entTipoPasajero> lstTipoPasajero = new List<entTipoPasajero>();

            int idPasajero = sidPasajero == "" ? 0 : Convert.ToInt32(sidPasajero);


            try
            {
                
                
                negPasajero negPasajero = new negPasajero();
                negTipoPasajero negtipopasajero = new negTipoPasajero();
                DataTable dtPasajero = idPasajero != 0 ? negPasajero.ConsultaPasajero(idPasajero) : negPasajero.MuestraPasajero(); 
                lstPasajero = (from DataRow dr in dtPasajero.Rows
                               select new entPasajero()
                               {
                                   idPasajero = Convert.ToInt32(dr["idPasajero"]),
                                   nombre = dr["nombre"].ToString(),
                                   apellido = dr["apellido"].ToString(),
                                   telefono = dr["telefono"].ToString(),
                                   idTipoPasajero = Convert.ToInt32(dr["idTipoPasajero"]),
                                   TipoPasajero = dr["TipoPasajero"].ToString()

                                   // bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                               }).ToList();
                lstTipoPasajero = negtipopasajero.ListaTipoPasajero();
                JSON.Clear();
                JSON.Add("1Error", false);
                JSON.Add("cError", "");
                JSON.Add("LstPasajero", lstPasajero);
                JSON.Add("LstTipoPasajero", lstTipoPasajero);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }

            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("1Error", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("LstPasajero", "");
                JSON.Add("LstTipoPasajero", "");


            }
            jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();

        }

        [WebMethod]
        public void EliminaPasajero(string  sidPasajero)
        {
            try
            {
                int idPasajero=Convert.ToInt32(sidPasajero);
                negPasajero negPasajero = new negPasajero();
                string Eliminado = negPasajero.EliminaPasajero(idPasajero);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Pasajero", Eliminado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Pasajero", "");
                throw;
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void ConsultaPasajero(int idPasajero)
        {
            string jSonEnviar = "";
            List<entPasajero> lstPasajero = new List<entPasajero>();
            try
            {
                negPasajero negPasajero = new negPasajero();
                DataTable dtPasajero = negPasajero.ConsultaPasajero(idPasajero);

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
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("sError", "");
                JSON.Add("Pasajero", lstPasajero);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("sError", ex.Message);
                JSON.Add("Pasajero", "");

            }
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void GuardaPasajero(string sidPasajero, string snombre, string sapellido, string stelefono, string sidTipoPasajero)
        {

            try
            {
                int idPasajero = sidPasajero == "" ? 0 : Convert.ToInt32(sidPasajero);
                negPasajero negPasajero = new negPasajero();
                entPasajero entPasajero = new entPasajero();
                entPasajero.idPasajero = idPasajero;
                entPasajero.nombre = snombre;
                entPasajero.apellido = sapellido;
                entPasajero.telefono = stelefono;
                entPasajero.idTipoPasajero = Convert.ToInt32(sidTipoPasajero);


                string Guardado = idPasajero != 0 ? negPasajero.ModificaPasajero(entPasajero) : negPasajero.CreaPasajero(entPasajero);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Pasajero", Guardado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Pasajero", "");
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
/*---------------------------------------Reserva-----------------------------------------------------------*/

        [WebMethod]
        public void ListaReserva(string sidReserva)
        {
            string jSonEnviar = "";
            List<entReserva> lstReserva = new List<entReserva>();
            List<entRuta> lstRuta = new List<entRuta>();
            List<entPasajero> lstPasajero = new List<entPasajero>();
            List<entVehiculo> lstVehiculo= new List<entVehiculo>();

            try
            {
                int idReserva = sidReserva == "" ? 0 : Convert.ToInt32(sidReserva);
                negReserva negReserva = new negReserva();
                negRuta negruta = new negRuta();
                negPasajero negpasajero = new negPasajero();
                negVehiculo negvehiculo = new negVehiculo();
                DataTable dtReserva = idReserva != 0 ? negReserva.ConsultaReserva(idReserva) : negReserva.MuestraReserva();
                lstReserva = (from DataRow dr in dtReserva.Rows
                              select new entReserva()
                              {
                                  idReserva = Convert.ToInt32(dr["idReserva"]),
                                  idPasajero = Convert.ToInt32(dr["idPasajero"]),
                                  idRuta = Convert.ToInt32(dr["idRuta"]),
                                  idVehiculo = Convert.ToInt32(dr["idVehiculo"]),
                                  Pasajero = dr["Pasajero"].ToString(),
                                  Ruta =  dr["Ruta"].ToString(),
                                  Vehiculo = dr["Vehiculo"].ToString(),
                                  Asiento = dr["Asiento"].ToString(),
                                  horaReserva =dr["horaReserva"].ToString(),
                                  horaModificacion = dr["horaModificacion"].ToString(),
                                  bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                              }).ToList();
                lstRuta = negruta.ListaRuta();
                lstPasajero = negpasajero.ListaPasajero();
                lstVehiculo=negvehiculo.ListaVehiculo();
                JSON.Clear();
                JSON.Add("1Error", false);
                JSON.Add("cError", "");
                JSON.Add("LstReserva", lstReserva);
                JSON.Add("LstRuta", lstRuta);
                JSON.Add("LstPasajero", lstPasajero);
                JSON.Add("LstVehiculo", lstVehiculo);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }

            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("1Error", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("LstReserva", "");
                JSON.Add("LstRuta", "");
                JSON.Add("LstPasajero", "");
                JSON.Add("LstVehiculo", "");

            }
            jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();

        }

        [WebMethod]
        public void EliminaReserva(int idReserva)
        {
            try
            {
                negReserva negReserva = new negReserva();
                string Eliminado = negReserva.EliminaReserva(idReserva);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Reserva", Eliminado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Reserva", "");
                throw;
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void ConsultaReserva(int idReserva)
        {
            string jSonEnviar = "";
            List<entReserva> lstReserva = new List<entReserva>();
           // List<entPasajero> lstPasajero = new List<entPasajero>();
            try
            {
                negReserva negReserva = new negReserva();
               // negPasajero negpasajero
                DataTable dtReserva = negReserva.ConsultaReserva(idReserva);

                lstReserva = (from DataRow dr in dtReserva.Rows
                              select new entReserva()
                              {
                                  idReserva = Convert.ToInt32(dr["idReserva"]),
                                  idPasajero = Convert.ToInt32(dr["idPasajero"]),
                                  idRuta = Convert.ToInt32(dr["idRuta"]),
                                  idVehiculo = Convert.ToInt32(dr["idVehiculo"]),
                                  Asiento = dr["Asiento"].ToString(),
                                  horaReserva = dr["horaReserva"].ToString(),
                                  horaModificacion = dr["horaModificacion"].ToString(),
                                  bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                              }).ToList();
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("sError", "");
                JSON.Add("Reserva", lstReserva);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("sError", ex.Message);
                JSON.Add("Reserva", "");

            }
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void GuardaReserva(string sidreserva, string sidpasajero, string sidruta, string sidvehiculo, string sasiento)
        {

            try
            {
                int idReserva = sidreserva == "" ? 0 : Convert.ToInt32(sidreserva);
                negReserva negReserva = new negReserva();
                entReserva entReserva = new entReserva();
                entReserva.idReserva = idReserva;
                entReserva.idPasajero = Convert.ToInt32(sidpasajero);
                entReserva.idRuta = Convert.ToInt32(sidruta);
                entReserva.idVehiculo = Convert.ToInt32(sidvehiculo);
                entReserva.Asiento = sasiento;
               // entReserva.horaReserva = shorareserva;


                string Guardado = idReserva != 0 ? negReserva.ModificaReserva(entReserva) : negReserva.CreaReserva(entReserva);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Reserva", Guardado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Reserva", "");
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }

        /*---------------------------------------Ruta-----------------------------------------------------------*/

        [WebMethod]
        public void ListaRuta()
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
                               horaLlegada = dr["horaLlegada"].ToString(),
                               bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                           }).ToList();
                JSON.Clear();
                JSON.Add("1Error", false);
                JSON.Add("cError", "");
                JSON.Add("LstRuta", lstRuta);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }

            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("1Error", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("LstRuta", "");



            }
            jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();

        }

        [WebMethod]
        public void EliminaRuta(int idRuta)
        {
            try
            {
                negRuta negRuta = new negRuta();
                string Eliminado = negRuta.EliminaRuta(idRuta);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Ruta", Eliminado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Ruta", "");
                throw;
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void ConsultaRuta(int idRuta)
        {
            string jSonEnviar = "";
            List<entRuta> lstRuta = new List<entRuta>();
            try
            {
                negRuta negRuta = new negRuta();
                DataTable dtRuta = negRuta.ConsultaRuta(idRuta);

                lstRuta = (from DataRow dr in dtRuta.Rows
                           select new entRuta()
                           {
                               idRuta = Convert.ToInt32(dr["idRuta"]),
                               nombre = dr["nombre"].ToString(),
                               descripcion = dr["descripcion"].ToString(),
                               horaSalida = dr["horaSalida"].ToString(),
                               horaLlegada = dr["horaLlegada"].ToString()
                           }).ToList();
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("sError", "");
                JSON.Add("Ruta", lstRuta);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("sError", ex.Message);
                JSON.Add("Ruta", "");

            }
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void GuardaRuta(string sidRuta, string snombre, string sdescripcion, string shorasalida, string shorallegada)
        {

            try
            {
                int idRuta = sidRuta == "" ? 0 : Convert.ToInt32(sidRuta);
                negRuta negRuta = new negRuta();
                entRuta entRuta = new entRuta();
                entRuta.idRuta = idRuta;
                entRuta.nombre = snombre;
                entRuta.descripcion = sdescripcion;
                entRuta.horaSalida = shorasalida;
                entRuta.horaLlegada = shorallegada;

                string Guardado = idRuta != 0 ? negRuta.ModificaRuta(entRuta) : negRuta.CreaRuta(entRuta);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Ruta", Guardado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Ruta", "");
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }

        /*---------------------------------------TipoPasajero-----------------------------------------------------------*/

        //  [WebMethod]
        //public List<entTipoPasajero> ListaTipoPasajero(/*string sidTipoPasajero*/)
        //{
        //    string jSonEnviar = "";
        //    List<entTipoPasajero> lstTipoPasajero = new List<entTipoPasajero>();
        //   //int idTipoPasajero = sidTipoPasajero == "" ? 0 : Convert.ToInt32(sidTipoPasajero);
        //    try
        //    {

        //        negTipoPasajero negTipoPasajero = new negTipoPasajero();
        //        DataTable dtTipoPasajero = negTipoPasajero.MuestraTipoPasajero();
        //        lstTipoPasajero = (from DataRow dr in dtTipoPasajero.Rows
        //                           select new entTipoPasajero()
        //                           {
        //                               idTipoPasajero = Convert.ToInt32(dr["idTipoPasajero"]),
        //                               nombre = dr["nombre"].ToString()   ,                       
        //                                bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
        //                           }).ToList();

        //        //JSON.Clear();
        //        //JSON.Add("1Error", false);
        //        //JSON.Add("cError", "");
        //        //JSON.Add("LstTipoPasajero", lstTipoPasajero);
        //        //jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
        //    }


        //    catch (Exception ex)
        //    {
        //        //JSON.Clear();
        //        //JSON.Add("1Error", true);
        //        //JSON.Add("cError", ex.Message);
        //        //JSON.Add("LstTipoPasajero", "");



        //    }
        //    return lstTipoPasajero;
        //    //jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
        //    //Context.Response.Clear();
        //    //Context.Response.Write(jSonEnviar);
        //    //Context.Response.Flush();
        //    //Context.Response.End();

        //}

        [WebMethod]
        public void EliminaTipoPasajero(string sidTipoPasajero)
        {
            int idTipoPasajero = Convert.ToInt32(sidTipoPasajero);
            try
            {
                negTipoPasajero negTipoPasajero = new negTipoPasajero();
                string Eliminado = negTipoPasajero.EliminaTipoPasajero(idTipoPasajero);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("TipoPasajero", Eliminado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("TipoPasajero", "");
                throw;
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void ConsultaTipoPasajero(int idTipoPasajero)
        {
            string jSonEnviar = "";
            List<entTipoPasajero> lstTipoPasajero = new List<entTipoPasajero>();
            try
            {
                negTipoPasajero negTipoPasajero = new negTipoPasajero();
                DataTable dtTipoPasajero = negTipoPasajero.ConsultaTipoPasajero(idTipoPasajero);

                lstTipoPasajero = (from DataRow dr in dtTipoPasajero.Rows
                                   select new entTipoPasajero()
                                   {
                                       idTipoPasajero = Convert.ToInt32(dr["idTipoPasajero"]),
                                       nombre = dr["nombre"].ToString()
                                      
                                       // bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                                   }).ToList();
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("sError", "");
                JSON.Add("TipoPasajero", lstTipoPasajero);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("sError", ex.Message);
                JSON.Add("TipoPasajero", "");

            }
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void GuardaTipoPasajero(string sidTipoPasajero, string snombre)
        {

            try
            {
                int idTipoPasajero = sidTipoPasajero == "" ? 0 : Convert.ToInt32(sidTipoPasajero);
                negTipoPasajero negTipoPasajero = new negTipoPasajero();
                entTipoPasajero entTipoPasajero = new entTipoPasajero();
                entTipoPasajero.idTipoPasajero = idTipoPasajero;
                entTipoPasajero.nombre = snombre;
     


                string Guardado = idTipoPasajero != 0 ? negTipoPasajero.ModificaTipoPasajero(entTipoPasajero) : negTipoPasajero.CreaTipoPasajero(entTipoPasajero);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("TipoPasajero", Guardado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("TipoPasajero", "");
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }

        /*---------------------------------------Usuario-----------------------------------------------------------*/
        [WebMethod]
        public void ListaUsuario()
        {
            string jSonEnviar = "";
            List<entUsuario> lstUsuario = new List<entUsuario>();
            try
            {
                negUsuario negUsuario = new negUsuario();
                DataTable dtUsuario = negUsuario.MuestraUsuario();
                lstUsuario = (from DataRow dr in dtUsuario.Rows
                              select new entUsuario()
                              {
                                  idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                  usuario = dr["usuario"].ToString(),
                                  nombre = dr["nombre"].ToString(),
                                  correo = dr["correo"].ToString(),
                                  clave = dr["clave"].ToString(),
                                  // bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                              }).ToList();
                JSON.Clear();
                JSON.Add("1Error", false);
                JSON.Add("cError", "");
                JSON.Add("LstUsuario", lstUsuario);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }

            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("1Error", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("LstUsuario", "");



            }
            jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();

        }

        [WebMethod]
        public void EliminaUsuario(int idUsuario)
        {
            try
            {
                negUsuario negUsuario = new negUsuario();
                string Eliminado = negUsuario.EliminaUsuario(idUsuario);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Usuario", Eliminado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Usuario", "");
                throw;
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void ConsultaUsuario(int idUsuario)
        {
            string jSonEnviar = "";
            List<entUsuario> lstUsuario = new List<entUsuario>();
            try
            {
                negUsuario negUsuario = new negUsuario();
                DataTable dtUsuario = negUsuario.ConsultaUsuario(idUsuario);

                lstUsuario = (from DataRow dr in dtUsuario.Rows
                              select new entUsuario()
                              {
                                  idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                  usuario = dr["usuario"].ToString(),
                                  nombre = dr["nombre"].ToString(),
                                  correo = dr["correo"].ToString(),
                                  clave = dr["clave"].ToString()
                                  // bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                              }).ToList();
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("sError", "");
                JSON.Add("Usuario", lstUsuario);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("sError", ex.Message);
                JSON.Add("Usuario", "");

            }
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void GuardaUsuario(string sidUsuario, string susuario, string snombre, string scorreo, string sclave)
        {

            try
            {
                int idUsuario = sidUsuario == "" ? 0 : Convert.ToInt32(sidUsuario);
                negUsuario negUsuario = new negUsuario();
                entUsuario entUsuario = new entUsuario();
                entUsuario.idUsuario = idUsuario;
                entUsuario.usuario = susuario;
                entUsuario.nombre = snombre;
                entUsuario.correo = scorreo;
                entUsuario.clave = sclave;


                string Guardado = idUsuario != 0 ? negUsuario.ModificaUsuario(entUsuario) : negUsuario.CreaUsuario(entUsuario);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Usuario", Guardado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Usuario", "");
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }

        /*---------------------------------------Vehiculo-----------------------------------------------------------*/

        [WebMethod]
        public void ListaVehiculo()
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
                JSON.Clear();
                JSON.Add("1Error", false);
                JSON.Add("cError", "");
                JSON.Add("LstVehiculo", lstVehiculo);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }

            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("1Error", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("LstVehiculo", "");



            }
            jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();

        }

        [WebMethod]
        public void EliminaVehiculo(int idVehiculo)
        {
            try
            {
                negVehiculo negVehiculo = new negVehiculo();
                string Eliminado = negVehiculo.EliminaVehiculo(idVehiculo);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Vehiculo", Eliminado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Vehiculo", "");
                throw;
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void ConsultaVehiculo(int idVehiculo)
        {
            string jSonEnviar = "";
            List<entVehiculo> lstVehiculo = new List<entVehiculo>();
            try
            {
                negVehiculo negVehiculo = new negVehiculo();
                DataTable dtVehiculo = negVehiculo.ConsultaVehiculo(idVehiculo);

                lstVehiculo = (from DataRow dr in dtVehiculo.Rows
                               select new entVehiculo()
                               {
                                   idVehiculo = Convert.ToInt32(dr["idVehiculo"]),
                                   matricula = dr["apellido"].ToString(),
                                   modelo = dr["modelo"].ToString(),
                                   marca = dr["marca"].ToString(),
                                   capacidad = Convert.ToInt32(dr["capacidad"]),
                                   descripcion = dr["descripcion"].ToString()
                                   // bActivo = Convert.ToBoolean(dr["bActivo"].ToString())
                               }).ToList();
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("sError", "");
                JSON.Add("Vehiculo", lstVehiculo);
                jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("sError", ex.Message);
                JSON.Add("Vehiculo", "");

            }
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
        [WebMethod]
        public void GuardaVehiculo(string sidVehiculo, string smatricula, string smodelo, string smarca, int scapacidad, string sdescripcion)
        {

            try
            {
                int idVehiculo = sidVehiculo == "" ? 0 : Convert.ToInt32(sidVehiculo);
                negVehiculo negVehiculo = new negVehiculo();
                entVehiculo entVehiculo = new entVehiculo();
                entVehiculo.idVehiculo = idVehiculo;
                entVehiculo.matricula = smatricula;
                entVehiculo.modelo = smodelo;
                entVehiculo.marca = smarca;
                entVehiculo.capacidad = scapacidad;
                entVehiculo.descripcion = sdescripcion;
            


                string Guardado = idVehiculo != 0 ? negVehiculo.ModificaVehiculo(entVehiculo) : negVehiculo.CreaVehiculo(entVehiculo);
                JSON.Clear();
                JSON.Add("lError", false);
                JSON.Add("cError", "");
                JSON.Add("Vehiculo", Guardado);
            }
            catch (Exception ex)
            {
                JSON.Clear();
                JSON.Add("lError", true);
                JSON.Add("cError", ex.Message);
                JSON.Add("Vehiculo", "");
            }
            string jSonEnviar = new JavaScriptSerializer().Serialize(JSON);
            Context.Response.Clear();
            Context.Response.Write(jSonEnviar);
            Context.Response.Flush();
            Context.Response.End();
        }
    }
}
