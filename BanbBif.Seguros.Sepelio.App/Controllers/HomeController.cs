
using BanBif.Seguros.Sepelio.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using BanbBif.Seguros.Sepelio.App.Util;

namespace BanbBif.Seguros.Sepelio.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlApp").ToString();
            return View();
        }

        public ActionResult ValidarLogin(ObtenerLoginRequest request)
        {
            ObtenerLoginResponse loginResponse = new ObtenerLoginResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ObtenerLogin";
                string response = WebApi<ObtenerLoginRequest>.RequestWebApi(request, strURL);
                loginResponse = JsonConvert.DeserializeObject<ObtenerLoginResponse>(response);
            }
            catch (Exception ex)
            {
                loginResponse.Result = false;
            }
            return Json(loginResponse);
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
        public ActionResult ValidarToken(TokenRequest request)
        {
            TokenResponse contenidoResponse = new TokenResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/ValidarToken";
                string response = WebApi<TokenRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<TokenResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
                contenidoResponse.Mensaje = ex.InnerException.ToString();

            }
            return Json(contenidoResponse);
        }

        public ActionResult RegistrarLog(RegistrarLogRequest request)
        {
            Session["UID"] = request.CodigoUnico;
            Session["IP"] = request.IpCliente;

            return Json(AddLog(request));
        }

        public RegistrarLogResponse AddLog(RegistrarLogRequest request)
        {

            RegistrarLogResponse logResponse = new RegistrarLogResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["BaseUrlService"] + "api/Sepelio/RegistrarLog";
                string response = WebApi<RegistrarLogRequest>.RequestWebApi(request, strURL);
                logResponse = JsonConvert.DeserializeObject<RegistrarLogResponse>(response);
            }
            catch (Exception ex)
            {
                logResponse.Result = false;
            }
            return logResponse;
        }

    }
}