using BanBif.Seguro.Sepelio.Web.Util;
using BanBif.Seguros.Sepelio.BE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanBif.Seguros.Sepelio.Web.Controllers
{
    public class SolicitarAfiliacionController : Controller
    {
        // GET: SolicitarAfiliacion
        public ActionResult Index()
        {
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlApp").ToString();
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

        public ActionResult ObtenerNombreCliente(ObtenerNombreClienteRequest request)
        {
            ObtenerNombreClienteResponse contenidoResponse = new ObtenerNombreClienteResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ObtenerNombreCliente";
                string response = WebApi<ObtenerNombreClienteRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ObtenerNombreClienteResponse>(response);
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