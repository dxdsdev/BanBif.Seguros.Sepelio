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
    public class DesafiliacionController : Controller
    {
        // GET: Desafiliacion
        public ActionResult Index()
        {
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlApp").ToString();
            return View();
        }

    }
}
