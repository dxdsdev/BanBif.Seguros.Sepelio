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
    public class AfiliacionDesafiliacionController : Controller
    {
        // GET: AfiliacionDesafiliacion
        public ActionResult Index()
        {
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlApp").ToString();
            return View();
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

        public ActionResult ObtenerConyugueTransaccion(ObtenerTransaccionRequest request)
        {
            ObtenerTransaccionResponse contenidoResponse = new ObtenerTransaccionResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ObtenerConyugueTransaccion";
                string response = WebApi<ObtenerTransaccionRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ObtenerTransaccionResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }
            return Json(contenidoResponse);
        }

        public ActionResult ObtenerCantidadMascotas(ObtenerTransaccionRequest request)
        {
            ObtenerCantidadResponse contenidoResponse = new ObtenerCantidadResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/PetLover/ObtenerCantidadMascotas";
                string response = WebApi<ObtenerTransaccionRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ObtenerCantidadResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }
            return Json(contenidoResponse);
        }

    }
}