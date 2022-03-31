using api_back_facturacion.Models.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models
{
    public class Cliente
    {
        [Key]
        public Int64 id { get; set; }

        [Required]
        public string nombres { get; set; }

        [Required]
        public string apellidos { get; set; }

        [Required]
        public Int64 edad { get; set; }

        public static explicit operator Cliente(ClienteDto v)
        {
            throw new NotImplementedException();
        }
    }
}
