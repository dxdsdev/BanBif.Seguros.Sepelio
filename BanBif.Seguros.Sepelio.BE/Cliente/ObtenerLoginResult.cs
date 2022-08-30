
namespace BanBif.Seguros.Sepelio.BE
{
   public class ObtenerLoginResult
    {
        public int CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public bool TieneSeguro { get; set; }
        public string PlanSeguro { get; set; }
        public string Correo { get; set; }
        public int? Atendido { get; set; }
    }
}
