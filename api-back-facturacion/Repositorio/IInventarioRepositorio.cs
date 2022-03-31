using api_back_facturacion.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Repositorio
{
    public interface IInventarioRepositorio
    {
        Task<List<InventarioDto>> GetInventario();

        Task<InventarioDto> GetInventarioById(Int64 id);

        Task<InventarioDto> CreateUpdate(InventarioDto usuarioDto);

        Task<bool> DeleteInventario(Int64 id);
    }
}
