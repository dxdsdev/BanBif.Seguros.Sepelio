using BanbBif.Seguros.Sepelio.App.Util;
using BanBif.Seguros.Sepelio.BE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanbBif.Seguros.Sepelio.App.Controllers
{
    public class DesafiliacionGraciasController : Controller
    {
        // GET: DesafiliacionGracias
        public ActionResult Index()
        {
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlApp").ToString();
            return View();
        }
        public ActionResult GuardarDesafiliacion(DesafiliacionRequest request)
        {
            ListaNroTarjetaResponse contenidoResponse = new ListaNroTarjetaResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/GuardarDesafiliacion";
                string response = WebApi<DesafiliacionRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ListaNroTarjetaResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }
            return Json(contenidoResponse);
        }
    }
}
