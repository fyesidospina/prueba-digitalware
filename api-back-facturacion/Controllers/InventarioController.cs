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
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioRepositorio _inventarioRepositorio;
        protected ResponseDto _response;

        public InventarioController(IInventarioRepositorio inventarioRepositorio)
        {
            _inventarioRepositorio = inventarioRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/<InventarioController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetInventario()
        {
            try
            {
                var lista = await _inventarioRepositorio.GetInventario();
                _response.Result = lista;
                _response.DisplayMessage = "Lista Inventarios";
                _response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET api/<InventarioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> GetInventario(Int64 id)
        {
            try
            {
                var obj = await _inventarioRepositorio.GetInventarioById(id);
                if (obj == null)
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "No existe Inventario";
                    return NotFound(_response);
                }

                _response.Result = obj;
                _response.DisplayMessage = "Informacion Inventario";

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // POST api/<InventarioController>
        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario([FromBody] InventarioDto value)
        {
            try
            {
                var obj = await _inventarioRepositorio.CreateUpdate(value);
                _response.Result = obj;
                _response.IsSuccess = true;
                return CreatedAtAction("GetInventario", new { id = obj.id }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error Creando el Inventario";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // PUT api/<InventarioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Inventario>> PutInventario(Int64 id, [FromBody] InventarioDto value)
        {
            try
            {
                var obj = await _inventarioRepositorio.CreateUpdate(value);
                _response.Result = obj;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error Actualizando...";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE api/<InventarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(Int64 id)
        {
            try
            {
                bool delete = await _inventarioRepositorio.DeleteInventario(id);
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
