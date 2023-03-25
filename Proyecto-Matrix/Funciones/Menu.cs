using Proyecto_Matrix.Clases;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class Menu
    {
        public void ImprimirLogo()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(@"
███████╗████████╗ ██████╗  ██████╗██╗  ██╗    ██╗   ██╗██████╗ 
██╔════╝╚══██╔══╝██╔═══██╗██╔════╝██║ ██╔╝    ██║   ██║██╔══██╗
███████╗   ██║   ██║   ██║██║     █████╔╝     ██║   ██║██████╔╝
╚════██║   ██║   ██║   ██║██║     ██╔═██╗     ██║   ██║██╔═══╝ 
███████║   ██║   ╚██████╔╝╚██████╗██║  ██╗    ╚██████╔╝██║     
╚══════╝   ╚═╝    ╚═════╝  ╚═════╝╚═╝  ╚═╝     ╚═════╝ ╚═╝");
            Console.WriteLine("\n");
        }
        public void imprimirmenu()
        {
            bool salir = false;
            while (salir != true)
            {
                Estatus estatus = new Estatus();
                inventario FuncionInventario = new inventario();
                ImprimirLogo();
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
                        estatus.Loading();
                        FuncionInventario.agregarproducto();
                        AnsiConsole.MarkupLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "Visualizacion de inventario":
                        estatus.Loading();
                        FuncionInventario.visualizaciondeinventario();
                        break;
                    case "Actualizacion de inventario":
                        estatus.Loading();
                        FuncionInventario.ModificarInventario();
                        break;
                    case "Ventas":
                        AnsiConsole.MarkupLine("Función en desarrollo");
                        AnsiConsole.MarkupLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "Salir":
                        Console.Clear();
                        ImprimirLogo();
                        AnsiConsole.MarkupLine("¡Hasta Luego!");
                        salir = true;
                        break;
                }
            }
        }
    }
}
