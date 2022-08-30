using BanBif.Seguros.Sepelio.BE;
using BanBif.Seguros.Sepelio.BE.Conyugues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Seguros.Sepelio.DA
{
    public class SepelioDA
    {
        #region GLOBALES
        public ObtenerNombreClienteResult ObtenerNombreCliente(ObtenerNombreClienteRequest request)
        {
            using (var db = new panelEntities())
            {
                var cliente = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.CODIGOCLIENTE == request.CodigoCliente).FirstOrDefault();
                var result = new ObtenerNombreClienteResult();

                if (cliente != null)
                {
                    result.NombreCliente = cliente.NOMBRE.ToString();
                    result.Correo = cliente.CORREO.ToString();
                }
                var transaccion = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(p => p.CODIGOCLIENTE == request.CodigoCliente).OrderByDescending(p => p.CODIGOTRANSACCION).FirstOrDefault();
                if (transaccion != null)
                {
                    result.TipoPlan = Convert.ToUInt16(transaccion.CODIGOTIPOPLAN);
                }
                return result;
            }

        }

        public ObtenerDatosConyugueResult ObtenerConyugueCliente(ObtenerNombreClienteRequest request)
        {
            using (var db = new panelEntities())
            {
                var codConyugue = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(p => p.CODIGOCLIENTE == request.CodigoCliente).OrderByDescending(p => p.CODIGOTRANSACCION).FirstOrDefault().CODIGOCONYUGUE;
                var result = new ObtenerDatosConyugueResult();
                var Conyugue = db.tbl_aSEGUROSEPELIO_CONYUGUE.Where(p => p.CODIGOCONYUGUE == codConyugue).FirstOrDefault();
                if (Conyugue != null)
                {
                    result.NombreConyugue = Conyugue.NOMBRE.ToString();
                    result.DocumentoConyugue = Conyugue.DOCUMENTO.ToString();
                }
               
                return result;
            }

        }
        #endregion

        #region PANTALLA LOGIN
        public ObtenerLoginResult ObtenerLogin(ObtenerLoginRequest request)
        {
            using (var db = new panelEntities())
            {
                var cliente = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.DOCUMENTO == request.NumeroDocumento).FirstOrDefault(); //.ToList()
                var result = new ObtenerLoginResult();               

                if (cliente != null)
                {
                    result.CodigoCliente = cliente.CODIGOCLIENTE;
                    result.Nombre = cliente.NOMBRE;
                    result.TieneSeguro = cliente.TIENESEGURO.Value;
                    result.PlanSeguro = string.Empty;                    

                    string[] separada = cliente.CORREO.Split('@');
                    int inicio = 1; //Caracteres al inicio de la cadena que dejamos visibles
                    int final = 3; //Caracteres al final de la cadena que dejamos visibles
                    int longitud;
                    if (separada[0].Length > inicio + final)
                        longitud = separada[0].Length - final - inicio;
                    else
                        longitud = 1;

                    separada[0] = separada[0].Remove(inicio, longitud).Insert(inicio, new string('*', longitud));
                    result.Correo  = String.Join("@", separada);


                    if (result.TieneSeguro)
                    {
                        var planUsuario = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(p => p.CODIGOCLIENTE == result.CodigoCliente).OrderByDescending(p=> p.CODIGOTRANSACCION).FirstOrDefault().CODIGOTIPOPLAN; //.ToList()
                        var atendido = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(p => p.CODIGOCLIENTE == result.CodigoCliente).OrderByDescending(p => p.CODIGOTRANSACCION).FirstOrDefault().ATENTIDO; //.ToList()
                        var plan = db.tbl_aSEGUROSEPELIO_TIPO_PLAN.Where(p => p.CODIGOTIPOPLAN == planUsuario).FirstOrDefault().DESCRIPCIONTIPOPLAN; //.ToList()
                        result.PlanSeguro = plan;
                        result.Atendido=atendido;
                    }
                    else
                    {
                        db.SP_SEGUROSEPELIO_ACTUALIZACONSENTIMIENTO(result.CodigoCliente, request.FlagConsentimiento);
                    }                   
                }

                return result;
            }

        }

        #endregion

        #region TIPO PLAN
        public ListaTipoPlanResult ListaTipoPlan()
        {
            using (panelEntities db = new panelEntities())
            {
                ListaTipoPlanResult result = new ListaTipoPlanResult();
                var listaTipoPlan = db.tbl_aSEGUROSEPELIO_TIPO_PLAN.Where(p => p.ESTADO == 1).ToList();

                var listaResult = new List<TipoPlan>();
                foreach (var item in listaTipoPlan)
                {
                    listaResult.Add(new TipoPlan
                    {
                        CodigoTipoPlan = item.CODIGOTIPOPLAN,
                        Descripcion = item.DESCRIPCIONTIPOPLAN
                    });
                }
                result.TipoPlan = listaResult;
                return result;
            }
        }


        #endregion

        #region BENEFICIOS

        public ObtenerContenidoResult ObtenerContenido(ObtenerContenidoRequest request)
        {
            using (var db = new panelEntities())
            {
                var condicion = db.SEGURIDAD_TERMINOS_CONDICIONES.Where(p => p.APLICACION_ID == request.AplicationId).FirstOrDefault();
                var result = new ObtenerContenidoResult();

                if (condicion != null)
                {
                    result.contenido2 = condicion.CONTENIDO_2;
                }

                return result;
            }

        }


        #endregion

        #region REGISTRO TERCEROS / CONYUGUE
        public ListaCiudadResult ListarCiudad()
        {
            using (panelEntities db = new panelEntities())
            {
                ListaCiudadResult result = new ListaCiudadResult();
                var listaCiudad = db.tbl_aSEGUROSEPELIO_UBIGEO_CIUDAD.Where(p => p.ESTADO == 1).ToList();

                var listaResult = new List<Ciudad>();
                foreach (var item in listaCiudad)
                {
                    listaResult.Add(new Ciudad
                    {
                        CodigoCiudad = item.ID_CIUDAD,
                        Descripcion = item.NOMBRE_CIUDAD
                    });
                }
                result.ListaCiudad = listaResult;
                return result;
            }
        }

        public ListarProvinciaResult ListarProvincia(ListarProvinciaRequest request)
        {
            using (panelEntities db = new panelEntities())
            {
                ListarProvinciaResult result = new ListarProvinciaResult();
                var listaProvincia = db.tbl_aSEGUROSEPELIO_UBIGEO_PROV.Where(p => p.ESTADO == 1 && p.ID_CIUDAD == request.CodigoCiudad).ToList();

                var listaResult = new List<Provincia>();
                foreach (var item in listaProvincia)
                {
                    listaResult.Add(new Provincia
                    {
                        CodigoProvincia = item.ID_PROV,
                        DescripcionProvincia = item.NOMBRE_PROV
                    });
                }
                result.ListarProvincia = listaResult;
                return result;
            }

        }

        public ListarDistritoResult ListarDistrito(ListarDistritoRequest request)
        {
            using (panelEntities db = new panelEntities())
            {
                ListarDistritoResult result = new ListarDistritoResult();
                var listaDistrito = db.tbl_aSEGUROSEPELIO_UBIGEO_DISTRIT.Where(p => p.ESTADO == 1 && p.ID_PROV == request.CodigoProvincia).ToList();

                var listaResult = new List<Distrito>();
                foreach (var item in listaDistrito)
                {
                    listaResult.Add(new Distrito
                    {
                        CodigoDistrito = item.ID_DIST,
                        DescripcionDistrito = item.NOMBRE_DIST
                    });
                }
                result.ListaDistrito = listaResult;
                return result;
            }

        }

        public ListaSexoResult ListarSexo()
        {
            using (panelEntities db = new panelEntities())
            {
                ListaSexoResult result = new ListaSexoResult();
                var listaSexo = db.tbl_aSEGUROSEPELIO_SEXO.Where(p => p.ESTADO == 1).ToList();

                var listaResult = new List<Sexo>();
                foreach (var item in listaSexo)
                {
                    listaResult.Add(new Sexo
                    {
                        CodigoSexo = item.CODIGOSEXO,
                        Descripcion = item.DESCRIPCION
                    });
                }
                result.Sexo = listaResult;
                return result;
            }

        }

        #endregion

        #region TOKEN
        public TokenResponse GuardarToken(TokenRequest request)
        {
            using (var db = new panelEntities())
            {
                var response = new TokenResponse();

                /*DESACTIVAR TOKEN NO VALIDADOS POR DNI*/
                var listaToken = db.tbl_mSEGUROSEPELIO_TOKEN.Where(p => p.DOCUMENTO == request.Documento && p.ESTADO == 1 && p.VALIDADO == false).ToList();

                foreach (var item in listaToken)
                {
                    item.ESTADO = 0;
                }
                db.SaveChanges();

                /*REGISTRAR NUEVO TOKEN*/
                var token = new tbl_mSEGUROSEPELIO_TOKEN
                {
                    DOCUMENTO = request.Documento,
                    TOKEN = request.Token,
                    FECHA = DateTime.Now,
                    VALIDADO = false,
                    ESTADO = 1
                };

                try
                {
                    db.tbl_mSEGUROSEPELIO_TOKEN.Add(token);
                    db.SaveChanges();
                    response.Result = true;

                    return response;
                }
                catch (Exception e)
                {
                    response.Result = false;
                    response.Mensaje = e.InnerException.ToString();
                    return response;
                }
            }
        }

        public TokenResponse ValidarToken(TokenRequest request)
        {
            using (var db = new panelEntities())
            {
                var response = new TokenResponse();
                var validarToken = request.Token;
                var token = db.tbl_mSEGUROSEPELIO_TOKEN.Where(p => p.DOCUMENTO == request.Documento && p.TOKEN == validarToken && p.ESTADO == 1 && p.VALIDADO == false).FirstOrDefault();
                /// TOKEN INVALIDO RETORNA FALSO Y EL MENSAJE
                if (token == null)
                {
                    response.Result = false;
                    response.Mensaje = "El token ingresado no es valido.";
                }
                else
                {
                    response.Result = true;
                    response.Mensaje = "El token ingresado es valido.";
                    token.VALIDADO = true;
                    db.SaveChanges();
                }

               
                return response;
            }
        }


        #endregion

        #region CORREO
        public CorreoDataCliente ObtenerDatosCliente(EnviarRequest request)
        {

            using (var db = new panelEntities())
            {
                var result = new CorreoDataCliente();
                var cliente = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.CODIGOCLIENTE == request.CodigoCliente).FirstOrDefault();
                if (cliente != null)
                {
                    result.Correo = cliente.CORREO;
                    result.Nombre = cliente.NOMBRE;
                    result.Documento = cliente.DOCUMENTO;
                }

                return result;
            }
        }


        #endregion

        #region CLIENTE
        public ListaNroTarjetaResult ListarNroTarjeta(ObtenerNroTarjetaRequest request)
        {
            using (panelEntities db = new panelEntities())
            {
                ListaNroTarjetaResult result = new ListaNroTarjetaResult();
                /*OBTENER DATOS CLIENTE*/
                var cliente = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.CODIGOCLIENTE == request.CodigoCliente).FirstOrDefault();

                var arrCorreo = cliente.CORREO.Split('@');

                result.Nombre = cliente.NOMBRE;
                result.Correo = arrCorreo[0].Substring(0, 1) + "********" + "@" + arrCorreo[1];

                /*OBTENER TARJETAS*/
                var listaNroTarjeta = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.ESTADO == 1 && p.DOCUMENTO == cliente.DOCUMENTO).ToList();

                var listaResult = new List<NroTarjeta>();
                foreach (var item in listaNroTarjeta)
                {

                    listaResult.Add(new NroTarjeta
                    {
                        CodigoCliente = item.CODIGOCLIENTE,
                        NroTarjetaCliente = item.TIPOPRODUCTO == "CREDITO" ? "Tarjeta de crédito: **** **** **** " + item.NROTARJETA : "N° de cuenta: " + item.NUMEROCUENTA
                    });
                }
                result.NroTarjeta = listaResult;
                return result;
            }

        }

        #endregion

        #region TRANSACCION
        public TransaccionResponse GuardarTransaccion(TransaccionRequest request)
        {
            using (var db = new panelEntities())
            {
                var response = new TransaccionResponse();
                var cliente = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.CODIGOCLIENTE == request.CodigoCliente).FirstOrDefault();
                var validarToken = int.Parse(request.Token);
              //  var token = db.tbl_mSEGUROSEPELIO_TOKEN.Where(p => p.DOCUMENTO == cliente.DOCUMENTO && p.TOKEN == validarToken && p.ESTADO == 1 && p.VALIDADO == false).FirstOrDefault();
                var listaTransaccion = new List<tbl_mSEGUROSEPELIO_TRANSACCION>();               

                /// TOKEN INVALIDO RETORNA FALSO Y EL MENSAJE
                //if (token == null)
                //{
                //    response.Result = false;
                //    response.Mensaje = "El token ingresado no es valido.";
                //    return response;
                //}
                //// SI EL TOKEN ES VALIDO HACE TODO LO SIGUIENTE               
                ////ACTUALIZAR EL TOKEN PARA MARCARLO COMO USADO. 
                //token.VALIDADO = true;
                //db.SaveChanges();

                var transaccionCliente = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(x => x.CODIGOCLIENTE == cliente.CODIGOCLIENTE && x.CODIGO_TIPO_TRANSACCION=="A").FirstOrDefault();
                int CODIGOTRANSACCION = 0;

                if (transaccionCliente == null)// Nuevo seguro
                {
                    var dbproceso = db.tbl_mSEGUROSEPELIO_TRANSACCION.OrderByDescending(p => p.CODIGO_PROCESO).FirstOrDefault();
                    var proceso = 0;

                    if (dbproceso == null)
                    {
                        proceso = 1;
                    }
                    else
                    {
                        proceso = dbproceso.CODIGO_PROCESO.Value + 1;
                    }                                     

                  
                    var listaConyugue = new List<tbl_aSEGUROSEPELIO_CONYUGUE>();
                    var seguros = new tbl_mSEGUROSEPELIO_TRANSACCION();

                    seguros.ATENTIDO = 0;
                    seguros.CARGO_TARJETA = request.CargoTarjeta == 1 ? true : false;
                    seguros.CARGO_TARJETA_DIA = request.CargoDia == 1 ? true : false;
                    seguros.TERMINOS_CONDICIONES = request.TerminosCondiciones == 1 ? true : false;
                    seguros.CODIGOCLIENTE = request.CodigoCliente;
                    seguros.NOMBRECLIENTE = request.NombreCliente;
                    seguros.ESTADO = 1;
                    seguros.CODIGO_PROCESO = proceso;
                    seguros.CODIGO_TIPO_TRANSACCION = "A";
                    seguros.FECHA_TRANSACCION = DateTime.Now;
                    seguros.CODIGOTIPOPLAN = request.CodigoPlan;
                    db.tbl_mSEGUROSEPELIO_TRANSACCION.Add(seguros);
                    db.SaveChanges();
                    CODIGOTRANSACCION = seguros.CODIGOTRANSACCION;     
                    
                }
                else //Actualización
                {
                    transaccionCliente.ATENTIDO = 0;
                    transaccionCliente.CARGO_TARJETA = request.CargoTarjeta == 1 ? true : false;
                    transaccionCliente.CARGO_TARJETA_DIA = request.CargoDia == 1 ? true : false;
                    transaccionCliente.TERMINOS_CONDICIONES = request.TerminosCondiciones == 1 ? true : false;
                    transaccionCliente.ESTADO = 1;
                    transaccionCliente.FECHA_TRANSACCION = DateTime.Now;
                    transaccionCliente.CODIGOTIPOPLAN = request.CodigoPlan;
                    db.SaveChanges();

                    CODIGOTRANSACCION = transaccionCliente.CODIGOTRANSACCION;
                }

                /*REGISTRAR NUEVO CONYUGUE*/
                if (request.Conyugues != null)
                {
                    foreach (var conyugue in request.Conyugues)
                    {
                        var cony = new tbl_aSEGUROSEPELIO_CONYUGUE();

                        cony.NOMBRE = conyugue.NombreConyugue;
                        cony.DOCUMENTO = conyugue.DocumentoConyugue;
                        cony.APELLIDO = conyugue.ApellidosConyugue;
                        cony.CORREO = conyugue.CorreoConyugue;
                        cony.CODIGOSEXO = conyugue.CodigoSexo;
                        cony.ID_CIUDAD = conyugue.CodigoCiudad;
                        cony.DIRECCION = conyugue.DireccionConyugue;
                        cony.TELEFONO = conyugue.TelefonoConyugue;
                        cony.ESTADO = 1;
                        cony.FECHAREGISTRO = DateTime.Now;
                        cony.FECHANACIMIENTO = Convert.ToDateTime(conyugue.FechaNacimiento);
                        db.tbl_aSEGUROSEPELIO_CONYUGUE.Add(cony);
                        db.SaveChanges();
                        int CODIGOCONYUGUE = cony.CODIGOCONYUGUE;
                        var transaccion = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(x => x.CODIGOTRANSACCION == CODIGOTRANSACCION).FirstOrDefault();
                        transaccion.CODIGOCONYUGUE = CODIGOCONYUGUE;
                        transaccion.NOMBRECONYUGUE = String.Concat(conyugue.NombreConyugue, ' ', conyugue.ApellidosConyugue);
                        db.SaveChanges();
                    }
                }



                if (request.Terceros != null)
                {
                    var cont = 0;
                    foreach (var Terceros in request.Terceros)
                    {
                        cont = cont + 1;
                        var cony = new tbl_aSEGUROSEPELIO_TERCERO();

                        cony.NOMBRE = Terceros.NombreTercero;
                        cony.DOCUMENTO = Terceros.DocumentoTercero;
                        cony.APELLIDO = Terceros.ApellidosTercero;
                        cony.CORREO = Terceros.CorreoTercero;
                        cony.CODIGOSEXO = Terceros.CodigoSexo;
                        cony.ID_CIUDAD = Terceros.CodigoCiudad;
                        cony.DIRECCION = Terceros.DireccionTercero;
                        cony.TELEFONO = Terceros.TelefonoTercero;
                        cony.ESTADO = 1;
                        cony.FECHAREGISTRO = DateTime.Now;
                        db.tbl_aSEGUROSEPELIO_TERCERO.Add(cony);
                        db.SaveChanges();
                        int CODIGOTERCERO = cony.CODIGOTERCERO;
                        var transaccion = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(x => x.CODIGOTRANSACCION == CODIGOTRANSACCION).FirstOrDefault();
                        if (cont == 1)
                        {
                            transaccion.CODIGOTERCERO = CODIGOTERCERO;
                            transaccion.NOMBRETERCERO = String.Concat(Terceros.NombreTercero, ' ', Terceros.ApellidosTercero);
                            db.SaveChanges();
                        }
                        if (cont == 2)
                        {
                            transaccion.CODIGOTERCERO2 = CODIGOTERCERO;
                            transaccion.NOMBRETERCERO2 = String.Concat(Terceros.NombreTercero, ' ', Terceros.ApellidosTercero);
                            db.SaveChanges();
                        }
                    }
                }

                /*CLIENTES CON MAS DE UNA TARJETA*/
                var tarjetas = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.DOCUMENTO == cliente.DOCUMENTO).ToList();
                foreach (var item in tarjetas)
                {
                    item.TIENESEGURO = true;
                    db.SaveChanges();
                }

                try
                {
                    response.Result = true;

                    /*TRANSACCION RESULT (ENVIO CORREO)*/
                    var transaccionResult = new TransaccionResult
                    {
                        Nombres = cliente.NOMBRE,
                        Correo = cliente.CORREO,
                        CantidadCoyugues = listaTransaccion.Count,
                        CantidadTerceros = request.CodigoPlan,
                        CargoDia = request.CargoDia == 1 ? true : false,
                        TipoProducto = cliente.TIPOPRODUCTO,
                        NroProducto = cliente.TIPOPRODUCTO == "CREDITO" ? cliente.NROTARJETA : cliente.NUMEROCUENTA.Substring(cliente.NUMEROCUENTA.Length - 4, 4)
                    };

                    response.Data = transaccionResult;
                    return response;
                }
                catch (Exception e)
                {
                    response.Result = false;
                    response.Mensaje = e.InnerException.ToString();
                    return response;
                }
            }
         }

        public List<ObtenerTransaccionConyugueResult> ObtenerConyugueTransaccion(ObtenerTransaccionRequest request)
        {
            using (var db = new panelEntities())
            {
                var cliente = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.CODIGOCLIENTE == request.CodigoCliente).FirstOrDefault();
                var listaClientes = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.DOCUMENTO == cliente.DOCUMENTO).ToList();

                //Con el codcli buscar el dni y con el dni buscar todos los clientes asociados
                var response = new List<ObtenerTransaccionConyugueResult>();

                foreach (var itemCliente in listaClientes)
                {
                    var listaMascotas = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(p => p.CODIGOCLIENTE == itemCliente.CODIGOCLIENTE && p.CODIGO_TIPO_TRANSACCION == "A" && p.ATENTIDO == 1 && p.ESTADO == 1).ToList();

                    foreach (var item in listaMascotas)
                    {
                        response.Add(new ObtenerTransaccionConyugueResult
                        {
                            CodigoTransaccion = item.CODIGOTRANSACCION,
                            NombreConyugue = item.NOMBRECONYUGUE,
                            CodigoCiudad = item.tbl_aSEGUROSEPELIO_CONYUGUE.tbl_aSEGUROSEPELIO_UBIGEO_CIUDAD.ID_CIUDAD,
                            CodigoSexo = item.tbl_aSEGUROSEPELIO_CONYUGUE.tbl_aSEGUROSEPELIO_SEXO.CODIGOSEXO,
                            CiudadDesc = item.tbl_aSEGUROSEPELIO_CONYUGUE.tbl_aSEGUROSEPELIO_UBIGEO_CIUDAD.NOMBRE_CIUDAD,
                            SexoDesc = item.tbl_aSEGUROSEPELIO_CONYUGUE.tbl_aSEGUROSEPELIO_SEXO.DESCRIPCION,
                            FechaNacimiento = item.FECHANACIMIENTO.ToString(),
                            NumeroCertificado = item.CERTIFICADO,
                            Estado = item.ESTADO.Value
                        });

                    }
                }


                return response;
            }

        }


        public int ObtenerCantidadTercerosConyugues(ObtenerCantidadConyuguesRequest request)
        {
            using (var db = new panelEntities())
            {
                var contador = 0;
                var conyugue = db.tbl_aSEGUROSEPELIO_CONYUGUE.Where(p => p.CODIGOCONYUGUE == request.CodigoConyugue).FirstOrDefault();
                var tercero = db.tbl_aSEGUROSEPELIO_TERCERO.Where(p => p.CODIGOTERCERO == request.CodigoTercero).FirstOrDefault();
                var listaConyugue = db.tbl_aSEGUROSEPELIO_CONYUGUE.Where(p => p.DOCUMENTO == conyugue.DOCUMENTO).ToList();
                var listaTercero = db.tbl_aSEGUROSEPELIO_TERCERO.Where(p => p.DOCUMENTO == tercero.DOCUMENTO).ToList();
                foreach (var item in listaConyugue)
                {
                    var listaConyugues = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(p => p.CODIGOCONYUGUE == item.CODIGOCONYUGUE && p.CODIGO_TIPO_TRANSACCION == "A" && p.ATENTIDO == 1 && p.ESTADO == 1).ToList();
                    contador += listaConyugues.Count();
                }

                foreach (var item in listaTercero)
                {
                    var listaConyugues = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(p => p.CODIGOTERCERO == item.CODIGOTERCERO && p.CODIGO_TIPO_TRANSACCION == "A" && p.ATENTIDO == 1 && p.ESTADO == 1).ToList();
                    contador += listaConyugues.Count();
                }

                return contador;
            }

        }

        public TransaccionResponse GuardarDesafiliacion(DesafiliacionRequest request)
        {
            using (var db = new panelEntities())
            {
                var response = new TransaccionResponse();     

                try
                {
                    var tarjetas = db.tbl_mSEGUROSEPELIO_CLIENTE.Where(p => p.CODIGOCLIENTE == request.CodigoCliente).ToList();
                    var dataResult = new TransaccionResult();
                    foreach (var item in tarjetas)
                    {
                        
                        dataResult.Nombres = item.NOMBRE;
                        dataResult.Correo = item.CORREO;
                        dataResult.CantidadCoyugues = 0;
                        item.TIENESEGURO = false;
                        db.SaveChanges();
                    }

                    var transaccion = db.tbl_mSEGUROSEPELIO_TRANSACCION.Where(p => p.CODIGOCLIENTE == request.CodigoCliente && p.ESTADO==1).OrderByDescending(p => p.CODIGOTRANSACCION).FirstOrDefault();
                    transaccion.ESTADO = 2;
                    transaccion.ATENTIDO = 0;
                    transaccion.CODIGO_TIPO_TRANSACCION = "D";
                   
                    db.SaveChanges();

                    dataResult.CantidadCoyugues = Convert.ToInt16(transaccion.CODIGOTIPOPLAN);
                    response.Result = true;
                    response.Data = dataResult;

                }
                catch (Exception ex)
                {

                    response.Result = false;
                    response.Mensaje = ex.InnerException.ToString();
                }


                return response;
            }
        }


        #endregion

        #region LOG

        public RegistrarLogResult RegistrarLog(RegistrarLogRequest request)
        {
            using (var db = new panelEntities())
            {
                var result = new RegistrarLogResult();
                var log = new tbl_mSEGUROSEPELIO_LOG();
                try
                {

                    log.CODIGO_UNICO = request.CodigoUnico;
                    log.CODIGOCLIENTE = request.CodigoCliente;
                    log.CODIGO_PASO = request.CodigoPaso;
                    log.DETALLE_LOG = request.DetalleLog;
                    log.FECHA_LOG = DateTime.Now;
                    log.IP_CLIENTE = request.IpCliente;

                    db.tbl_mSEGUROSEPELIO_LOG.Add(log);
                    db.SaveChanges();

                    result.CodigoLog = log.CODIGO_LOG;
                }
                catch (Exception ex)
                {
                    result.CodigoLog = 0;
                }

                return result;
            }
        }

        #endregion

    }
}
