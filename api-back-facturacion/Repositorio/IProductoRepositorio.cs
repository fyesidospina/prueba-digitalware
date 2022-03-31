using api_back_facturacion.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Repositorio
{
    public interface IProductoRepositorio
    {
        Task<List<ProductoDto>> GetProducto();

        Task<ProductoDto> GetProductoById(Int64 id);

        Task<ProductoDto> CreateUpdate(ProductoDto productoDto);

        Task<bool> DeleteProducto(Int64 id);
    }
}
