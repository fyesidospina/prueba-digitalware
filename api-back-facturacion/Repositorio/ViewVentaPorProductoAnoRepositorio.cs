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
    public class ViewVentaPorProductoAnoRepositorio : IViewVentaPorProductoAnoRepositorio
    {
        private readonly ApplicationDbContext _dbCont;
        private IMapper _mapper;

        public ViewVentaPorProductoAnoRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _dbCont = db;
            _mapper = mapper;
        }
   
        public async Task<List<ViewVentaPorProductoAnoDto>> GetViewVentaPorProductoAno()
        {
            List<ViewVentaPorProductoAno> factura = await _dbCont.vw_lista_total_venta_x_producto_x_ano.ToListAsync();
            return _mapper.Map<List<ViewVentaPorProductoAnoDto>>(factura);
        }
       
    }
}
