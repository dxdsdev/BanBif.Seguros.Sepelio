using BanBif.Seguro.Sepelio.Web.Util;
using BanBif.Seguros.Sepelio.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace BanBif.Seguros.Sepelio.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
    }
}