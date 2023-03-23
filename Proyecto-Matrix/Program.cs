using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Data.SqlClient;
using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Proyecto_Matrix.Funciones;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Proyecto_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producto producto = new Producto();
            bool salir = false;
            while (salir != true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"
███████╗████████╗ ██████╗  ██████╗██╗  ██╗    ██╗   ██╗██████╗ 
██╔════╝╚══██╔══╝██╔═══██╗██╔════╝██║ ██╔╝    ██║   ██║██╔══██╗
███████╗   ██║   ██║   ██║██║     █████╔╝     ██║   ██║██████╔╝
╚════██║   ██║   ██║   ██║██║     ██╔═██╗     ██║   ██║██╔═══╝ 
███████║   ██║   ╚██████╔╝╚██████╗██║  ██╗    ╚██████╔╝██║     
╚══════╝   ╚═╝    ╚═════╝  ╚═════╝╚═╝  ╚═╝     ╚═════╝ ╚═╝");
                Console.WriteLine("\n");
                var Funcion = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
            .Title("¿Que desea Realizar?")
            .PageSize(10)
            .AddChoices(new[] {
            "Registro de productos", "Visualizacion de inventario", "Actualizacion de inventario",
             "Ventas","Salir"
            }));
                switch (Funcion)
                {
                    case "Registro de productos":
                        CRUDCurso CRUD = new CRUDCurso();
                        CRUD.CrearProducto();
                        AnsiConsole.MarkupLine("Producto agregado con exito");
                        AnsiConsole.MarkupLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "Visualizacion de inventario":
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
                        AnsiConsole.MarkupLine("Presiona una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "Actualizacion de inventario":
                        c
                        break;
                    case "Ventas":

                        break;
                    case "Salir":
                        Console.Clear();
                        AnsiConsole.MarkupLine("¡Hasta Luego!");
                        salir = true;
                        break;
                }
            }
        }
    }
}
