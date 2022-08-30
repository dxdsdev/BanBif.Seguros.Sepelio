using BanbBif.Seguros.Sepelio.App.Util;
using BanBif.Seguros.Sepelio.BE;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace BanbBif.Seguros.Sepelio.App.Controllers
{
    public class PlanesSeguroController : Controller
    {
        // GET: PlanesSeguro
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
    }
}