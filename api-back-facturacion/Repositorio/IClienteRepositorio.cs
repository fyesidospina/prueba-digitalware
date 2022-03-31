using api_back_facturacion.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteDto>> GetCliente();

        Task<ClienteDto> GetClienteById(Int64 id);

        Task<ClienteDto> CreateUpdate(ClienteDto clienteDto);

        Task<bool> DeleteCliente(Int64 id);
    }
}
