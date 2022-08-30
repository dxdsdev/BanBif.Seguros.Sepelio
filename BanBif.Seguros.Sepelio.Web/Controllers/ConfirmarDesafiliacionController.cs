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
    public class ConfirmarDesafiliacionController : Controller
    {
        // GET: ConfirmarDesafiliacion
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