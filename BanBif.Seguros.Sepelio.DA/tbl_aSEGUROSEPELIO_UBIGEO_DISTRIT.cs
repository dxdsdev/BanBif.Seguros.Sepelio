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
    
    public partial class tbl_aSEGUROSEPELIO_UBIGEO_DISTRIT
    {
        public int ID_DIST { get; set; }
        public Nullable<int> ID_PROV { get; set; }
        public string UBIGEO_DIST { get; set; }
        public string NOMBRE_DIST { get; set; }
        public Nullable<int> ESTADO { get; set; }
    
        public virtual tbl_aSEGUROSEPELIO_UBIGEO_PROV tbl_aSEGUROSEPELIO_UBIGEO_PROV { get; set; }
    }
}
