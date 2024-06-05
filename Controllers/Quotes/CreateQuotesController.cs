using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.DTO;
using Filtro.Models;
using Filtro.Service.Pets;
using Filtro.Service.Quotes;
using Filtro.Service.Vets;
using Microsoft.AspNetCore.Mvc;
using Simulacro2.Services;

namespace Filtro.Controllers.Quotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateQuotesController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;
        private readonly IPetsRepository _petsRepository;
        private readonly MailerSendService _mailerSendService;

          public CreateQuotesController(IQuotesRepository quotesRepository, IPetsRepository petsRepository, MailerSendService mailerSendService)
        {
            _quotesRepository = quotesRepository;
            _petsRepository = petsRepository;
            _mailerSendService = mailerSendService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCita([FromBody] QuoteDTO quoteDTO)
        {

            try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quote = new Quote
            {
                DATE = quoteDTO.DATE,
                Description = quoteDTO.Description,
                PetId = quoteDTO.PetId,
                VetId = quoteDTO.VetId
            };

            await _quotesRepository.CreateCitaAsync(quote);

            return Ok("cita creada exitosamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Ha ocurrido un error: {ex.Message}");
        }
        }
        
    }
}