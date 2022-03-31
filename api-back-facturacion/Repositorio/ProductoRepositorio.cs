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
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly ApplicationDbContext _dbCont;
        private IMapper _mapper;

        public ProductoRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _dbCont = db;
            _mapper = mapper;
        }
        public async Task<ProductoDto> CreateUpdate(ProductoDto hotelDto)
        {
            Producto producto = _mapper.Map<ProductoDto, Producto>(hotelDto);
            if (producto.id > 0)
            {
                _dbCont.TL_Producto.Update(producto);
            }
            else
            {
                await _dbCont.TL_Producto.AddAsync(producto);
            }

            await _dbCont.SaveChangesAsync();
            return _mapper.Map<Producto, ProductoDto>(producto);
        }

        public async Task<bool> DeleteProducto(Int64 id)
        {

            try
            {
                Producto producto = await _dbCont.TL_Producto.FindAsync(id);
                if (producto == null)
                {
                    return false;
                }

                _dbCont.TL_Producto.Remove(producto);
                await _dbCont.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }

        public async Task<List<ProductoDto>> GetProducto()
        {
            List<Producto> producto = await _dbCont.TL_Producto.ToListAsync();
            return _mapper.Map<List<ProductoDto>>(producto);
        }

        public async Task<ProductoDto> GetProductoById(Int64 id)
        {
            Producto producto = await _dbCont.TL_Producto.FindAsync(id);
            return _mapper.Map<ProductoDto>(producto);
        }
    }
}
