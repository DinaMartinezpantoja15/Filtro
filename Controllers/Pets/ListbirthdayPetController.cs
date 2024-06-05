using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Service.Pets;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListbirthdayPetController : ControllerBase
    {
        
        private readonly IPetsRepository _petRepository;
        public ListbirthdayPetController(IPetsRepository petRepository)
        {
            _petRepository = petRepository;
        }

        
        [HttpGet]
        public async Task<IActionResult> ListbirthdayPet(int OwnerId, DateTime DateBirth)
        {
            var citas = await _petRepository.GetListbirthdayPeteAsync(OwnerId, DateBirth);
            if (citas == null || !citas.Any())
            {
                return NotFound("No se encontraron fecha cumpleaños especificada.");
            }

            return Ok(citas);
        }

    }
}