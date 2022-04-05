using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models
{
    public class ViewClienteNoMayor
    {
        [Key]
        public Int64 id { get; set; }
        public String nombres { get; set; }

        public String apellidos { get; set; }

        public Int64 edad { get; set; }

        public DateTime fecha_compra { get; set; }


    }
}
