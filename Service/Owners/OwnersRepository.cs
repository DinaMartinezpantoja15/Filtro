using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Data;
using Filtro.Models;
using Microsoft.EntityFrameworkCore;

namespace Filtro.Service.Owners
{
    public class OwnersRepository : IOwnersRepository
    {

         private readonly BaseContext _context;

            public object Especialidades => throw new NotImplementedException();

            public OwnersRepository(BaseContext context)
            {
            _context = context;
            
            }

        public async Task AddAsync(Owner owner)
        {
             _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
    }

        public  async Task UpdateAsync(Owner owner)
        {
        try
        {
            _context.Entry(owner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Manejo de errores
            throw new Exception("Error al actualizar el  Dueño.", ex);
        }
          }

        public async Task<Owner> GetByIdAsync(int id)
        {
            return await _context.Owners.FindAsync(id);
        }

        public async  Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _context.Owners
                .ToListAsync();
        }

        
    }
}