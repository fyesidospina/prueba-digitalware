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
    public class ViewPromedioCompraController : ControllerBase
    {

        private readonly IViewPromedioCompraRepositorio _vwViewPromedioCompraRepositorio;

        protected ResponseDto _response;

        public ViewPromedioCompraController(IViewPromedioCompraRepositorio vwPromedioCompraRepositorio)
        {
            _vwViewPromedioCompraRepositorio = vwPromedioCompraRepositorio; 

            _response = new ResponseDto();
        }



        // GET: api/<ViewListaProductosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewPromedioCompra>>> GetViewPromedioCompra()
        {
            try
            {
                var lista = await _vwViewPromedioCompraRepositorio.GetViewPromedioCompra();

                _response.Result = lista;
                _response.DisplayMessage = "_vwViewPromedioCompraRepositorio";
                _response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

    }
}
