using api_back_facturacion;
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
    public class InventarioRepositorio : IInventarioRepositorio
    {
        private readonly ApplicationDbContext _dbCont;
        private IMapper _mapper;

        public InventarioRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _dbCont = db;
            _mapper = mapper;
        }
        public async Task<InventarioDto> CreateUpdate(InventarioDto inventarioDto)
        {
            Inventario inventario = _mapper.Map<InventarioDto, Inventario>(inventarioDto);
            if (inventario.id > 0)
            {
                _dbCont.TL_Inventario.Update(inventario);
            }
            else
            {
                await _dbCont.TL_Inventario.AddAsync(inventario);
            }

            await _dbCont.SaveChangesAsync();
            return _mapper.Map<Inventario, InventarioDto>(inventario);
        }

        public async Task<bool> DeleteInventario(Int64 id)
        {
            try
            {
                Inventario inventario = await _dbCont.TL_Inventario.FindAsync(id);
                if (inventario == null)
                {
                    return false;
                }
                _dbCont.TL_Inventario.Remove(inventario);
                await _dbCont.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public async Task<List<InventarioDto>> GetInventario()
        {
            List<Inventario> inventario = await _dbCont.TL_Inventario.ToListAsync();
            return _mapper.Map<List<InventarioDto>>(inventario);
        }

        public async Task<InventarioDto> GetInventarioById(Int64 id)
        {
            Inventario inventario = await _dbCont.TL_Inventario.FindAsync(id);
            return _mapper.Map<InventarioDto>(inventario);
        }
    }
}
