using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Matrix.Clases;
using Spectre.Console;

namespace Proyecto_Matrix.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=JONY;Database=ProyectoDB-Matrix;Trusted_Connection=True;");

        }
       public DbSet<Producto> productos { get; set; }
        public DbSet<Persona> personas { get; set; }
    }
}
