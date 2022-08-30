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
    public class RegistroConyugueController : Controller
    {
        // GET: RegistroConyugue
        public ActionResult Index()
        {
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlApp").ToString();
            /*LISTAR CIUDAD*/
            ListaCiudadResponse ContenidoResponse1 = new ListaCiudadResponse();
            string strURL1 = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ListaCiudad";
            string response1 = WebApi<Ciudad>.RequestWebApi(null, strURL1);
            ContenidoResponse1 = JsonConvert.DeserializeObject<ListaCiudadResponse>(response1);
            ViewBag.Ciudad = ContenidoResponse1.Data;

            /*LISTAR SEXO*/
            ListaSexoResponse ContenidoResponse2 = new ListaSexoResponse();
            string strURL2 = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ListarSexo";
            string response2 = WebApi<Sexo>.RequestWebApi(null, strURL2);
            ContenidoResponse2 = JsonConvert.DeserializeObject<ListaSexoResponse>(response2);
            ViewBag.Sexo = ContenidoResponse2.Data;

            return View();
        }

        public ActionResult ListarProvincia(ListarProvinciaRequest request)
        {
            ListarProvinciaResponse contenidoResponse = new ListarProvinciaResponse();

            try
            {
                ListarProvinciaResult oListarRazaResult = new ListarProvinciaResult();
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ListarProvincia";
                string response = WebApi<ListarProvinciaRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ListarProvinciaResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }
            return Json(contenidoResponse);
        }

        public ActionResult ListarDistrito(ListarDistritoRequest request)
        {
            ListarDistritoResponse contenidoResponse = new ListarDistritoResponse();

            try
            {
                ListarDistritoResult oListarRazaResult = new ListarDistritoResult();
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ListarDistrito";
                string response = WebApi<ListarDistritoRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ListarDistritoResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }
            return Json(contenidoResponse);
        }

        public ActionResult EnviarToken(EnviarRequest request)
        {
            CorreoResponse contenidoResponse = new CorreoResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/EnviarToken";
                string response = WebApi<EnviarRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<CorreoResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Enviado = false;
                contenidoResponse.Resultado = ex.InnerException.ToString();

            }
            return Json(contenidoResponse);
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

            return Json(new { result = true, mensaje = Age + " años y " + Dias + " días." });
        }
    }
}