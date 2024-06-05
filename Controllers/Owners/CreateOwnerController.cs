using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.DTO;
using Filtro.Models;
using Filtro.Service.Owners;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Owners
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateOwnerController : ControllerBase
    {
        private readonly IOwnersRepository _ownersRepository;
        public CreateOwnerController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }

         [HttpPost]
          public async Task<IActionResult> CreatePet([FromBody] OwnerDTO OwnerDTO)
         {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = new Owner
            {
                Names = OwnerDTO.Names,
                LastNames = OwnerDTO.LastNames,
                Email = OwnerDTO.Email,
                Phone = OwnerDTO.Phone,
                Address = OwnerDTO.Address
            };

            await _ownersRepository.AddAsync(owner);

            return Ok("owner creado exitosamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Ha ocurrido un error: {ex.Message}");
        }
        }


        
    }
}