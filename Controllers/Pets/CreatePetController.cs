using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.DTO;
using Filtro.Models;
using Filtro.Service.Pets;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreatePetController : ControllerBase
    {

         private readonly IPetsRepository _petRepository;
        public CreatePetController(IPetsRepository petRepository)
        {
            _petRepository = petRepository;
        }
        
         [HttpPost]
          public async Task<IActionResult> CreatePet([FromBody] PetDTO petDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pet = new Pet
            {
                Name = petDTO.Name,
                Specie = petDTO.Specie,
                Race = petDTO.Race,
                DateBirth = petDTO.DateBirth,
                phone = petDTO.phone,
                OwnerId = petDTO.OwnerId
            };

            await _petRepository.AddAsync(pet);

            return Ok("pet creado exitosamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Ha ocurrido un error: {ex.Message}");
        }
        }
        
    }
}