using Microsoft.EntityFrameworkCore;
using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class CRUD_INVENTARIO
    {
        public void CrearProducto()
        {
            using (var _context = new ApplicationDbContext())
            {
                bool salir = false;
                while (salir != true)
                {
                //TODO ADENTRO SE AGREGA
                Producto producto = new Producto();
                producto.nombre = AnsiConsole.Ask<string>("Ingresa el Nombre del Producto");
                producto.descripcion = AnsiConsole.Ask<string>("Ingresa la descripcion breve del producto");
                producto.precio = AnsiConsole.Ask<decimal>("Ingresa El precio del producto");
                producto.cantidad_inventario = AnsiConsole.Ask<int>("¿Cuantos hay en el inventario?");
                _context.productos.Add(producto);
                _context.SaveChanges();

                    AnsiConsole.MarkupLine("Producto agregado con exito");
                    var Seleccion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("¿Desea agregar otro producto?")
                    .PageSize(10)
                    .AddChoices(new[]
                    {
                       "Si","No"
                    }));
                    switch(Seleccion)
                    {
                        case "No":
                            salir = true;
                        break;
                    }
                }
            }
        }
        public void ActualizarInventario(int idEdit)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Producto productoEdit = _context.productos.Find(idEdit);
                Console.WriteLine($"El producto {productoEdit.nombre} con numero de id {productoEdit.Id} ha sido actualizado con exito!");

                _context.productos.Update(productoEdit);
                _context.SaveChanges();
            }
        }
        public void EliminarInventario(int idDelete)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Producto productoDelete = _context.productos.Find(idDelete);
                Console.WriteLine($"El producto {productoDelete.nombre} con numero de id {productoDelete.Id} ha sido eliminado con exito!");

                _context.productos.Remove(productoDelete);
                _context.SaveChanges();
            }
        }
        #region --- Ver Productos funcion obsoleta ----
        /*public void VisualizarProductos()
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
        }*/
        #endregion
        public void Leer()
        {
            AnsiConsole.Status()
            .Start("Espere por favor...", ctx =>
            {
                AnsiConsole.MarkupLine("Cargando Tabla...");
                Thread.Sleep(2000);
                ctx.Status("Espere por favor...");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));
                AnsiConsole.MarkupLine("Organizando Productos...");
                Thread.Sleep(4000);
                AnsiConsole.MarkupLine("Finalizando...");
                Thread.Sleep(3000);
            });
            var table = new Table().LeftAligned();
            table.Border = TableBorder.Rounded;
            table.BorderColor<Table>(color: Color.Green);
            AnsiConsole.Live(table)
            .Start(ctx =>
            {
                ctx.Refresh();
                Thread.Sleep(800);
                table.AddColumn("ID");
                table.AddColumn("Nombre del producto ");
                table.AddColumn("Descripcion del producto");
                table.AddColumn("Precio del producto");
                table.AddColumn("Cantidad disponible");
                using (var _context = new ApplicationDbContext())
                {
                    List<Producto> productos = _context.productos.ToList();
                    foreach (Producto item in productos)
                    {
                        table.AddRow("" + item.Id, "" + item.nombre, "" + item.descripcion, "" + item.precio, "" + item.cantidad_inventario);
                    }

                }
            });
        }
    }
}
