using BanbBif.Seguros.Sepelio.App.Util;
using BanBif.Seguros.Sepelio.BE;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace BanbBif.Seguros.Sepelio.App.Controllers
{
    public class EligeCuentaController : Controller
    {
        // GET: EligeCuenta
        public ActionResult Index()
        {
            ViewBag.URL =   ConfigurationManager.AppSettings.Get("UrlApp").ToString();
            return View();
        }
        public ActionResult ObtenerTarjetas(ObtenerNroTarjetaRequest request)
        {
            ListaNroTarjetaResponse contenidoResponse = new ListaNroTarjetaResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ListarNroTarjeta";
                string response = WebApi<ObtenerNroTarjetaRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ListaNroTarjetaResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }
            return Json(contenidoResponse);
        }

        public ActionResult RegistrarSolicitud(TransaccionRequest request)
        {
            var transaccionResponse = new TransaccionResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/GuardarTransaccion";
                string response = WebApi<TransaccionRequest>.RequestWebApi(request, strURL);
                transaccionResponse = JsonConvert.DeserializeObject<TransaccionResponse>(response);
            }
            catch (Exception ex)
            {
                transaccionResponse.Result = false;
            }
            return Json(transaccionResponse);
        }

    }
}