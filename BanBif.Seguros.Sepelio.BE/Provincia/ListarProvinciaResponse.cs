using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Seguros.Sepelio.BE
{
   public class ListarProvinciaResponse
    {

        public bool Result { get; set; }
        public ListarProvinciaResult Data { get; set; }
        public string Mensaje { get; set; }

    }
}
