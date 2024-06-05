using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Service.Quotes;
using Filtro.Service.Vets;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Vets
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListQuoteVetController : ControllerBase
    {
        
        private readonly IQuotesRepository _quotesRepository;
        public ListQuoteVetController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpGet]
        public async Task<IActionResult>Citasveterinario(int id)
        {
            try
            {
                var quoteVet = await _quotesRepository.GetquoteVetAsync(id);

                var Listowners = quoteVet.Select(o => new
                {
                    o.id,
                    o.DATE,
                    o.Description,
                    Nombrepet = o.Pet != null ? o.Pet.Name : null,

                    
                });
                return Ok(quoteVet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}