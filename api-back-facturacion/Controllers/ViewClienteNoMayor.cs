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
    public class ViewClienteNoMayorController : ControllerBase
    {

        private readonly IViewClienteNoMayorRepositorio _vwClienteNoMayorRepositorio;
        
        protected ResponseDto _response;

        public ViewClienteNoMayorController(IViewClienteNoMayorRepositorio vwClienteNoMayorRepositorio)
        {
            
            _vwClienteNoMayorRepositorio = vwClienteNoMayorRepositorio;
            _response = new ResponseDto();
        }




        // GET: api/<ViewListaProductosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewClienteNoMayor>>> GetViewClienteNoMayor()
        {
            try
            {
                var lista = await _vwClienteNoMayorRepositorio.GetViewClienteNoMayor();

                _response.Result = lista;
                _response.DisplayMessage = "_vwClienteNoMayorRepositorio";
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
