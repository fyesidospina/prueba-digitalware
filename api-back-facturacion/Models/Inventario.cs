using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models
{
    public class Inventario
    {
        [Key]
        public Int64 id { get; set; }

        //Foreign key for Standard
        public Int64 id_producto { get; set; }
                
        [Required]
        public Int64 cantidad { get; set; }

        [Required]
        public Int64 valor_und { get; set; }

        [Required]
        public Int64 existencia { get; set; }
                      
    }
}
