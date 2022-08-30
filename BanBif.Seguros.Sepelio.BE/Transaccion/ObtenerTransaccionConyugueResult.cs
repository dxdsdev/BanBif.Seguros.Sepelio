using System;
using System.Collections.Generic;

namespace BanBif.Seguros.Sepelio.BE
{
    public class ObtenerTransaccionConyugueResult : ConyuguesBE
    {
        public int CodigoTransaccion { get; set; }
        public string SexoDesc { get; set; }
        public string CiudadDesc { get; set; }
        public string NumeroCertificado { get; set; }
        public int Estado { get; set; }
    }
}
