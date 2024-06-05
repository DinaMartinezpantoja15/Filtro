using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Data;
using Filtro.Models;
using Microsoft.EntityFrameworkCore;

namespace Filtro.Service.Pets
{
    public class PetsRepository : IPetsRepository
    {
        
        private readonly BaseContext _context;

            public object Especialidades => throw new NotImplementedException();

            public PetsRepository(BaseContext context)
            {
            _context = context;
            
            }

        public  async Task AddAsync(Pet pet)
        {
             _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Pet>> GetAllAsync()
        {
             return await _context.Pets
             .Include(p => p.Owner)
                .ToListAsync();
        }

        public  async Task UpdateAsync(Pet pet)
        {
            
             try
        {
            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Manejo de errores
            throw new Exception("Error al actualizar la mascota.", ex);
        }
        }

        public async Task<Pet> GetPacienteByIdAsync(int PetId)
        {
            try
            {
                return await _context.Pets.FirstOrDefaultAsync(p => p.id == PetId);
            }
            catch (Exception ex)
            {
                // Manejo de errores, log, etc.
                throw new Exception("Error al obtener paciente por ID", ex);
            }
        }

        public  async Task<Pet> GetByIdAsync(int id)
        {
            return await _context.Pets.FindAsync(id);
        }



           public async Task<IEnumerable<Pet>> GetOwnerPetAsync(int OwnerId) 
        {
            try
            {
                // Obtener la cantidad de citas del paciente
                return await _context.Pets
                    .Where(c => c.OwnerId == OwnerId)
                .ToListAsync(); 

                
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la consulta
                throw new Exception("Error al obtener la cantidad de citas del paciente.", ex);
            }
        }

        public async Task<IEnumerable<Pet>> GetListbirthdayPeteAsync(int OwnerId, DateTime DateBirth)
        {
            return await _context.Pets
                .Where(c => c.OwnerId == OwnerId && c.DateBirth == DateBirth.Date)
                .ToListAsync();
        }




    }
}