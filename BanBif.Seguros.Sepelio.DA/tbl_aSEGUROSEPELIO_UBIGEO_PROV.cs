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
    
    public partial class tbl_aSEGUROSEPELIO_UBIGEO_PROV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_aSEGUROSEPELIO_UBIGEO_PROV()
        {
            this.tbl_aSEGUROSEPELIO_UBIGEO_DISTRIT = new HashSet<tbl_aSEGUROSEPELIO_UBIGEO_DISTRIT>();
        }
    
        public int ID_PROV { get; set; }
        public Nullable<int> ID_CIUDAD { get; set; }
        public string UBIGEO_PROV { get; set; }
        public string NOMBRE_PROV { get; set; }
        public Nullable<int> ESTADO { get; set; }
    
        public virtual tbl_aSEGUROSEPELIO_UBIGEO_CIUDAD tbl_aSEGUROSEPELIO_UBIGEO_CIUDAD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_aSEGUROSEPELIO_UBIGEO_DISTRIT> tbl_aSEGUROSEPELIO_UBIGEO_DISTRIT { get; set; }
    }
}
