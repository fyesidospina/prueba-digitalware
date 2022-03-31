using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models.Dto
{
    public class ProductoDto
    {
        public Int64 id { get; set; }

        public string nombre_producto { get; set; }

        public string detalle { get; set; }
    }
}
