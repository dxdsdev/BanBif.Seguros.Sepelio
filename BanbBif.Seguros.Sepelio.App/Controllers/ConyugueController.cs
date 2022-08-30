using BanbBif.Seguros.Sepelio.App.Util;
using BanBif.Seguros.Sepelio.BE;
using BanBif.Seguros.Sepelio.BE.Conyugues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanbBif.Seguros.Sepelio.App.Controllers
{
    public class ConyugueController : Controller
    {
        // GET: Conyugue
        public ActionResult Index()
        {
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlApp").ToString();
            return View();
        }

        public ActionResult CalcularEdad(ConyuguesBE conyugue)
        {

            var fechaNacimiento = DateTime.Parse(conyugue.FechaNacimiento);
            var hoy = DateTime.Now;

            if (fechaNacimiento > hoy)
            {
                return Json(new { result = false, mensaje = "La fecha de nacimiento es mayor a la fecha actual." });
            }

            var DiasTotales = (hoy - fechaNacimiento).TotalDays.ToString();
            var Age = int.Parse(DiasTotales.Split('.')[0]) / 365;
            var Dias = int.Parse(DiasTotales.Split('.')[0]) - (Age * 365);

            if (Age < 18)
            {
                return Json(new { result = false, mensaje = "La edad mínima es de 18 años" });
            }

            if (Age >= 49)
            {
                return Json(new { result = false, mensaje = "La edad máxima es de 49 años y 364 días" });
            }

            return Json(new { result = true, mensaje = "OK" });
        }

        public ActionResult ObtenerConyugueCliente(ObtenerNombreClienteRequest request)
        {
            ObtenerDatosConyugueResponse contenidoResponse = new ObtenerDatosConyugueResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ObtenerConyugueCliente";
                string response = WebApi<ObtenerNombreClienteRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ObtenerDatosConyugueResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }
            return Json(contenidoResponse);
        }
        
    }
}
