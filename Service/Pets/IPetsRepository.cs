using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Models;

namespace Filtro.Service.Pets
{
    public interface IPetsRepository
    {
         Task AddAsync(Pet pet);
         Task<IEnumerable<Pet>> GetAllAsync();
        Task UpdateAsync(Pet pet);
        Task<Pet> GetByIdAsync(int id);
        Task<Pet>GetPacienteByIdAsync(int PetId);
       
         Task<IEnumerable<Pet>>  GetOwnerPetAsync(int OwnerId);
          Task<IEnumerable<Pet>> GetListbirthdayPeteAsync(int OwnerId, DateTime date);
    }
}