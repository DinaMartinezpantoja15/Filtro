using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filtro.Models;
using Microsoft.EntityFrameworkCore;

namespace Filtro.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Vet> Vets { get; set; }
        
    }
}