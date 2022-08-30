
using System.Collections.Generic;


namespace BanBif.Seguros.Sepelio.BE
{
    public class ListaNroTarjetaResult
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public List<NroTarjeta> NroTarjeta { get; set; }

    }
}
