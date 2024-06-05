using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Service.Vets;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Vets
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListVetsController : ControllerBase
    {
        private readonly IVetsRepository _vestsRepository;
        public ListVetsController(IVetsRepository vestsRepository)
        {
            _vestsRepository = vestsRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> ListVets()
        {
            try
            {
                var ListVets = await _vestsRepository.GetAllAsync();
                return Ok(ListVets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los Veterinarios. Detalles: " + ex.Message });
            }
        }




    }
}