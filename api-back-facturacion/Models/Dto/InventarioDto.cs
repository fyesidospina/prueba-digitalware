using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models.Dto
{
    public class InventarioDto
    {
        public Int64 id { get; set; }

        //Foreign key for Standard
        public Int64 id_producto { get; set; }

        public Int64 cantidad { get; set; }
        public Int64 valor_und { get; set; }

        public Int64 existencia { get; set; }
    }
}
