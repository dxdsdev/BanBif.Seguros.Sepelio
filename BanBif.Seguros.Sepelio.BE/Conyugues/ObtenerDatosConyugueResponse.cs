using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Seguros.Sepelio.BE.Conyugues
{
    public class ObtenerDatosConyugueResponse
    {
        public bool Result { get; set; }
        public string Mensaje { get; set; }
        public ObtenerDatosConyugueResult  Data { get; set; }
    }
}
