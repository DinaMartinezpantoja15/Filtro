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
    public class ListPetsController : ControllerBase
    {
        private readonly IPetsRepository _petRepository;
        public ListPetsController(IPetsRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpGet]
            public async Task<IActionResult> GetAllMedicos()
            {
                var pets = await _petRepository.GetAllAsync();
                
                var Listpets = pets.Select(p => new
                {
                    p.id,
                    p.Name,
                    p.Specie,
                    p.Race,
                    p.DateBirth,
                    p.phone,
                    Owner = p.Owner != null ? p.Owner.Names : null,
                    
                });
                return Ok(Listpets);
            }


    }
}