using api_back_facturacion.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Repositorio
{
    public interface IFacturacionRepositorio
    {
        Task<List<FacturacionDto>> GetFacturacion();

        Task<FacturacionDto> GetFacturacionById(Int64 id);

        Task<FacturacionDto> CreateUpdate(FacturacionDto facturacionDto);

        Task<bool> DeleteFacturacion(Int64 id);
    }
}
