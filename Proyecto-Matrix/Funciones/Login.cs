using Proyecto_Matrix.Clases;
using Proyecto_Matrix.Context;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Funciones
{
    public class Login
    {
        public void Welcome()
        {
            Console.WriteLine(@"
########  #### ######## ##    ## ##     ## ######## ##    ## #### ########   #######  
##     ##  ##  ##       ###   ## ##     ## ##       ###   ##  ##  ##     ## ##     ## 
##     ##  ##  ##       ####  ## ##     ## ##       ####  ##  ##  ##     ## ##     ## 
########   ##  ######   ## ## ## ##     ## ######   ## ## ##  ##  ##     ## ##     ## 
##     ##  ##  ##       ##  ####  ##   ##  ##       ##  ####  ##  ##     ## ##     ## 
##     ##  ##  ##       ##   ###   ## ##   ##       ##   ###  ##  ##     ## ##     ## 
########  #### ######## ##    ##    ###    ######## ##    ## #### ########   #######  
            ");
        }

        public void Sesion()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                int answ = 0;
                do
                {
                    Console.Clear();
                    Welcome();
                    Console.WriteLine("Escribe tu ID");
                    int ID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Escribe tu username");
                    string user = Console.ReadLine();
                    Console.WriteLine("Escribe tu contrasena");
                    string pass = Console.ReadLine();

                    Administrador administrador = _context.Administradores.Find(ID);
                    if (administrador == null)
                    {
                        Console.Clear();
                        Console.WriteLine("No estas registrado en la Base de Datos.Por favor contacta al administrador.");
                    }
                    else
                    {
                        string user1 = persona.Username;
                        string pass1 = persona.Password;
                        int tipouser1 = persona.TipoUsuario;
                        if (user == user1 && pass == pass1)
                        {
                            Menu menu = new Menu();
                            Console.Clear();
                            Console.WriteLine("Digita el numero que corresponde a tu tipo de usuario:\n1. Administrador\n2. Empleado");
                            int tipouser = int.Parse(Console.ReadLine());
                            if (tipouser == tipouser1 && tipouser == 1)
                            {
                                menu.imprimirmenuAdmin();
                            }
                            else if (tipouser == tipouser1 && tipouser == 2)
                            {
                                menu.imprimirmenuCajero();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("No tienes los permisos necesarios para usar el sistema");
                            }
                        }
                    }
                    Console.WriteLine("\nDeseas intentarlo nuevamente?");
                    Console.WriteLine("\n1. Si\n2.No");
                    answ = int.Parse(Console.ReadLine());
                    if (answ != 1 || answ != 2)
                    {
                        Console.WriteLine("Por favor ingresa una opcion correcta:");
                        Console.WriteLine("1.Si\n2.No");
                        answ = int.Parse(Console.ReadLine());
                    }
                } while (answ == 1);
            }
        }
    }
}
