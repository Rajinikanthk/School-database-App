using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_database__App.Models;

namespace School_database__App.Data
{
    public class ClasseDbContext : DbContext
    {
        public ClasseDbContext (DbContextOptions<ClasseDbContext> options)
            : base(options)
        {
        }

        public DbSet<School_database__App.Models.Classe> Classe { get; set; } = default!;
    }
}
