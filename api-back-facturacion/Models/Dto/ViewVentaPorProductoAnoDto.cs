using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models
{
    public class ViewVentaPorProductoAnoDto
    {
        
        
        public String nombre_producto { get; set; }
                
        public Int64 Cant_Vendido { get; set; }

        public Int64 valor_und { get; set; }

        public Int64 votal_venta { get; set; }

        public DateTime fecha_compra { get; set; }

    }
}
