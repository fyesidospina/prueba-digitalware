using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Models.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }

        public object Result { get; set; }

        public string DisplayMessage { get; set; }

        public List<string> ErrorMessage { get; set; }
    }
}
