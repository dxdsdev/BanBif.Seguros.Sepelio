using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Seguros.Sepelio.BE
{
   public class ListarDistritoResponse
    {

        public bool Result { get; set; }
        public ListarDistritoResult Data { get; set; }
        public string Mensaje { get; set; }

    }
}
