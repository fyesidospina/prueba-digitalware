using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models
{
    public class Producto
    {
        [Key]
        public Int64 id { get; set; }

        [Required]
        public string nombre_producto { get; set; }

        [Required]
        public string detalle { get; set; }


    }
}
