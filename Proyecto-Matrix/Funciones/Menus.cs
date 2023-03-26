using Proyecto_Matrix.Clases;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class Menus
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
        public void ImprimirLogoBienvenida()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"
██████╗ ██╗███████╗███╗   ██╗██╗   ██╗███████╗███╗   ██╗██╗██████╗  ██████╗ 
██╔══██╗██║██╔════╝████╗  ██║██║   ██║██╔════╝████╗  ██║██║██╔══██╗██╔═══██╗
██████╔╝██║█████╗  ██╔██╗ ██║██║   ██║█████╗  ██╔██╗ ██║██║██║  ██║██║   ██║
██╔══██╗██║██╔══╝  ██║╚██╗██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║██║██║  ██║██║   ██║
██████╔╝██║███████╗██║ ╚████║ ╚████╔╝ ███████╗██║ ╚████║██║██████╔╝╚██████╔╝
╚═════╝ ╚═╝╚══════╝╚═╝  ╚═══╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝╚═╝╚═════╝  ╚═════╝ 
                                                                            ");
            Console.WriteLine("\n");
        }
        public void imprimirmenuAdministrador()
        {
            bool salir = false;
            while (salir != true)
            {
                Console.Clear();
                Menus menu = new Menus();
                Estatus estatus = new Estatus();
                inventario FuncionInventario = new inventario();
                menu.ImprimirLogo();
                var Funcion = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
            .Title("¿Que desea Realizar?")
            .PageSize(10)
            .AddChoices(new[] {
            "Registro de productos", "Visualizacion de inventario", "Actualizacion de inventario",
             "Usuarios","Salir"
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
                    case "Usuarios":
                        estatus.Loading();
                        Console.Clear ();
                        imprimirmenufuncionusuario();
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
        public void imprimirmenuEmpleado()
        {
            bool salir = false;
            while (salir != true)
            {
                Console.Clear();
                Menus menu = new Menus();
                Estatus estatus = new Estatus();
                inventario FuncionInventario = new inventario();
                menu.ImprimirLogo();
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
                    case "Salir":
                        Console.Clear();
                        ImprimirLogo();
                        AnsiConsole.MarkupLine("¡Hasta Luego!");
                        salir = true;
                        break;
                }
            }
        }
        public void imprimirmenufuncionusuario()
        {
            bool salir = false;
            while (salir != true)
            {
                Menus menu  = new Menus();
                Estatus estatus = new Estatus();
                CRUDEmpleado funcionusuarios = new CRUDEmpleado();
                menu.ImprimirLogo();
                var Funcion = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
            .Title("¿Que desea Realizar?")
            .PageSize(10)
            .AddChoices(new[] {
            "Añadir nuevo Empleado","Visualizar Empleados","Modificar Empleados","Regresar"
            }));
            switch (Funcion)
                {
                    case "Añadir nuevo Empleado":
                        estatus.Loading();
                        funcionusuarios.AñadirEmpleado();
                        break;
                    case "Visualizar Empleados":
                        estatus.Loading();
                        funcionusuarios.VisualizarEmpleados();
                        break;
                    case "Modificar Empleados":
                        estatus.Loading();
                        funcionusuarios.ModificarEmpleados();
                        break;
                    case "Regresar":
                        salir = true;
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
