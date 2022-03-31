using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models.Dto
{
    public class ClienteDto
    {
        public Int64 id { get; set; }
        
        public string nombres { get; set; }
        
        public string apellidos { get; set; }
        
        public Int64 edad { get; set; }
    }
}
