using System;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Data.SqlClient;
using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Proyecto_Matrix.Funciones;
using Spectre.Console;

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
            "Salir"
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
                        var table = new Table().LeftAligned();

                        AnsiConsole.Live(table)
                            .Start(ctx =>
                            {
                                table.AddColumn("ID");
                                //table.AddRow("Nombre Producto", producto.precio);
                                ctx.Refresh();
                                Thread.Sleep(1000);

                                table.AddColumn("Nombre Producto");
                                ctx.Refresh();
                                Thread.Sleep(1000);
                            });
                        break;
                    case "Actualizacion de inventario":

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
