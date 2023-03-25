using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
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
       public void imprimirmenuAdmin()
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
             var FuncionMenu = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
            .Title("¿Que desea Realizar?")
            .PageSize(10)
            .AddChoices(new[] {
            "Registro de productos", "Visualizacion de inventario", "Actualizacion de inventario","Eliminar Producto",
            "Usuarios","Salir",
            }));

                CRUD_INVENTARIO CRUD = new CRUD_INVENTARIO();
                switch (FuncionMenu)
                {
                    case "Registro de productos":
                        CRUD.CrearProducto();
                        AnsiConsole.MarkupLine("Producto agregado con exito");
                        AnsiConsole.MarkupLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "Visualizacion de inventario":
                        CRUD.Leer();
                        AnsiConsole.MarkupLine("Presiona una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "Actualizacion de inventario":
                        Console.WriteLine("Ingresa el ID del producto que deseas actualizar");
                        int idEdit = int.Parse(Console.ReadLine());
                        CRUD.ActualizarInventario(idEdit);
                        break;

                    case "Eliminar Producto":
                        Console.WriteLine("Ingresa el ID del producto que deseas eliminar");
                        int idDelete = int.Parse(Console.ReadLine());
                        CRUD.EliminarInventario(idDelete);
                        break;

                    case "Usuarios":
                         var FuncionUsers = AnsiConsole.Prompt(
                         new SelectionPrompt<string>()
                        .Title("¿Que desea Realizar?")
                        .PageSize(10)
                        .AddChoices(new[] {
                        "Registrar Usuario", "Editar Usuario", "Ver Usuarios","Eliminar Usuario","Salir",
                        }));
                        CRUD_USUARIOS usuarioscrud = new CRUD_USUARIOS();
                        switch (FuncionUsers)
                        {
                            case "Registrar Usuario":
                                usuarioscrud.addUSer();
                                break;
                            case "Editar Usuario":
                                Console.WriteLine("Ingresa el ID del usuario que deseas actualizar");
                                int idupdate = int.Parse(Console.ReadLine());
                                usuarioscrud.updateUser(idupdate);
                                break;
                            case "Ver Usuarios":
                                usuarioscrud.viewUser();
                                break;
                            case "Eliminar Usuario":
                                Console.WriteLine("Ingresa el ID del usuario que deseas eliminar");
                                int idelete = int.Parse(Console.ReadLine());
                                usuarioscrud.deleteUser(idelete);
                                break;
                            case "Salir":
                                Menu menu = new Menu();
                                menu.imprimirmenuAdmin();
                                break;
                        }
                        break;

                    case "Salir":
                        Console.Clear();
                        AnsiConsole.MarkupLine("¡Hasta Luego!");
                        salir = true;
                        break;
                }
            }
        }
        public void imprimirmenuCajero()
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
                "Eliminar Producto","Salir",
               }));

                CRUD_INVENTARIO CRUD = new CRUD_INVENTARIO();
                switch (Funcion)
                {
                    case "Registro de productos":
                        CRUD.CrearProducto();
                        AnsiConsole.MarkupLine("Producto agregado con exito");
                        AnsiConsole.MarkupLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "Visualizacion de inventario":
                        CRUD.Leer();
                        AnsiConsole.MarkupLine("Presiona una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "Actualizacion de inventario":
                        Console.WriteLine("Ingresa el ID del producto que deseas actualizar");
                        int idEdit = int.Parse(Console.ReadLine());
                        CRUD.ActualizarInventario(idEdit);
                        break;

                    case "Eliminar Producto":
                        Console.WriteLine("Ingresa el ID del producto que deseas eliminar");
                        int idDelete = int.Parse(Console.ReadLine());
                        CRUD.EliminarInventario(idDelete);
                        break;

                    case "Salir":
                        Console.Clear();
                        AnsiConsole.MarkupLine("¡Hasta Luego!");
                        Program program = new Program();
                        salir = true;
                        break;
                }
            }
        }
    }
}
