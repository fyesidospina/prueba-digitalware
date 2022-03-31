using api_back_facturacion.Models;
using api_back_facturacion.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion.Repositorio
{
    public class FacturacionRepositorio : IFacturacionRepositorio
    {
        private readonly ApplicationDbContext _dbCont;
        private IMapper _mapper;

        public FacturacionRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _dbCont = db;
            _mapper = mapper;
        }
        public async Task<FacturacionDto> CreateUpdate(FacturacionDto facturacionDto)
        {
            Facturacion factura = _mapper.Map<FacturacionDto, Facturacion>(facturacionDto);
            if (factura.id > 0)
            {
                _dbCont.TL_Facturacion.Update(factura);
            }
            else
            {
                await _dbCont.TL_Facturacion.AddAsync(factura);
            }

            await _dbCont.SaveChangesAsync();
            return _mapper.Map<Facturacion, FacturacionDto>(factura);
        }

        public async Task<bool> DeleteFacturacion(Int64 id)
        {
            try
            {
                Facturacion factura = await _dbCont.TL_Facturacion.FindAsync(id);
                if (factura == null)
                {
                    return false;
                }

                _dbCont.TL_Facturacion.Remove(factura);
                await _dbCont.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<FacturacionDto>> GetFacturacion()
        {
            List<Facturacion> factura = await _dbCont.TL_Facturacion.ToListAsync();
            return _mapper.Map<List<FacturacionDto>>(factura);
        }

        public async Task<FacturacionDto> GetFacturacionById(Int64 id)
        {
            Facturacion factura = await _dbCont.TL_Facturacion.FindAsync(id);
            return _mapper.Map<FacturacionDto>(factura);
        }
    }
}
