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
    public class ViewListaProductosRepositorio : IViewListaProductosRepositorio
    {
        private readonly ApplicationDbContext _dbCont;
        private IMapper _mapper;

        public ViewListaProductosRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _dbCont = db;
            _mapper = mapper;
        }
   
        public async Task<List<ViewListaProductosDto>> GetViewListaProductos()
        {
            List<ViewListaProductos> factura = await _dbCont.vw_lista_precios_productos.ToListAsync();
            return _mapper.Map<List<ViewListaProductosDto>>(factura);
        }
       
    }
}
