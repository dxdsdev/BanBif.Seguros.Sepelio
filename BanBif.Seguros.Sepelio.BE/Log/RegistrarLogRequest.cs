
namespace BanBif.Seguros.Sepelio.BE
{
    public class RegistrarLogRequest
    {
        public string CodigoUnico { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoPaso { get; set; }

        public string DetalleLog { get; set; }
        public string IpCliente { get; set; }
    }
}
