using api_back_facturacion.Models;
using api_back_facturacion.Models.Dto;
using api_back_facturacion.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_back_facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepositorio _clienteRepositorio;
        protected ResponseDto _response;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _response = new ResponseDto();
        }


        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            try
            {
                var lista = await _clienteRepositorio.GetCliente();
                _response.Result = lista;
                _response.DisplayMessage = "Lista Clientes";
                _response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(Int64 id)
        {
            var cliente = await _clienteRepositorio.GetClienteById(id);
            if (cliente == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "No existe cliente";
                return NotFound(_response);
            }

            _response.Result = cliente;
            _response.DisplayMessage = "Informacion Cliente";
            return Ok(_response);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] ClienteDto value)
        {
            try
            {
                var cliente = await _clienteRepositorio.CreateUpdate(value);
                _response.Result = cliente;
                return CreatedAtAction("GetCliente", new { id = cliente.id }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error Creando el registro cliente";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(Int64 id, [FromBody] ClienteDto value)
        {
            try
            {
                ClienteDto modelUpd = await _clienteRepositorio.CreateUpdate(value);
                _response.Result = modelUpd;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error Actualizando el registro habitacion";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);

            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Int64 id)
        {
            try
            {
                bool delete = await _clienteRepositorio.DeleteCliente(id);
                if (delete) {
                    _response.Result = delete;
                    _response.DisplayMessage = "Cliente Eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error Eliminando el registro cliente";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
