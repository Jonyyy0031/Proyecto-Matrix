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
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-SD33E52;Database=ProyectoDB-Matrix;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"server=jony;database=proyectodb-matrix;trusted_connection=true;");

        }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        //add-migration nombre
        //update-database
    }
}
