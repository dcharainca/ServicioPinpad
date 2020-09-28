using HCOMPINPADLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioPinpad
{
    /// <summary>
    /// Descripción breve de svcPinpad
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class svcPinpad : System.Web.Services.WebService
    {
        string pNumeroMasterKey = "123", pMasterKey = "123", pWorkingKey = "";
        int velocidad = 123;
        short puerto;
        Pinpad pinpad = new HCOMPINPADLib.Pinpad();
        [WebMethod]
        public string ActivarLecturaTarjeta()
        {
            string resultado = String.Empty;
            try
            {
                if (pinpad.Connect(Port: puerto, velocidad) == 1)
                {
                    if (pinpad.ReadCardIni() == 1)
                    {
                        resultado = "Ok";
                    }
                }
                resultado = "No se pudo conectar";
            }
            catch (Exception)
            {
                resultado = "Error";
            }
            return resultado;
        }

        [WebMethod]
        public string ObtenerDatosTarjeta()
        {
            string resultado = String.Empty;
            try
            {
                if (pinpad.Connect(Port: puerto, velocidad) == 1)
                {
                    resultado = pinpad.ReadCard();
                }
                resultado = "No se pudo conectar";
            }
            catch (Exception)
            {
                resultado = "Error";
            }
            return resultado;
        }

        [WebMethod]
        public string SolicitarPin(string datoTarjeta)
        {
            string resultado = String.Empty;
            try
            {
                if (pinpad.Connect(Port: puerto, velocidad) == 1)
                {
                    if (pinpad.ReadPinIni(pNumeroMasterKey, pWorkingKey, datoTarjeta) == 1)
                    {
                        resultado = "Ok";
                    }
                }
                resultado = "No se pudo conectar";
            }
            catch (Exception)
            {
                resultado = "Error";
            }
            return resultado;
        }


        [WebMethod]
        public string LeerPin()
        {
            string resultado = String.Empty;
            try
            {
                if (pinpad.Connect(Port: puerto, velocidad) == 1)
                {
                    short lecturaPin;
                    //Se lee el pin ingresado
                    resultado = pinpad.ReadPin(out lecturaPin);
                }
                resultado = "No se pudo conectar";
            }
            catch (Exception)
            {
                resultado = "Error";
            }
            return resultado;
        }





    }
}
