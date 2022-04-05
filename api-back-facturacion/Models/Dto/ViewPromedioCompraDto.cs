using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models
{
    public class ViewPromedioCompraDto
    {
        
        public Int64 id_cliente { get; set; }

        public String nombres { get; set; }

        public String apellidos { get; set; }

        //Foreign key for id_inventario
        public Int64 media_dias { get; set; }

        public DateTime fecha_proxima_compra { get; set; }


    }
}
