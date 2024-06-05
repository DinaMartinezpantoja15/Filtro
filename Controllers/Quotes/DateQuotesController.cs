using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Service.Quotes;
using Microsoft.AspNetCore.Mvc;

namespace Filtro.Controllers.Quotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class DateQuotesController : ControllerBase
    {
        
        private readonly IQuotesRepository _quotesRepository;
        public DateQuotesController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCantidadCitasPorDia(DateTime Date)
        {
            try
            {   
                var Citas = await _quotesRepository.GetQuotesDateAsync(Date);
                return Ok(Citas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        
    }
}