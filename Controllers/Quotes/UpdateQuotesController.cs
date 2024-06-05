using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.DTO;
using Filtro.Service.Quotes;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Quotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateQuotesController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;
        public UpdateQuotesController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }
        [HttpPut("{id}")]
            public async Task<IActionResult> UpdatePet(int id, [FromBody] QuoteDTO quoteDTO)
            {
                try
                {

                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var pet  = await _quotesRepository.GetByIdAsync(id);
                    if (pet == null)
                    {
                        return NotFound("mascota  no encontrado.");
                    }

                    pet.DATE = quoteDTO.DATE;
                    pet.Description = quoteDTO.Description;
                    pet.PetId = quoteDTO.PetId;
                    pet.VetId = quoteDTO.VetId;
                    

                    await _quotesRepository.UpdateAsync(pet);

                    return Ok("La Cita fue actualizada exitosamente.");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, $"Ha ocurrido un error: {ex.Message}");
                }
            }



    }
}