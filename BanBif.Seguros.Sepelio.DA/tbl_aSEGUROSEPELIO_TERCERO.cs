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
    
    public partial class tbl_aSEGUROSEPELIO_TERCERO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_aSEGUROSEPELIO_TERCERO()
        {
            this.tbl_mSEGUROSEPELIO_TRANSACCION = new HashSet<tbl_mSEGUROSEPELIO_TRANSACCION>();
        }
    
        public int CODIGOTERCERO { get; set; }
        public string NOMBRE { get; set; }
        public string DOCUMENTO { get; set; }
        public string CORREO { get; set; }
        public Nullable<int> CODIGOSEXO { get; set; }
        public string TELEFONO { get; set; }
        public Nullable<int> ID_CIUDAD { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<System.DateTime> FECHAREGISTRO { get; set; }
        public Nullable<int> ESTADO { get; set; }
        public string APELLIDO { get; set; }
    
        public virtual tbl_aSEGUROSEPELIO_SEXO tbl_aSEGUROSEPELIO_SEXO { get; set; }
        public virtual tbl_aSEGUROSEPELIO_UBIGEO_CIUDAD tbl_aSEGUROSEPELIO_UBIGEO_CIUDAD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_mSEGUROSEPELIO_TRANSACCION> tbl_mSEGUROSEPELIO_TRANSACCION { get; set; }
    }
}
