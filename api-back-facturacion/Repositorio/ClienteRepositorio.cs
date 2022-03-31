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
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ApplicationDbContext _dbCont;
        private IMapper _mapper;

        public ClienteRepositorio(ApplicationDbContext db,  IMapper mapper) {
            _dbCont = db;
            _mapper = mapper;
        }

        public async Task<ClienteDto> CreateUpdate(ClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<ClienteDto, Cliente>(clienteDto);
            if (cliente.id > 0)
            {
                _dbCont.TL_Cliente.Update(cliente);
            }
            else
            {
                await _dbCont.TL_Cliente.AddAsync(cliente);
            }

            await _dbCont.SaveChangesAsync();
            return _mapper.Map<Cliente, ClienteDto>(cliente);
        }

        public async Task<bool> DeleteCliente(Int64 id)
        {
            try
            {
                Cliente cliente = await _dbCont.TL_Cliente.FindAsync(id);
                if (cliente == null)
                {
                    return false;
                }

                _dbCont.TL_Cliente.Remove(cliente);
                await _dbCont.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ClienteDto>> GetCliente()
        {
            List <Cliente> cliente = await _dbCont.TL_Cliente.ToListAsync();
            return _mapper.Map<List<ClienteDto>>(cliente);

        }

        public async Task<ClienteDto> GetClienteById(Int64 id)
        {
            Cliente cliente = await _dbCont.TL_Cliente.FindAsync(id);
            return _mapper.Map<ClienteDto>(cliente);
        }

    }
}
