using api_back_facturacion.Models;
using api_back_facturacion.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Repositorio
{
    public interface IViewClienteNoMayorRepositorio
    {
        Task<List<ViewClienteNoMayorDto>> GetViewClienteNoMayor();
        
    }
}
