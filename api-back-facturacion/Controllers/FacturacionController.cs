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
    public class FacturacionController : ControllerBase
    {

        private readonly IFacturacionRepositorio _facturacionRepositorio;
        private readonly IInventarioRepositorio _inventarioRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        protected ResponseDto _response;

        public FacturacionController(IFacturacionRepositorio facturacionRepositorio, IInventarioRepositorio inventarioRepositorio,
                                  IClienteRepositorio clienteRepositorio)
        {
            _facturacionRepositorio = facturacionRepositorio;
            _inventarioRepositorio = inventarioRepositorio;
            _clienteRepositorio = clienteRepositorio;
            
            _response = new ResponseDto();
        }


        // GET: api/<FacturacionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facturacion>>> GetFacturacion()
        {
            try
            {
                var lista = await _facturacionRepositorio.GetFacturacion();

                _response.Result = lista;
                _response.DisplayMessage = "Lista Facturacion";
                _response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET api/<FacturacionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facturacion>> GetFacturacionById(Int64 id)
        {
            var factura = await _facturacionRepositorio.GetFacturacionById(id);
            if (factura == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "No existe Factura";
                return NotFound(_response);
            }

            _response.Result = factura;
            _response.DisplayMessage = "Informacion Factura";
            return Ok(_response);
        }

        // POST api/<FacturacionController>
        [HttpPost]
        public async Task<ActionResult<Facturacion>> PostFacturacion([FromBody] FacturacionDto value)
        {
            try
            {
                var factura = await _facturacionRepositorio.CreateUpdate(value);
                _response.Result = factura;
                return CreatedAtAction("GetFacturacion", new { id = factura.id }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error Creando el registro Reserva";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // PUT api/<FacturacionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturacion(Int64 id, [FromBody] FacturacionDto value)
        {
            try
            {
                FacturacionDto modelUpd = await _facturacionRepositorio.CreateUpdate(value);
                _response.Result = modelUpd;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error Actualizando el registro";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);

            }
        }

        // DELETE api/<FacturacionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturacion(Int64 id)
        {
            try
            {
                bool delete = await _facturacionRepositorio.DeleteFacturacion(id);
                if (delete)
                {
                    _response.Result = delete;
                    _response.DisplayMessage = "Registro Eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error Eliminando el registro";
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
