using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Models;

namespace Filtro.Service.Owners
{
    public interface IOwnersRepository
    {
        Task AddAsync(Owner owner);
        Task UpdateAsync(Owner owner);
        Task<Owner> GetByIdAsync(int id);
         Task<IEnumerable<Owner>> GetAllAsync();
        
    }
}