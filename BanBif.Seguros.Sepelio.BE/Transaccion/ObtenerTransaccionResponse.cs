
using System.Collections.Generic;

namespace BanBif.Seguros.Sepelio.BE
{
    public class ObtenerTransaccionResponse
    {
        public bool Result { get; set; }
        public string Mensaje { get; set; }
        public List<ObtenerTransaccionConyugueResult> Data { get; set; }

        

    }
}
