using BanBif.Seguros.Sepelio.BE;
using BanBif.Seguro.Sepelio.Web.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanBif.Seguros.Sepelio.Web.Controllers
{
    public class BeneficiosController : Controller
    {
        // GET: Beneficios
        public ActionResult Index()
        {
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlApp").ToString();
            /*LISTAR TIPO PLAN*/
            ListaTipoPlanResponse ContenidoResponse = new ListaTipoPlanResponse();
            string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ListaTipoPlan";
            string response = WebApi<TipoPlan>.RequestWebApi(null, strURL);
            ContenidoResponse = JsonConvert.DeserializeObject<ListaTipoPlanResponse>(response);
            ViewBag.TipoPlan = ContenidoResponse.Data;

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

        public ActionResult ObtenerContenido(ObtenerContenidoRequest request)
        {
            ObtenerContenidoResponse contenidoResponse = new ObtenerContenidoResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ObtenerContenido";
                string response = WebApi<ObtenerContenidoRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ObtenerContenidoResponse>(response);
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

    }
}