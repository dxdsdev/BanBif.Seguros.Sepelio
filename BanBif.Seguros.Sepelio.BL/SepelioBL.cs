using BanBif.Seguros.Sepelio.BE;
using BanBif.Seguros.Sepelio.BE.Conyugues;
using BanBif.Seguros.Sepelio.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Seguros.Sepelio.BL
{
    public class SepelioBL
    {
        #region GLOBALES
        public ObtenerNombreClienteResponse ObtenerNombreCliente(ObtenerNombreClienteRequest request)
        {

            var response = new ObtenerNombreClienteResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var data = sepelioDA.ObtenerNombreCliente(request);
                response.Data = data;

                if (data.NombreCliente.ToString() != null)
                {
                    response.Result = true;
                }
                else
                {
                    response.Mensaje = "Datos No encontrados";
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.InnerException.ToString();
            }

            return response;
        }

        public ObtenerDatosConyugueResponse ObtenerConyugueCliente(ObtenerNombreClienteRequest request)
        {
            var response = new ObtenerDatosConyugueResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var data = sepelioDA.ObtenerConyugueCliente(request);
                response.Data = data;

                if (data.NombreConyugue.ToString() != null)
                {
                    response.Result = true;
                }
                else
                {
                    response.Mensaje = "Datos No encontrados";
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.InnerException.ToString();
            }

            return response;
        }
        #endregion

        #region PANTALLA LOGIN

        public ObtenerLoginResponse ObtenerLogin(ObtenerLoginRequest request)
        {

            var response = new ObtenerLoginResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var data = sepelioDA.ObtenerLogin(request);


                if (data.CodigoCliente > 0)
                {
                    response.Data = data;
                    response.Result = true;
                    response.Mensaje = "Documento Verificado";
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "Este seguro es válido para clientes BanBif, verifica que los datos ingresados sean correctos. Te redireccionamos para que puedas ingresar tus datos y un asesor se comunique contigo.";
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.InnerException.ToString();
            }

            return response;
        }

        #endregion

        #region TIPO PLAN
        public ListaTipoPlanResponse ListaTipoPlan()
        {
            var response = new ListaTipoPlanResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var resultado = sepelioDA.ListaTipoPlan();
                if (resultado.TipoPlan.Count > 0)
                {
                    response.Result = true;
                    response.Data = resultado;
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }



        #endregion

        #region BENEFICIOS
        public ObtenerContenidoResponse ObtenerContenido(ObtenerContenidoRequest request)
        {

            var response = new ObtenerContenidoResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var data = sepelioDA.ObtenerContenido(request);
                response.Data = data;

                if (data.contenido2 != "")
                {
                    response.Result = true;
                }
                else
                {
                    response.Mensaje = "Codigo no encontrado";
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.InnerException.ToString();
            }

            return response;
        }
        #endregion

        #region REGISTRO TERCEROS / CONYUGUE
        public ListaCiudadResponse ListaCiudad()
        {
            var response = new ListaCiudadResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var resultado = sepelioDA.ListarCiudad();
                if (resultado.ListaCiudad.Count > 0)
                {
                    response.Result = true;
                    response.Data = resultado;
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }

        public ListarProvinciaResponse ListarProvincia(ListarProvinciaRequest request)
        {
            var response = new ListarProvinciaResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var resultado = sepelioDA.ListarProvincia(request);
                if (resultado.ListarProvincia.Count > 0)
                {
                    response.Result = true;
                    response.Data = resultado;
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }

        public ListarDistritoResponse ListarDistrito(ListarDistritoRequest request)
        {
            var response = new ListarDistritoResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var resultado = sepelioDA.ListarDistrito(request);
                if (resultado.ListaDistrito.Count > 0)
                {
                    response.Result = true;
                    response.Data = resultado;
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }


        public ListaSexoResponse ListarSexo()
        {
            var response = new ListaSexoResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var resultado = sepelioDA.ListarSexo();
                if (resultado.Sexo.Count > 0)
                {
                    response.Result = true;
                    response.Data = resultado;
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }


        #endregion

        #region CORREOS
        public CorreoResponse EnviarToken(EnviarRequest request)
        {
            /*OBTENER DATA CLIENTE*/
            var sepelioDA = new SepelioDA();
            var BlComun = new ComunBL();
            var Cliente = sepelioDA.ObtenerDatosCliente(request);

            Random random = new Random();
            string Codigo = random.Next(1000, 9999).ToString();

            var correoAsunto = request.Tipo == "A" ? "Código de verificación de afiliación Microseguro Sepelio" : "Código de verificación de desafiliación Microseguro Sepelio";

            var CorreoRequest = new CorreoRequest
            {
                From = "BanBif Seguros <BANBIFSEGUROS@banbif.com.pe>",
                To = Cliente.Correo,
                Asunto = correoAsunto,
                Mensaje = MensajeToken(Codigo, Cliente.Nombre, request.Tipo)
            };

            var RespuestaCorreo = BlComun.EnviarCorreo(CorreoRequest);
            if (RespuestaCorreo.Enviado == true)
            {
                var Token = new TokenRequest();
                Token.Documento = Cliente.Documento;
                Token.Token = int.Parse(Codigo);
                sepelioDA.GuardarToken(Token);
            }

            return RespuestaCorreo;
        }

        public TokenResponse ValidarToken(TokenRequest request)
        {
            var sepelioDA = new SepelioDA();
            var data = sepelioDA.ValidarToken(request);
            return data;
        }

        static string MensajeToken(string codigoValidacion, string nombreCliente, string tipo)
        {
            var strHTML = "";
            strHTML += "    <br><br>      <table bgcolor = '#e5e5e5' border = '0' cellpadding = '0' cellspacing = '0' style = 'border-collapse: collapse;font-family:arial;text-align: center;color: #515050;font-size: 16px;' width = '100%' >";
            strHTML += "                     <tr>";
            strHTML += "                         <td>";
            strHTML += "                           <table bgcolor = '#FFFFFF' border = '0' cellpadding = '0' cellspacing = '0' style = 'border-collapse: collapse;font-family:arial;text-align: center; font-size: 16px;width: 640px;' align = 'center' >";
            strHTML += "                                   <tr>";
            strHTML += "                                     <td align='center' valign='middle' style='border:none'><span style ='font-size:28px; font-family:arial;'><strong>";
            strHTML += "¡HOLA!, " + nombreCliente + "</strong></span></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='15'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td width='570' style='font-size: 11px; text-align: justify; color:#303030; padding-left: 30px;' >";
            if (tipo == "A")
            {
                strHTML += "Ingresa el siguiente código para confirmar tu solicitud de afiliación: " + codigoValidacion + ".";
            }
            else
            {
                strHTML += "Ingresa el siguiente código para confirmar tu solicitud de desafiliación: " + codigoValidacion + ".";
            }
            strHTML += "<br><br>";
            strHTML += "Para garantizar la seguridad de tu correo electrónico, no respondas a este mensaje.";
            strHTML += "<br><br>";
            strHTML += "Atentamente,";
            strHTML += "<br><br>";
            strHTML += "Tu banco,";
            strHTML += "<br><br>";
            strHTML += "BANBIF";
            strHTML += "<br>";
            strHTML += "</span></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='25'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr width='640'>";
            strHTML += "<td width='640'>";
            strHTML += "<img src='http://csbanbif.embluemail.com.s3.amazonaws.com/diciembre-030119-TC-Experiencia/6.png' width='640' border='0' style='display:block' >";
            strHTML += "</td>";
            strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td width='640'>";
            //strHTML += "<table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='640' style='border-collapse: collapse;font-family:arial' >";
            //strHTML += "<tr>";
            //strHTML += "<td width='35'>";
            //strHTML += "</td>";
            //strHTML += "<td width='570'>";
            //strHTML += "<table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='570' style='border-collapse: collapse;font-family:arial'>";
            //strHTML += "<tr>";
            //strHTML += "<td width='570' style='font-size: 11px; text-align: justify; color:#303030;' >";
            //strHTML += "<br>";
            //strHTML += "<p>El contenido de este mensaje es a título parcial y no es un folleto informativo. Prevalecen las definiciones de cada cobertura que se especifican en la póliza del Microseguro de Sepelio N° 420022607 contratada por CHUBB PERU. En caso de consultas, reclamos y/o siniestros llamar a la Central de Atención al Cliente de Chubb Perú al 417-5000 (Lima), escribe a atencion . seguros @ chubb . com , ingresa a la página web www . chubb . com . pe y/o visita la oficina ubicada en Calle Amador Merino Reyna N° 267 Oficina 402, San Isidro. Aplican exclusiones detalladas en la póliza. El plazo para la atención de consultas y/o reclamos es de 30 días contando desde la presentación del reclamo y/o consulta, sin que ello implique caducidad de su derecho. Para mayor información puedes ingresar a la página web www . BanBif . com . pe y/o www . Chubb. com / pe. Este seguro ofrecido por CHUBB PERU S.A. puede ser adquirido en las oficinas de BanBif. BanBif no se responsabiliza legalmente por la disponibilidad, idoneidad, calidad, condiciones, entrega, exclusiones, daño o perjuicio respecto a los seguros ofrecidos por CHUBB. La presente información es parcial y no constituye las condiciones de la Póliza, prevaleciendo los términos del contrato suscrito ante CHUBB y el adquirente del seguro. BanBif interviene en calidad de comercializador del Microseguro de Sepelio de CHUBB, conforme al Reglamento de Comercialización de Productos de Seguros Res. SBS N° 1121-2017, Ley Complementaria a la Ley de Protección al Consumidor en Materia de Servicios Financieros Ley N°28587 y sus normas modificatorias, así como el Reglamento de Gestión de Conducta de Mercado del Sistema Financiero aprobado por Res. SBS N°3274-2017 y sus modificatorias.</p>";
            //strHTML += "<br>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "<td width='35'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td>";
            //strHTML += "<table style='border: 0' align='center' width='100%' cellpadding='0' cellspacing='0' border='0' >";
            //strHTML += "<tbody>";
            //strHTML += "<tr >";
            //strHTML += "<td width='40'></td>";
            //strHTML += "<td width='550'>";
            //strHTML += "<table style='border: 0' align='center' width='100%' cellpadding='0' cellspacing='0' border='0' >";
            //strHTML += "<tbody>";
            //strHTML += "<tr>";
            //strHTML += "<td width='199' ></td>";
            //strHTML += "<td width='260' align='justify'><span style='color:#000000;font-size:10px;text-align:justify;font-family:arial;font-weight:bold;display:block'></span></td>";
            //strHTML += "<td width='90'><img src='https://ci4.googleusercontent.com/proxy/VnLNbt5DieoNSZDOvMi-kILz52bs8gecrKzcbReMoBa6CpsA9em4hbVvr1xrOrbPRzIjtHS8a7Vjq-SD5ghWUoK8DcpfFp_auYa8omThgNLOOtPKli129-T4hno=s0-d-e1-ft#http://i.embluejet.com/ImagenesMoxie/4569/images/Campana_seguros/ds-b.jpg' style = 'border:none' class='CToWUd'></td>";
            //strHTML += "</tr>";
            //strHTML += "</tbody>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "<td width='50'></td>";
            //strHTML += "</tr>";
            //strHTML += "</tbody>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td width='640' height='10'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr width='640'>";
            //strHTML += "<td width='640'>";
            //strHTML += "<img src='http://csbanbif.embluemail.com.s3.amazonaws.com/diciembre-030119-TC-Experiencia/6.png' width='640' border='0' style='display:block'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td width='640' height='10'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            strHTML += "</table>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";

            return strHTML;
        }
        #endregion

        #region DATOS CLIENTE
        public ListaNroTarjetaResponse ListarNroTarjeta(ObtenerNroTarjetaRequest request)
        {
            var response = new ListaNroTarjetaResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var resultado = sepelioDA.ListarNroTarjeta(request);
                if (resultado.NroTarjeta.Count > 0)
                {
                    response.Result = true;
                    response.Data = resultado;
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }
        #endregion

        #region TRANSACCION
        public TransaccionResponse GuardarTransaccion(TransaccionRequest request)
        {
            var sepelioDA = new SepelioDA();
            var Transaccion = sepelioDA.GuardarTransaccion(request);

            if (Transaccion.Result)
            {
                /*ENVIO CORREO*/
                var BlComun = new ComunBL();
                var CorreoRequest = new CorreoRequest
                {
                    From = "BanBif Seguros <BANBIFSEGUROS@banbif.com.pe>",
                    To = Transaccion.Data.Correo,
                    Bcc = "BANCASEGUROS@banbif.com.pe",
                    Asunto = "Recepción de solicitud de afiliación Microseguro de Sepelio",
                    Mensaje = MensajeAfiliacion(Transaccion.Data)
                };

                BlComun.EnviarCorreo(CorreoRequest);
            }
            Transaccion.Data = null;

            return Transaccion;
        }

        string MensajeAfiliacion(TransaccionResult solicitud) {

            var strHTML = "";
            strHTML += " <!DOCTYPE html>";
            strHTML += "<html lang='en'>";
            strHTML += "<head>";
            strHTML += "<meta charset='UTF-8'>";
            strHTML += "<title></title>";
            strHTML += "<style type='text/css'>";
            strHTML += "body {";
            strHTML += "margin: 0;";
            strHTML += "padding: 0;";
            strHTML += "background-color: #f5f4f5;";
            strHTML += "}";
            strHTML += "td {";
            strHTML += "padding: 0;";
            strHTML += "}";
            strHTML += "</style>";
            strHTML += "</head>";

            strHTML += "<body>";
            strHTML += "<div style='background-color: #f5f4f5;text-align: center;'>";
  strHTML += "<table style='border: 0;' bgcolor='#ffffff' align='center' width='640' cellpadding='0' cellspacing='0' border='0'>";
    strHTML += "<tr>";
            strHTML += "<td width='100%' style='border: none;'><img src='https://www.reinventabanbif.pe/SimuladorDPL/content/mail/header.png' alt='' style='border: none;max-width: 100%;width: 100%;display: block'></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td width='100%' style='border: none;'><img src='https://www.reinventabanbif.pe/SimuladorDPL/content/mail/banner.png' alt='' style='border: none;max-width: 100%;width: 100%;display: block'></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='30' style='line-height: 30px'>&nbsp;</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td align='center' style='border: none;'><span style='font-size: 26px;font-family: arial;color: #4d4d4d'>  "+ solicitud.Nombres + " ,</span></td>";
    strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='20' style='line-height: 20px'>&nbsp;</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td align='center' style='border: none;'><table cellpadding='0' cellspacing='0' border='0' width='80%'>";
            strHTML += "<tr>";
            strHTML += "<td align='center'><span style='font-size: 18px;font-family: arial;color: #606060'>Tu seguridad es <strong>muy importante</strong> para nosotros</span></td>";

         strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td height='20' style='line-height: 20px'>&nbsp;</td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td bgcolor='#ffffff'><table style='border: 0;' align='center' width='450' cellpadding='0' cellspacing='0' border='0'>";

         strHTML += "<tr>";

            strHTML += "<td valign='middle' style='background: #eef8ff; padding: 0; border-radius: 5px;'><table align='center' width='420' cellpadding='0' cellspacing='0' border='0'>";

               strHTML += "<tr>";

            strHTML += "<td height='20' ></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td align='center' style=''><table cellpadding='0' cellspacing='0' border='0' width='420'>";

            strHTML += "<tr>";

            strHTML += "<td width='20' ></td>";

            strHTML += "<td valign='midlle' width='' align='center'><img src='https://www.reinventabanbif.pe/SimuladorDPL/content/mail/icon.png' alt='' style='display: block;'></td>";

            strHTML += "<td width='20' ></td>";

            strHTML += "<td align='left' style=''><span style='font-family: Helvetica, Arial, 'sans-serif'; font-size: 17px; color: #24a3fc'>Te comentamos que tu<strong> Seguro de Sepelio</strong> de <strong></strong> fue afiliado con &eacute; xito. </span></td>";
 
                         strHTML += "<td width='20' ></td>";

            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td height='20' ></td>";

            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td height='10' style='line-height: 10px'>&nbsp;</td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td align='center' style='border: none;'><table cellpadding='0' cellspacing='0' border='0' width='70%'>";

            strHTML += "<tr>";

            strHTML += "<td align='center'><span style='font-size: 13px;font-family: arial;color: #606060'>Fecha de Afiliaci&oacute; n: DD-MM-AAAA </span></td>";
  
            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td height='40' style='line-height: 40px'>&nbsp;</td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td align='center' style='border: none;'><table cellpadding='0' cellspacing='0' border='0' width='70%'>";

            strHTML += "<tr>";

            strHTML += "<td align='center'><span style='font-size: 16px;font-family: arial;color: #20a6ff'><strong>Valor del plan del seguro: S/ 9.5 al mes</strong> </span></td>";
 
           strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td height='10' style='line-height: 10px'>&nbsp;</td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td align='center' style='border: none;' ><table cellpadding='0' cellspacing='0' border='0' width='70%'>";

            strHTML += "<tr>";

            strHTML += "<td align='center'><span style='font-size: 14px;font-family: arial;color: #606060'>Xxxxx Xxxxx en donde se cargar&aacute; el valor del plan del seguro: <br>";
               strHTML += "************XXXXX </span></td>";

            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td height='20' style='line-height: 20px'>&nbsp;</td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td align='center' style='border: none;' bgcolor='#f4f4f4'><table cellpadding='0' cellspacing='0' border='0' width='90%'>";
 
           strHTML += "<tr>";

            strHTML += "<td align='left'><br>";

            strHTML += "<span style='font-size: 11px;font-family: arial;color: #000; text-align: justify; line-height: 12px; display: block;'>La aseguradora, proceder&aacute; en enviarte el certificado del Seguro Protecci&oacute; n de Tarjetas Cyber a este correo electr&oacute; nico registrado dentro de los siguientes 5 d&iacute;as h&aacute; biles. <br>";
    
                  strHTML += "<br>";
            strHTML += "El primer cargo del plan del seguro ser&aacute; cobrado en l&iacute; nea el d&iacute; a de hoy.Las fechas de cobro de las primas de tu Seguro Protecci&oacute; n de Tarjetas Cyber, ser&aacute; la correspondiente al d&iacute; a de la afiliaci&oacute; n del seguro contratado y ser&aacute; n cargadas mensualmente. <br>";

            strHTML += "<br>";
            strHTML += "Recuerda que puedes ejercer tu derecho de arrepentimiento para resolver el contrato sin expresi&oacute; n de causa ni penalidad alguna dentro de los 15 d&iacute;as posteriores a la fecha de recepci&oacute; n de la p&oacute; liza y podr&aacute; s hacerlo a trav&eacute; s de los mecanismos de forma, lugar y medios que usaste para la contrataci&oacute; n del seguro.El ejercicio de tu derecho de arrepentimiento procede si no haces uso de las coberturas y/o asistencias.En caso hayas ejercido tu derecho de arrepentimiento luego de haber pagado el total o parte de la prima, la aseguradora proceder&aacute; a la devoluci&oacute; n de esta dentro de los treinta(30) d&iacute;as siguientes. </span><br></td>";

            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td><table style='border: 0;' align='center' width='100%' cellpadding='0' cellspacing='0' border='0'>";

            strHTML += "<tr>";

            strHTML += "<td width='20'></td>";

            strHTML += "<td width='600'><table style='border: 0;' align='center' width='600' cellpadding='0' cellspacing='0' border='0'>";

            strHTML += "<tr>";

            strHTML += "<td width='600'><p style='margin: 30px 0px 0px 0px; border-top: 2px  solid #000000; line-height: 0px;'>&nbsp;</p></td>";
            
                            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "<td width='20'></td>";

            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td><table style='border: 0;' align='center' width='100%' cellpadding='0' cellspacing='0' border='0'>";

            strHTML += "<tr>";

            strHTML += "<td width='20'></td>";

            strHTML += "<td width='600'><table style='border: 0;' align='center' width='100%' cellpadding='0' cellspacing='0' border='0'>";

            strHTML += "<tr>";

            strHTML += "<td width='100' align='left' valign='top'><p style='text-align: justify; margin: 0px, 0px, 0px;'><img src='https://www.reinventabanbif.pe/SimuladorDPL/content/mail/tea.png' alt='' style='border: none;'></p></td>";

            strHTML += "<td width='600' align='justify'><p style='text-align: justify; margin-top: 10px; margin-bottom: 10px; margin-left: 10px;'><span style='color: #6e6e6e;font-size: 11px;text-align: justify;font-family: arial;display:block;'>En caso de consultas, reclamos y/o siniestros llamar a la Central de Atenci&oacute; n al Cliente de Chubb Per&uacute; al 417-5000(Lima), escribe a atencion.seguros @ chubb.com , ingresa a la p&aacute; gina web www.chubb.com.pe y/o visita la oficina ubicada en Calle Amador Merino Reyna N&deg; 267 Oficina 402, San Isidro. Aplican exclusiones detalladas en la p&oacute; liza.El plazo para la atenci&oacute; n de consultas y/o reclamos es de 30 d&iacute;as contando desde la presentaci&oacute; n del reclamo y/o consulta, sin que ello implique caducidad de su derecho. Para mayor informaci&oacute; n puedes ingresar a la p&aacute; gina web www.BaniBf.com.pe y/o www.Chubb.com / pe.Este seguro ofrecido por CHUBB PERU S.A.puede ser adquirido en las oficinas de BanBif. BanBif no se responsabiliza legalmente por la disponibilidad, idoneidad, calidad, condiciones, entrega, exclusiones, daño o perjuicio respecto a los seguros ofrecidos por CHUBB.La presente informaci&oacute; n es parcial y no constituye las condiciones de la P&oacute; liza, prevaleciendo los t&eacute; rminos del contrato suscrito ante CHUBB y el adquirente del seguro.BanBif interviene en calidad de comercializador del Seguro Protecci&oacute; n de Tarjetas Cyber de CHUBB, conforme al Reglamento de Comercializaci&oacute; n de Productos de Seguros Res. SBS N&deg; 1121-2017, Ley Complementaria a la Ley de Protecci&oacute; n al Consumidor en Materia de Servicios Financieros Ley N&deg; 28587 y sus normas modificatorias, as&iacute; como el Reglamento de Gesti&oacute; n de Conducta de Mercado aprobado por Res. SBS N&deg; 3274-2017 y sus modificatorias.Informaci&oacute; n sobre los costos de los productos BanBif, disponible en nuestro tarifario, plataformas de atenci&oacute; n y p&aacute; gina web: www.Banbif.com.pe en el link(Tarifario General). </span></p></td>";
 
            strHTML += "     </tr>";

            strHTML += "</table></td>";

            strHTML += "<td width='20'></td>";

            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td><table style='border: 0;' align='center' width='100%' cellpadding='0' cellspacing='0' border='0'>";

            strHTML += "<tr>";

            strHTML += "<td width='20'></td>";

            strHTML += "<td width='600'><table style='border: 0;' align='center' width='600' cellpadding='0' cellspacing='0' border='0'>";

            strHTML += "<tr>";

            strHTML += "<td width='600'><p style='margin: 10px 0px 10px 0px; border-top: 2px  solid #000000; line-height: 0px;'>&nbsp;</p></td>";
 
                 strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "<td width='20'></td>";

            strHTML += "</tr>";

            strHTML += "</table></td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td height='10' style='line-height: 10px'>&nbsp;</td>";

            strHTML += "</tr>";

            strHTML += "<tr>";

            strHTML += "<td><table style='border: 0;' align='center' width='100%' cellpadding='0' cellspacing='0' border='0'>";

            strHTML += "<tbody>";

            strHTML += "<tr>";

               strHTML += "<td width='20'></td>";

               strHTML += "<td width='600'><table style='border: 0;' align='center' width='100%' cellpadding='0' cellspacing='0' border='0'>";


                   strHTML += "<tbody>";

                     strHTML += "<tr>";

                       strHTML += "<td width='20'>&nbsp;</td>";

                       strHTML += "<td width='600'><table style='border: 0;' align='center' width='100%' cellpadding='0' cellspacing='0' border='0'>";


                           strHTML += "<tbody>";

                             strHTML += "<tr>";

                               strHTML += "<td height='100' style='border: 5px solid #20A3FF; border-radius: 10px'><table cellpadding='0' cellspacing='0' border='0'>";


                                   strHTML += "<tbody>";

                                     strHTML += "<tr>";

                                       strHTML += "<td width='100' align='center' valign='middle'><img src='http://image.correobanbif.com.pe/lib/fe2e15707564057a7d1d77/m/14/d2743938-9bf3-4201-bac9-caca62b00e74.jpg' alt=''></td>";

                                       strHTML += "<td><p style='text-align: justify; display: block; line-height: 13px; margin-top: 15px; margin-bottom: 15px'><span style='color: #8a8a8a;font-size: 11px; text-align: justify; font-family: arial; display: block'><strong style='color: #20A3FF;font-size: 22px;text-align: justify;font-family: arial; font-weight: 800'>HOLA,</strong> BanBif nunca te solicitar&aacute;, por correo electr&oacute; nico, que env&iacute; es o informes tus datos financieros que pudieran vulnerar tu seguridad, como: <strong>claves de acceso, datos de tus tarjetas de d&eacute; bito o cr&eacute; dito(como n&uacute; mero, fecha de vencimiento, CVV), n&uacute; mero de cuentas, etc.</strong> </span></p></td>";

                                            strHTML += "<td width='20'></td>";


                                          strHTML += "</tr>";


                                        strHTML += "</tbody>";


                                      strHTML += "</table></td>";


                                  strHTML += "</tr>";


                                strHTML += "</tbody>";

                              strHTML += "</table></td>";

                            strHTML += "<td width='20'>&nbsp;</td>";


                          strHTML += "</tr>";


                        strHTML += "</tbody>";

                    strHTML += "</table></td>";

                    strHTML += "<td width='20'></td>";


                  strHTML += "</tr>";

                  strHTML += "<tr>";

                    strHTML += "<td height='20' style=''>&nbsp;</td>";


                  strHTML += "</tr>";


                strHTML += "</tbody>";


              strHTML += "</table></td>";


          strHTML += "</tr>";


        strHTML += "</table>";
      strHTML += "</div>";
      strHTML += "</body>";
      strHTML += "</html>";
            return strHTML;
        }


        string MensajeAfiliacion1(TransaccionResult solicitud)
        {
            var strHTML = "";
            strHTML += "    <br><br> <table bgcolor = '#e5e5e5' border = '0' cellpadding = '0' cellspacing = '0' style = 'border-collapse: collapse;font-family:arial;text-align: center;color: #515050;font-size: 16px;' width = '100%' >";
            strHTML += "                     <tr>";
            strHTML += "                         <td>";
            strHTML += "                           <table bgcolor = '#FFFFFF' border = '0' cellpadding = '0' cellspacing = '0' style = 'border-collapse: collapse;font-family:arial;text-align: center; font-size: 16px;width: 640px;' align = 'center' >";
            strHTML += "                                   <tr>";
            strHTML += "                                     <td align='center' valign='middle' style='border:none'><span style ='font-size:28px; font-family:arial;'><strong>";
            strHTML += "¡HOLA! " + solicitud.Nombres + ",</strong></span></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='15'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td width='570' style='font-size: 11px; text-align: justify; color:#303030; padding-left: 30px;' >";
            strHTML += "<br><br>";
            strHTML += "Hemos recibido tu(s) solicitud(es) de afiliación y se encuentra en proceso.";
            strHTML += "<br><br>";
            strHTML += "Tu microseguro Sepelio será afiliado en los próximos 2 días hábiles.";
            strHTML += "<br><br>";
            //if (solicitud.TipoProducto == "CREDITO")
            //{

                if (solicitud.CantidadTerceros ==1) //Plan Titular
                {
                    strHTML += "El monto a cobrar mensualmente será: S/ 4.50 (prima comercial)";
                strHTML += "<br><br>";
                strHTML += "Mediante tu tarjeta de crédito o nro de cuenta: **** **** **** " + solicitud.NroProducto;
            }
                else {

                    strHTML += "El monto a cobrar mensualmente será: S/ 9.00 (prima comercial) mediante tu tarjeta de crédito o nro de cuenta ********" + solicitud.NroProducto;
                strHTML += "<br><br>";
                strHTML += "Mediante tu tarjeta de crédito o nro de cuenta: **** **** **** " + solicitud.NroProducto;
            }

               
            //}
            //else
            //{
            //    strHTML += "El monto a cobrar mensualmente será: S/ 1.50 (0" + solicitud.CantidadTerceros + " seguro(s)) (incluye prima comercial + IGV)";
            //    strHTML += "<br><br>";
            //    strHTML += "Cuenta de ahorros donde se cargará el valor del plan del seguro: **** **** ****" + solicitud.NroProducto;
            //}
            strHTML += "<br><br>";
            strHTML += "Fecha de afiliación: " + DateTime.Now.ToString("dd-MM-yyyy");
            strHTML += "<br><br>";

            strHTML += "El primer cargo del seguro contratado será cobrado en línea el mismo día de la afiliación";
            strHTML += "<br><br>";

            strHTML += "Las fechas de cobro de las primas de tu Microseguro de Sepelio será la correspondiente al día de la afiliación del seguro de manera recurrente.";

            strHTML += "<br><br>";
            strHTML += "Para garantizar la seguridad de tu correo electrónico, no respondas a este mensaje.";
            strHTML += "<br><br>";
            strHTML += "Atentamente,";
            strHTML += "<br><br>";
            strHTML += "Tu banco,";
            strHTML += "<br><br>";
            strHTML += "BANBIF";
            strHTML += "<br>";
            strHTML += "</span></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='25'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr width='640'>";
            strHTML += "<td width='640'>";
            strHTML += "<img src='http://csbanbif.embluemail.com.s3.amazonaws.com/diciembre-030119-TC-Experiencia/6.png' width='640' border='0' style='display:block' >";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td width='640'>";
            strHTML += "<table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='640' style='border-collapse: collapse;font-family:arial' >";
            strHTML += "<tr>";
            strHTML += "<td width='35'>";
            strHTML += "</td>";
            strHTML += "<td width='570'>";
            strHTML += "<table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='570' style='border-collapse: collapse;font-family:arial'>";
            strHTML += "<tr>";
            strHTML += "<td width='570' style='font-size: 11px; text-align: justify; color:#303030;' >";
            strHTML += "<br>";
            strHTML += "<p>El contenido de este mensaje es a título parcial y no es un folleto informativo. Prevalecen las definiciones de cada cobertura que se especifican en la póliza del Microseguro de Sepelio N° 420022607 contratada por CHUBB PERU. En caso de consultas, reclamos y/o siniestros llamar a la Central de Atención al Cliente de Chubb Perú al 417-5000 (Lima), escribe a atencion . seguros @ chubb . com , ingresa a la página web www . chubb . com . pe y/o visita la oficina ubicada en Calle Amador Merino Reyna N° 267 Oficina 402, San Isidro. Aplican exclusiones detalladas en la póliza. El plazo para la atención de consultas y/o reclamos es de 30 días contando desde la presentación del reclamo y/o consulta, sin que ello implique caducidad de su derecho. Para mayor información puedes ingresar a la página web www . BanBif . com . pe y/o www . Chubb. com / pe. Este seguro ofrecido por CHUBB PERU S.A. puede ser adquirido en las oficinas de BanBif. BanBif no se responsabiliza legalmente por la disponibilidad, idoneidad, calidad, condiciones, entrega, exclusiones, daño o perjuicio respecto a los seguros ofrecidos por CHUBB. La presente información es parcial y no constituye las condiciones de la Póliza, prevaleciendo los términos del contrato suscrito ante CHUBB y el adquirente del seguro. BanBif interviene en calidad de comercializador del Microseguro de Sepelio de CHUBB, conforme al Reglamento de Comercialización de Productos de Seguros Res. SBS N° 1121-2017, Ley Complementaria a la Ley de Protección al Consumidor en Materia de Servicios Financieros Ley N°28587 y sus normas modificatorias, así como el Reglamento de Gestión de Conducta de Mercado del Sistema Financiero aprobado por Res. SBS N°3274-2017 y sus modificatorias.</p>";
            strHTML += "<br>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";
            strHTML += "</td>";
            strHTML += "<td width='35'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td>";
            strHTML += "<table style='border: 0' align='center' width='100%' cellpadding='0' cellspacing='0' border='0' >";
            strHTML += "<tbody>";
            strHTML += "<tr >";
            strHTML += "<td width='40'></td>";
            strHTML += "<td width='550'>";
            strHTML += "<table style='border: 0' align='center' width='100%' cellpadding='0' cellspacing='0' border='0' >";
            strHTML += "<tbody>";
            strHTML += "<tr>";
            strHTML += "<td width='199' ></td>";
            strHTML += "<td width='260' align='justify'><span style='color:#000000;font-size:10px;text-align:justify;font-family:arial;font-weight:bold;display:block'></span></td>";
            strHTML += "<td width='90'><img src='https://ci4.googleusercontent.com/proxy/VnLNbt5DieoNSZDOvMi-kILz52bs8gecrKzcbReMoBa6CpsA9em4hbVvr1xrOrbPRzIjtHS8a7Vjq-SD5ghWUoK8DcpfFp_auYa8omThgNLOOtPKli129-T4hno=s0-d-e1-ft#http://i.embluejet.com/ImagenesMoxie/4569/images/Campana_seguros/ds-b.jpg' style = 'border:none' class='CToWUd'></td>";
            strHTML += "</tr>";
            strHTML += "</tbody>";
            strHTML += "</table>";
            strHTML += "</td>";
            strHTML += "<td width='50'></td>";
            strHTML += "</tr>";
            strHTML += "</tbody>";
            strHTML += "</table>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td width='640' height='10'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr width='640'>";
            strHTML += "<td width='640'>";
            strHTML += "<img src='http://csbanbif.embluemail.com.s3.amazonaws.com/diciembre-030119-TC-Experiencia/6.png' width='640' border='0' style='display:block'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td width='640' height='10'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";

            return strHTML;
        }

        public ObtenerTransaccionResponse ObtenerConyugueTransaccion(ObtenerTransaccionRequest request)
        {
            var response = new ObtenerTransaccionResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var Transaccion = sepelioDA.ObtenerConyugueTransaccion(request);
                response.Data = Transaccion;

                if (response.Data != null && response.Data.Count > 0)
                {
                    response.Result = true;
                    response.Mensaje = "Transacción atendida";
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "Transacción no atendida";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }


        public ObtenerCantidadResponse ObtenerCantidadTercerosConyugues(ObtenerCantidadConyuguesRequest request)
        {
            ObtenerCantidadResponse response = new ObtenerCantidadResponse();
            try
            {
                var sepelioDA = new SepelioDA();
                var Transaccion = sepelioDA.ObtenerCantidadTercerosConyugues(request);

                if (Transaccion > 0)
                {
                    response.Result = true;
                    // response.Data.CantidadMascotas = resultado;
                    response.CantidadConyugues = Transaccion;
                    response.CantidadTerceros = Transaccion;
                }
                else
                {
                    response.Result = false;
                    response.CantidadConyugues = 0;
                    response.CantidadTerceros = 0;
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.CantidadConyugues = 0;
                response.CantidadTerceros = 0;
            }
            return response;
        }


        public TransaccionResponse GuardarDesafiliacion(DesafiliacionRequest request)
        {
            var sepelioDA = new SepelioDA();
            var Transaccion = sepelioDA.GuardarDesafiliacion(request);

            if (Transaccion.Result)
            {
                /*ENVIO CORREO*/
                var BlComun = new ComunBL();
                var CorreoRequest = new CorreoRequest
                {
                    From = "BanBif Seguros <BANBIFSEGUROS@banbif.com.pe>",
                    To = Transaccion.Data.Correo,
                    Bcc = "BANCASEGUROS@banbif.com.pe",
                    Asunto = "Recepción de solicitud de desafiliación Microseguro Sepelio",
                    Mensaje = MensajeDesafiliacion(Transaccion.Data)
                };

                BlComun.EnviarCorreo(CorreoRequest);
            }
            Transaccion.Data = null;

            return Transaccion;
        }
        string MensajeDesafiliacion(TransaccionResult solicitud)
        {
            var strHTML = "";
            strHTML += "    <br><br> <table bgcolor = '#e5e5e5' border = '0' cellpadding = '0' cellspacing = '0' style = 'border-collapse: collapse;font-family:arial;text-align: center;color: #515050;font-size: 16px;' width = '100%' >";
            strHTML += "                     <tr>";
            strHTML += "                         <td>";
            strHTML += "                           <table bgcolor = '#FFFFFF' border = '0' cellpadding = '0' cellspacing = '0' style = 'border-collapse: collapse;font-family:arial;text-align: center; font-size: 16px;width: 640px;' align = 'center' >";
            strHTML += "                                   <tr>";
            strHTML += "                                     <td align='center' valign='middle' style='border:none'><span style ='font-size:28px; font-family:arial;'><strong>";
            strHTML += "¡HOLA! " + solicitud.Nombres + ",</strong></span></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='15'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td width='570' style='font-size: 11px; text-align: justify; color:#303030; padding-left: 30px;' >";
            strHTML += "Hemos recibido tu solicitud de desafiliación.";
            strHTML += "<br><br>";
            strHTML += "Tu(s)  microseguro(s) de Sepelio será(n) desafiliado(s) en los próximos 2 días hábiles";
            strHTML += "<br><br>";
            strHTML += "Fecha de Solicitud: " + DateTime.Now.ToString("dd-MM-yyyy");
            strHTML += "<br><br>";
            if (solicitud.CantidadCoyugues <= 1)
            {
                strHTML += "Valor del plan del seguro: S/ 4.5 ";
            }
            else
            {

                strHTML += "Valor del plan del seguro: S/ 9.00" ;
            }
            strHTML += "<br><br>";
            strHTML += "Para garantizar la seguridad de tu correo electrónico, no respondas a este mensaje.";
            strHTML += "<br><br>";
            strHTML += "Atentamente,";
            strHTML += "<br><br>";
            strHTML += "Tu banco,";
            strHTML += "<br><br>";
            strHTML += "BANBIF";
            strHTML += "<br>";
            strHTML += "</span></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='25'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr width='640'>";
            strHTML += "<td width='640'>";
            strHTML += "<img src='http://csbanbif.embluemail.com.s3.amazonaws.com/diciembre-030119-TC-Experiencia/6.png' width='640' border='0' style='display:block' >";
            strHTML += "</td>";
            strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td width='640'>";
            //strHTML += "<table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='640' style='border-collapse: collapse;font-family:arial' >";
            //strHTML += "<tr>";
            //strHTML += "<td width='35'>";
            //strHTML += "</td>";
            //strHTML += "<td width='570'>";
            //strHTML += "<table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='570' style='border-collapse: collapse;font-family:arial'>";
            //strHTML += "<tr>";
            //strHTML += "<td width='570' style='font-size: 11px; text-align: justify; color:#303030;' >";
            //strHTML += "<br>";
            //strHTML += "<p>El contenido de este mensaje es a título parcial y no es un folleto informativo. Prevalecen las definiciones de cada cobertura que se especifican en la póliza del Microseguro de Sepelio N° 420022607 contratada por CHUBB PERU. En caso de consultas, reclamos y/o siniestros llamar a la Central de Atención al Cliente de Chubb Perú al 417-5000 (Lima), escribe a atencion . seguros @ chubb . com , ingresa a la página web www . chubb . com . pe y/o visita la oficina ubicada en Calle Amador Merino Reyna N° 267 Oficina 402, San Isidro. Aplican exclusiones detalladas en la póliza. El plazo para la atención de consultas y/o reclamos es de 30 días contando desde la presentación del reclamo y/o consulta, sin que ello implique caducidad de su derecho. Para mayor información puedes ingresar a la página web www . BanBif . com . pe y/o www . Chubb. com / pe. Este seguro ofrecido por CHUBB PERU S.A. puede ser adquirido en las oficinas de BanBif. BanBif no se responsabiliza legalmente por la disponibilidad, idoneidad, calidad, condiciones, entrega, exclusiones, daño o perjuicio respecto a los seguros ofrecidos por CHUBB. La presente información es parcial y no constituye las condiciones de la Póliza, prevaleciendo los términos del contrato suscrito ante CHUBB y el adquirente del seguro. BanBif interviene en calidad de comercializador del Microseguro de Sepelio de CHUBB, conforme al Reglamento de Comercialización de Productos de Seguros Res. SBS N° 1121-2017, Ley Complementaria a la Ley de Protección al Consumidor en Materia de Servicios Financieros Ley N°28587 y sus normas modificatorias, así como el Reglamento de Gestión de Conducta de Mercado del Sistema Financiero aprobado por Res. SBS N°3274-2017 y sus modificatorias.</p>";
            //strHTML += "<br>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "<td width='35'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td>";
            //strHTML += "<table style='border: 0' align='center' width='100%' cellpadding='0' cellspacing='0' border='0' >";
            //strHTML += "<tbody>";
            //strHTML += "<tr >";
            //strHTML += "<td width='40'></td>";
            //strHTML += "<td width='550'>";
            //strHTML += "<table style='border: 0' align='center' width='100%' cellpadding='0' cellspacing='0' border='0' >";
            //strHTML += "<tbody>";
            //strHTML += "<tr>";
            //strHTML += "<td width='199' ></td>";
            //strHTML += "<td width='260' align='justify'><span style='color:#000000;font-size:10px;text-align:justify;font-family:arial;font-weight:bold;display:block'></span></td>";
            //strHTML += "<td width='90'><img src='https://ci4.googleusercontent.com/proxy/VnLNbt5DieoNSZDOvMi-kILz52bs8gecrKzcbReMoBa6CpsA9em4hbVvr1xrOrbPRzIjtHS8a7Vjq-SD5ghWUoK8DcpfFp_auYa8omThgNLOOtPKli129-T4hno=s0-d-e1-ft#http://i.embluejet.com/ImagenesMoxie/4569/images/Campana_seguros/ds-b.jpg' style = 'border:none' class='CToWUd'></td>";
            //strHTML += "</tr>";
            //strHTML += "</tbody>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "<td width='50'></td>";
            //strHTML += "</tr>";
            //strHTML += "</tbody>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td width='640' height='10'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr width='640'>";
            //strHTML += "<td width='640'>";
            //strHTML += "<img src='http://csbanbif.embluemail.com.s3.amazonaws.com/diciembre-030119-TC-Experiencia/6.png' width='640' border='0' style='display:block'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td width='640' height='10'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            strHTML += "</table>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";

            return strHTML;
        }

        #endregion

        #region LOG
        public RegistrarLogResponse RegistrarLog(RegistrarLogRequest request)
        {
            var DaPetlover = new SepelioDA();
            var response = new RegistrarLogResponse();
            var result = DaPetlover.RegistrarLog(request);

            if (result.CodigoLog > 0)
            {
                response.Result = true;
                response.Data = result;
                response.Mensaje = "Codigo no encontrado";
            }
            else
            {
                response.Mensaje = "Codigo no encontrado";
            }

            return response;
        }

        #endregion
    }
}
