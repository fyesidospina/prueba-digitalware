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
    public class ViewProductosExistenciaMinRepositorio : IViewProductosExistenciaMinRepositorio
    {
        private readonly ApplicationDbContext _dbCont;
        private IMapper _mapper;

        public ViewProductosExistenciaMinRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _dbCont = db;
            _mapper = mapper;
        }
   
        public async Task<List<ViewProductosExistenciaMinDto>> GetViewViewProductosExistenciaMin()
        {
            List<ViewProductosExistenciaMin> factura = await _dbCont.vw_lista_producto_existencia_min.ToListAsync();
            return _mapper.Map<List<ViewProductosExistenciaMinDto>>(factura);
        }
       
    }
}
