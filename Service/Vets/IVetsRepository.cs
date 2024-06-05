using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Models;

namespace Filtro.Service.Vets
{
    public interface IVetsRepository
    {
        Task<IEnumerable<Vet>> GetAllAsync();
    }
}