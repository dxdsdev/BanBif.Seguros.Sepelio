//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanBif.Seguros.Sepelio.DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_mSEGUROSEPELIO_CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_mSEGUROSEPELIO_CLIENTE()
        {
            this.tbl_mSEGUROSEPELIO_TRANSACCION = new HashSet<tbl_mSEGUROSEPELIO_TRANSACCION>();
        }
    
        public int CODIGOCLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string DOCUMENTO { get; set; }
        public string CORREO { get; set; }
        public string TIPOPRODUCTO { get; set; }
        public string NROTARJETA { get; set; }
        public string NUMEROCUENTA { get; set; }
        public Nullable<bool> TIENESEGURO { get; set; }
        public Nullable<bool> COMPROBACION { get; set; }
        public Nullable<System.DateTime> FECHAREGISTRO { get; set; }
        public Nullable<int> ESTADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_mSEGUROSEPELIO_TRANSACCION> tbl_mSEGUROSEPELIO_TRANSACCION { get; set; }
    }
}
