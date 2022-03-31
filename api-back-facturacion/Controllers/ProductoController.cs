using api_back_facturacion.Models;
using api_back_facturacion.Models.Dto;
using api_back_facturacion.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_back_reserva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepositorio _productoRepositorio;
        protected ResponseDto _response;

        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProducto()
        {
            try
            {
                var lista = await _productoRepositorio.GetProducto();
                _response.Result = lista;
                _response.DisplayMessage = "Lista Producto";
                _response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductoById(Int64 id)
        {
            try
            {
                var obj = await _productoRepositorio.GetProductoById(id);
                if (obj == null)
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "No existe Producto";
                    return NotFound(_response);
                }

                _response.Result = obj;
                _response.DisplayMessage = "Informacion Producto";

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto([FromBody] ProductoDto value)
        {
            try
            {
                var obj = await _productoRepositorio.CreateUpdate(value);
                _response.Result = obj;
                return CreatedAtAction("GetProducto", new { id = obj.id }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error Creando el registro";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> PutProducto(int id, [FromBody] ProductoDto value)
        {
            try
            {
                var obj = await _productoRepositorio.CreateUpdate(value);
                _response.Result = obj;
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

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                bool delete = await _productoRepositorio.DeleteProducto(id);
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
