using BanBif.Seguros.Sepelio.BE;
using BanBif.Seguros.Sepelio.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BanBif.Seguros.Sepelio.Api.Controllers
{
    public class SepelioApiController : ApiController
    {
        #region GLOBALES

        [Route("api/Sepelio/ObtenerNombreCliente")]
        [HttpPost]
        public IHttpActionResult ObtenerNombreCliente(ObtenerNombreClienteRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.ObtenerNombreCliente(request));
        }

        [Route("api/Sepelio/ObtenerConyugueCliente")]
        [HttpPost]
        public IHttpActionResult ObtenerConyugueCliente(ObtenerNombreClienteRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.ObtenerConyugueCliente(request));
        }
        #endregion

        #region PANTALLA LOGIN
        [Route("api/Sepelio/ObtenerLogin")]
        [HttpPost]
        public IHttpActionResult ObtenerLogin(ObtenerLoginRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.ObtenerLogin(request));
        }
        #endregion

        #region TIPO PLAN
        [Route("api/Sepelio/ListaTipoPlan")]
        [HttpPost]
        public IHttpActionResult ListaTipoPlan()
        {
            var oBL = new SepelioBL();
            return Json(oBL.ListaTipoPlan());
        }
        #endregion

        #region BENEFICIOS

        [Route("api/Sepelio/ObtenerContenido")]
        [HttpPost]
        public IHttpActionResult ObtenerContenido(ObtenerContenidoRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.ObtenerContenido(request));
        }
        #endregion

        #region REGISTRO TERCEROS / CONYUGUE
        [Route("api/Sepelio/ListaCiudad")]
        [HttpPost]
        public IHttpActionResult ListaCiudad()
        {
            var oBL = new SepelioBL();
            return Json(oBL.ListaCiudad());
        }

        [Route("api/Sepelio/ListarProvincia")]
        [HttpPost]
        public IHttpActionResult ListarProvincia(ListarProvinciaRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.ListarProvincia(request));
        }

        [Route("api/Sepelio/ListarDistrito")]
        [HttpPost]
        public IHttpActionResult ListarDistrito(ListarDistritoRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.ListarDistrito(request));
        }

        [Route("api/Sepelio/ListarSexo")]
        [HttpPost]
        public IHttpActionResult ListarSexo()
        {
            var oBL = new SepelioBL();
            return Json(oBL.ListarSexo());
        }

        #endregion

        #region SOLICITAR AFILIACION / DESAFILIACION

        [Route("api/Sepelio/ListarNroTarjeta")]
        [HttpPost]
        public IHttpActionResult ListarNroTarjeta(ObtenerNroTarjetaRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.ListarNroTarjeta(request));
        }
        #endregion

        #region CORREO
        [Route("api/Sepelio/EnviarToken")]
        [HttpPost]
        public IHttpActionResult EnviarToken(EnviarRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.EnviarToken(request));
        }

        [Route("api/Sepelio/ValidarToken")]
        [HttpPost]
        public IHttpActionResult ValidarToken(TokenRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.ValidarToken(request));
        }
        #endregion

        #region TRANSACCION
        [Route("api/Sepelio/GuardarTransaccion")]
        [HttpPost]
        public IHttpActionResult GuardarTransaccion(TransaccionRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.GuardarTransaccion(request));
        }

        [Route("api/Sepelio/GuardarDesafiliacion")]
        [HttpPost]
        public IHttpActionResult GuardarDesafiliacion(DesafiliacionRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.GuardarDesafiliacion(request));
        }


        [Route("api/Sepelio/ObtenerConyugueTransaccion")]
        [HttpPost]
        public IHttpActionResult ObtenerConyugueTransaccion(ObtenerTransaccionRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.ObtenerConyugueTransaccion(request));
        }

        [Route("api/Sepelio/RegistrarLog")]
        [HttpPost]
        public IHttpActionResult RegistrarLog(RegistrarLogRequest request)
        {
            var oBL = new SepelioBL();
            return Json(oBL.RegistrarLog(request));
        }

        #endregion


    }
}
