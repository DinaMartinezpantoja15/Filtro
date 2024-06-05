using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Data;
using Filtro.Models;
using Filtro.Service.Pets;
using Filtro.Service.Vets;
using Microsoft.EntityFrameworkCore;
using Simulacro2.Services;

namespace Filtro.Service.Quotes
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly BaseContext _context;
       
        private readonly MailerSendService _mailerSendService;
         private readonly IPetsRepository _petsRepository;
          public object Citas => throw new NotImplementedException();

          public QuotesRepository(BaseContext context, MailerSendService mailerSendService, IPetsRepository petsRepository)
        {
            _context = context;
            _mailerSendService = mailerSendService;
            _petsRepository = petsRepository;
        }



        public async Task<Quote> CreateCitaAsync(Quote quote)
        {
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();

            // Obtener el correo electrónico del paciente desde la cita
            var pet = await _petsRepository.GetPacienteByIdAsync(quote.PetId);

            if (pet == null)
            {
                throw new Exception("No se pudo encontrar el paciente asociado a esta cita.");
            }

            // Enviar correo de confirmación
            var from = "MS_zrwFkg@trial-ynrw7gynq8r42k8e.mlsender.net"; // Correo electrónico del remitente
            var fromName = "Dina Martinez"; // Nombre del remitente
            var to = new List<string> { pet.Owner.Email }; // Correo electrónico del paciente p.Owner.Names  Especialidad = m.Especialidad != null ? m.Especialidad.nombre : null,
            var toNames = new List<string> {pet.Name }; // Nombre del paciente
            var subject = "Confirmación de Cita";
            var text = $"Hola {pet.Name}, tu cita ha sido confirmada para el {quote.DATE.ToString("dd/MM/yyyy")}";
            var html = $"<p>Hola {pet.Name},</p><p>Tu cita ha sido confirmada para el <strong>{quote.DATE.ToString("dd/MM/yyyy")}.</p>";

            await _mailerSendService.SendEmailAsync(from, fromName, to, toNames, subject, text, html);

            return quote;
        }

        public async Task<IEnumerable<Quote>> GetAllAsync()
        {
            return await _context.Quotes
             .Include(q => q.Pet)
             .Include(q => q.Vet)
                .ToListAsync();
        }

        public async Task<Quote> GetByIdAsync(int id)
        {
           return await _context.Quotes.FindAsync(id);
        }

        public async Task UpdateAsync(Quote quote)
        {
                         try
        {
            _context.Entry(quote).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Manejo de errores
            throw new Exception("Error al actualizar la mascota.", ex);
        }
        }

        public async Task<Quote> GetByAsyncquote(int id)
            {
                return await _context.Quotes
                    .Include(q => q.Pet)
                    .Include(q => q.Vet)
                    .FirstOrDefaultAsync(c => c.id == id);
            }

     public async Task<IEnumerable<Quote>>GetQuotesDateAsync(DateTime date)
        {

                // Obtener la cantidad de citas programadas para el día especificado
                 return await _context.Quotes
                    .Where(c => c.DATE.Date == date.Date)
                    
                    .ToListAsync();

            


        }

         public async Task<IEnumerable<Quote>> GetquoteVetAsync(int VetId) 
        {
            try
            {
                // Obtener la cantidad de citas del paciente
                return await _context.Quotes
                .Include(o => o.Pet)
                    .Where(c => c.VetId == VetId)
                .ToListAsync(); 

                
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la consulta
                throw new Exception("Error al obtener la cantidad de citas del paciente.", ex);
            }
        }


    }
}