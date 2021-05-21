using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiRest_T.Models;

namespace ApiRest_T.Data
{
    public class ApiRest_TContext : DbContext
    {
        public ApiRest_TContext (DbContextOptions<ApiRest_TContext> options)
            : base(options)
        {
        }

        public DbSet<ApiRest_T.Models.Usuario> Usuario { get; set; }
    }
}
