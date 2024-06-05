using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Service.Quotes;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Filtro.Controllers.Quotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListQuotesController : ControllerBase
    {
        
        private readonly IQuotesRepository _quotesRepository;
        public ListQuotesController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuotes()
            {
                var owners = await _quotesRepository.GetAllAsync();
                
                var Listowners = owners.Select(q => new
                {
                    q.id,
                    q.DATE,
                    q.Description,
                    
                    pet = q.Pet != null ? q.Pet.Name : null,
                    vet = q.Vet != null ? q.Vet.Name : null,  
                });
                return Ok(Listowners);
            }

    }
}