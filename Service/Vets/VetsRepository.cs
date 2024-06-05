using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Data;
using Filtro.Models;
using Microsoft.EntityFrameworkCore;

namespace Filtro.Service.Vets
{
    public class VetsRepository: IVetsRepository
    {
            private readonly BaseContext _context;

            public object Especialidades => throw new NotImplementedException();

            public VetsRepository(BaseContext context)
            {
            _context = context;
            
            }

        
        public async Task<IEnumerable<Vet>> GetAllAsync()
        {
                return await _context.Vets
                .ToListAsync();
        }




    }
}