using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class CRUDCurso
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
                    switch (Seleccion)
                    {
                        case "No":
                            salir = true;
                            break;
                    }
                }
            }
        }
        public void VisualizarProductos()
        {
            using (var _context = new ApplicationDbContext())
            {
                if (_context.productos.Any())
                {
                    AnsiConsole.Status()
                            .Start("Espere por favor...", ctx =>
                            {
                                AnsiConsole.MarkupLine("Cargando Tabla...");
                                Thread.Sleep(1000);
                                ctx.Status("Espere por favor...");
                                ctx.Spinner(Spinner.Known.Aesthetic);
                                ctx.SpinnerStyle(Style.Parse("green"));
                                AnsiConsole.MarkupLine("Organizando Productos...");
                                Thread.Sleep(1500);
                                AnsiConsole.MarkupLine("Finalizando...");
                                Thread.Sleep(2000);
                            });
                    var table = new Table().LeftAligned();
                    table.Border = TableBorder.Minimal;
                    table.BorderColor<Table>(color: Color.Green);
                    AnsiConsole.Live(table)
                        .Start(ctx =>
                        {
                            ctx.Refresh();
                            Thread.Sleep(500);
                            table.AddColumn("ID");
                            table.AddColumn("Nombre del producto ");
                            table.AddColumn("Descripcion del producto");
                            table.AddColumn("Precio del producto");
                            table.AddColumn("Cantidad disponible");
                            using (var _context = new ApplicationDbContext())
                            {
                                var productos = _context.productos.ToList();
                                foreach (Producto item in productos)
                                {
                                    table.AddRow("" + item.Id, "" + item.nombre, "" + item.descripcion, "" + item.precio, "" + item.cantidad_inventario);
                                }
                            }
                        });
                    Console.WriteLine("Presiona una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    AnsiConsole.MarkupLine("No hay productos en el inventario");
                    AnsiConsole.MarkupLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        public void ModificacionProductos()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                if(_context.productos.Any())
                {
                    var Cambio = AnsiConsole.Prompt(
                        new SelectionPrompt<String>()
                        .Title("¿Que desea Realizar?")
                        .PageSize(10)
                        .AddChoices(new[]
                        {
                            "Cambiar Nombre del producto","Cambiar Descripcion del producto","Cambiar Precio del Producto","Cambiar Cantidad Disponible del producto",
                            "Eliminar el producto"
                        }));
                    switch (Cambio)
                    {
                        case "Cambiar Nombre del producto":
                            break;
                        case "Cambiar Descripcion del producto":
                            break;
                        case "Cambiar Precio del Producto":
                            break;
                        case "Cambiar Cantidad Disponible del producto":
                            break;
                        case "Eliminar el producto":
                            break;
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("No hay productos en el inventario");
                    AnsiConsole.MarkupLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}