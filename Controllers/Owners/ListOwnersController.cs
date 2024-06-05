using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Service.Owners;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Owners
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListOwnersController : ControllerBase
    {
        private readonly IOwnersRepository _ownersRepository;
        public ListOwnersController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
            {
                var owners = await _ownersRepository.GetAllAsync();
                
                var Listowners = owners.Select(o => new
                {
                    o.id,
                    o.Names,
                    o.LastNames,
                    o.Email,
                    o.Phone,
                    o.Address
                    
                });
                return Ok(Listowners);
            }



    }
}