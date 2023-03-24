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
            inventario FuncionInventario = new inventario();
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
                        FuncionInventario.agregarproducto();
                        AnsiConsole.MarkupLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "Visualizacion de inventario":
                        FuncionInventario.visualizaciondeinventario();
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
