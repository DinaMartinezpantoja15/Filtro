using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.DTO;
using Filtro.Service.Owners;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Owners
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateOwnerController : ControllerBase
    {
        
        private readonly IOwnersRepository _ownersRepository;
        public UpdateOwnerController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }

         [HttpPut("{id}")]
            public async Task<IActionResult> UpdateOwner(int id, [FromBody] OwnerDTO OwnerDTO)
            {
                try
                {

                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var owner = await _ownersRepository.GetByIdAsync(id);
                    if (owner == null)
                    {
                        return NotFound("mascota  no encontrado.");
                    }

                    owner.Names = OwnerDTO.Names;
                    owner.LastNames = OwnerDTO.LastNames;
                    owner.Email = OwnerDTO.Email;
                    owner.Phone = OwnerDTO.Phone;
                    owner.Address = OwnerDTO.Address;
                    

                    await _ownersRepository.UpdateAsync(owner);

                    return Ok("El Dueño fue actualizada exitosamente.");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, $"Ha ocurrido un error: {ex.Message}");
                }
            }



    }
}