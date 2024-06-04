using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Filtro.Data
{
    public class BaseContext : DbContext
    {
                public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        
    }
}