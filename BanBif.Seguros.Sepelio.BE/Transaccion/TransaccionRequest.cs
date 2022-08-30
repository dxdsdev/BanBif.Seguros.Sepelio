using System.Collections.Generic;

namespace BanBif.Seguros.Sepelio.BE
{
    public class TransaccionRequest
    {
        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Token { get; set; }
        public int CargoTarjeta { get; set;}
        public int CargoDia { get; set; }
        public int CodigoPlan { get; set; }
        public int TerminosCondiciones { get; set; }
        public List<ConyuguesBE> Conyugues { get; set; }
        public List<TercerosBE> Terceros { get; set; }
        public List<ClientesBE> Clientes { get; set; }
    }
}
