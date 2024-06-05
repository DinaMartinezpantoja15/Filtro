using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.DTO;
using Filtro.Service.Pets;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdatePetController : ControllerBase
    {
        private readonly IPetsRepository _petRepository;
        public UpdatePetController(IPetsRepository petRepository)
        {
            _petRepository = petRepository;
        }
         [HttpPut("{id}")]
            public async Task<IActionResult> UpdatePet(int id, [FromBody] PetDTO petDTO)
            {
                try
                {

                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var pet  = await _petRepository.GetByIdAsync(id);
                    if (pet == null)
                    {
                        return NotFound("mascota  no encontrado.");
                    }

                    pet.Name = petDTO.Name;
                    pet.Specie = petDTO.Specie;
                    pet.Race = petDTO.Race;
                    pet.phone = petDTO.phone;
                    pet.OwnerId = petDTO.OwnerId;
                    

                    await _petRepository.UpdateAsync(pet);

                    return Ok("La Mascota fue actualizada exitosamente.");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, $"Ha ocurrido un error: {ex.Message}");
                }
            }



        
    }
}