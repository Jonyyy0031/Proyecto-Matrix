using System;
using System.Data.Common;
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
                AnsiConsole.Write(
                        new FigletText("STOCK UP")
                            .LeftJustified()
                            .Color(Color.Gold3_1));

                Console.WriteLine("");
                var Funcion = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
            .Title("¿Que desea Realizar?")
            .PageSize(10)
            .MoreChoicesText("Mueve con las flechas de arriba y abajo para seleccionar")
            .AddChoices(new[] {
            "Registro de productos", "Visualizacion de inventario", "Actualizacion de inventario",
             "Ventas","Salir"
            }));
                switch (Funcion)
                {
                    case "Registro de productos":
                        producto.Id += 0;
                        producto.nombre = AnsiConsole.Ask<string>("Nombre del producto");
                        producto.precio = AnsiConsole.Ask<decimal>("del producto");
                        producto.cantidad_inventario = AnsiConsole.Ask<int>(" del producto");
                        producto.descripcion = AnsiConsole.Ask<string>(" del producto");
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
                                table.AddRow(""+producto.Id,""+producto.nombre,""+producto.descripcion,""+producto.precio,""+producto.cantidad_inventario);

                            });
                        AnsiConsole.MarkupLine("Presiona una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "Actualizacion de inventario":

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
