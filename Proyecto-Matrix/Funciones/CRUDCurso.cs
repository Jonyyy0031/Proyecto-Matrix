using Microsoft.EntityFrameworkCore;
using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class CRUDCurso
    {
        public void CrearProducto()
        {
            using (var _context = new ApplicationDbContext())
            {
                //TODO ADENTRO SE AGREGA
                Producto producto = new Producto();
                producto.nombre = AnsiConsole.Ask<string>("Ingresa el Nombre del Producto");
                producto.descripcion = AnsiConsole.Ask<string>("Ingresa la descripcion breve del producto");
                producto.precio = AnsiConsole.Ask<decimal>("Ingresa El precio del producto");
                producto.cantidad_inventario = AnsiConsole.Ask<int>("¿Cuantos hay en el inventario");

                _context.productos.Add(producto);
                _context.SaveChanges();
            }
        }
        public void VisualizarProductos()
        {
            using (var _context = new ApplicationDbContext())
            {
                var producto = _context.productos.ToList();
                foreach (var item in producto)
                {
                    AnsiConsole.MarkupLine("ID : " + item.Id);
                    AnsiConsole.MarkupLine("Nombre del Producto "+item.nombre);
                    AnsiConsole.MarkupLine("Descripcion del producto " + item.descripcion);
                    AnsiConsole.MarkupLine("Precio del producto " + item.precio);
                    AnsiConsole.MarkupLine("Cantidad disponible" + item.cantidad_inventario);
                }
            }
        }
    }
}
