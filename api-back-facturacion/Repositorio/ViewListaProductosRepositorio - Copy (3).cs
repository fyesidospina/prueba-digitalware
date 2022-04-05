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
    public class ViewClienteNoMayorRepositorio : IViewClienteNoMayorRepositorio
    {
        private readonly ApplicationDbContext _dbCont;
        private IMapper _mapper;

        public ViewClienteNoMayorRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _dbCont = db;
            _mapper = mapper;
        }
   
        public async Task<List<ViewClienteNoMayorDto>> GetViewClienteNoMayor()
        {
            List<ViewClienteNoMayor> factura = await _dbCont.vw_lista_cliente_no_mayor_35.ToListAsync();
            return _mapper.Map<List<ViewClienteNoMayorDto>>(factura);
        }
       
    }
}
