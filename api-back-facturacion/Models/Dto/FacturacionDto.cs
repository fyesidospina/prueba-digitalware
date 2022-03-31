using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models.Dto
{
    public class FacturacionDto
    {
        public Int64 id { get; set; }

        public DateTime fecha_compra { get; set; }

        //Foreign key for id_inventario
        public Int64 id_inventario { get; set; }


        //Foreign key for id_cliente
        public Int64 id_cliente { get; set; }


        public Int64 cantidad { get; set; }


        public string descripcion { get; set; }
    }
}
