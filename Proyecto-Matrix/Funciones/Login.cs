using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class Login
    {
        public void Bienvenida()
        {
            Menus menu = new Menus();
            menu.ImprimirLogoBienvenida();
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var Funcion = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
            .Title("Seleccione como desea ingresar")
            .PageSize(10)
            .AddChoices(new[] {
            "Ingresar como Administrador","Ingresar como Empleado"
            }));
            switch (Funcion)
                {
                    case "Ingresar como Administrador":
                        Console.Clear();
                        menu.ImprimirLogoBienvenida();
                        int IDAdministrador = 1;
                        Administrador administrador = _context.Administradores.Find(IDAdministrador);
                        if (administrador != null)
                        {
                            int intentos1 = 0;
                            while (intentos1 < 6)
                            {
                                Console.Clear();
                                menu.ImprimirLogoBienvenida();
                                string UsuarioA = AnsiConsole.Ask<string>("Ingresa tu Usuario: ");
                                string ContraseñaAdmin = AnsiConsole.Ask<string>("Ingresa tu Contraseña: ");
                                if (administrador.User == UsuarioA && administrador.Password == ContraseñaAdmin)
                                {
                                    Console.Clear();
                                    menu.ImprimirLogo();
                                    Console.WriteLine("Bienvenido " + UsuarioA);
                                    menu.imprimirmenuAdministrador();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    intentos1 ++;
                                    Console.WriteLine("Datos incorrectos, Ingrese de nuevo los datos. Tiene como maximo 5 intentos");
                                    Console.WriteLine("Presione una tecla para continuar");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("No existe esa ID de Administrador");
                        }
                        break;
                    case "Ingresar como Empleado":

                        Console.Clear();
                        menu.ImprimirLogoBienvenida();
                        int IDEmpleado = AnsiConsole.Ask<int>("Ingresa tu ID de Empleado proporcionado por el Administrador: ");
                        Empleado empleado = _context.Empleados.Find(IDEmpleado);
                        if (empleado != null)
                        {
                            int intentos = 0;
                            while (intentos <6)
                            {
                                Console.Clear();
                                menu.ImprimirLogoBienvenida();
                                string Usuario = AnsiConsole.Ask<string>("Ingresa tu Usuario: ");
                                string ContraseñaEmpleado = AnsiConsole.Ask<string>("Ingresa tu contraseña: ");
                                if (empleado.UserE == Usuario && empleado.PasswordE == ContraseñaEmpleado)
                                {
                                    Console.Clear();
                                    menu.ImprimirLogo();
                                    Console.WriteLine("Bienvenido " + Usuario);
                                    menu.imprimirmenuEmpleado();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.WriteLine("Datos incorrectos, Ingrese de nuevo los datos. Tiene como maximo 5 intentos");
                                    Console.WriteLine("Presione una tecla para continuar");
                                    Console.ReadKey();
                                    Console.Clear();
                                    intentos++;
                                }
                            }
                            Console.WriteLine("Excedio el limite de intentos");
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else
                        {
                            AnsiConsole.MarkupLine("No existe esa ID de empleado");
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }
    }
}
