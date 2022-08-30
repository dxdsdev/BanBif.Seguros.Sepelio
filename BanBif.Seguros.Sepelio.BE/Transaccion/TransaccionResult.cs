
namespace BanBif.Seguros.Sepelio.BE
{
    public class TransaccionResult
    {
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string TipoProducto { get; set; }
        public string NroProducto { get; set; }
        public bool CargoDia { get; set; }
        public int CantidadTerceros { get; set; }
        public int CantidadCoyugues { get; set; }

    }
}
