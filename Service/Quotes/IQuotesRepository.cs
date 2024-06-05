using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Models;

namespace Filtro.Service.Quotes
{
    public interface IQuotesRepository
    {
        Task<Quote> CreateCitaAsync(Quote quote);
         Task<IEnumerable<Quote>> GetAllAsync();
         Task<Quote> GetByIdAsync(int id);
         Task UpdateAsync(Quote quote);
         Task<Quote> GetByAsyncquote(int id);

         Task<IEnumerable<Quote>> GetQuotesDateAsync(DateTime date);
          Task<IEnumerable<Quote>>GetquoteVetAsync(int VetId);
          
         

    }
}