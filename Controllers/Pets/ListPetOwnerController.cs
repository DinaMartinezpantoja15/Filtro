using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Models;
using Filtro.Service.Pets;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListPetOwnerController : ControllerBase
    {
         private readonly IPetsRepository _petRepository;
        public ListPetOwnerController(IPetsRepository petRepository)
        {
            _petRepository = petRepository;
        }

       [HttpGet]
        public async Task<IActionResult> GetCantidadCitasPaciente(int id)
        {
            try
            {
                var  OwnerPet = await _petRepository.GetOwnerPetAsync(id);
                return Ok(OwnerPet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}