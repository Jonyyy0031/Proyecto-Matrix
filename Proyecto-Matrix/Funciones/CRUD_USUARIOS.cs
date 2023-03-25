using System;
using Spectre.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Matrix.Context;
using Proyecto_Matrix.Clases;

namespace Proyecto_Matrix.Funciones
{
    public class CRUD_USUARIOS
    {
        public void addUSer()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Persona persona = new Persona();
                Console.WriteLine("Ingresa la informacion:");
                Console.WriteLine("\n1. Administrador\n2. Empleado");
                persona.TipoUsuario = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa un username");
                persona.Username = Console.ReadLine();
                Console.WriteLine("Ingresa una contrasena");
                persona.Password = Console.ReadLine();
                Console.WriteLine("Ingresa el nombre");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa el apellido");
                persona.Apellidos = Console.ReadLine();
                Console.WriteLine("Ingresa el puesto laboral");
                persona.Puesto = Console.ReadLine();

                _context.personas.Add(persona);
                _context.SaveChanges();
            }
        }
        public void updateUser(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Persona persona = _context.personas.Find(id);

                Console.WriteLine("Ingresa los nuevos datos:");
                Console.WriteLine("\n1. Administrador\n 2. Empleado");
                persona.TipoUsuario = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa un username");
                persona.Username = Console.ReadLine();
                Console.WriteLine("Ingresa una contrasena");
                persona.Password = Console.ReadLine();
                Console.WriteLine("Ingresa el nombre");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa el apellido");
                persona.Apellidos = Console.ReadLine();
                Console.WriteLine("Ingresa el puesto laboral");
                persona.Puesto = Console.ReadLine();

                _context.personas.Update(persona);
                _context.SaveChanges();
            }

        }
        public void viewUser()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                List<Persona> persona = _context.personas.ToList();

                foreach (var item in persona)
                {
                    Console.WriteLine($"\nPass: {item.Password}\nUsuario: {item.Username}\nID: {item.Idpersona}\nNombre: {item.Nombre}\nApellidos: {item.Apellidos}\nPuesto: {item.Puesto}\nTipo de Usuario: {item.TipoUsuario}\n---------------------");
                }
            }
        }
        public void deleteUser(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                Persona persona = _context.personas.Find(id);

                Console.WriteLine($"\nUsuario: {persona.Username}\nID: {persona.Idpersona}\nNombre: {persona.Nombre}\nApellidos: {persona.Apellidos}\nPuesto: {persona.Puesto}\nTipo de Usuario: {persona.TipoUsuario}\n esta siendo eliminado...");

                _context.personas.Remove(persona);
                _context.SaveChanges();
                Console.WriteLine("El usuario se ha eliminado con exito!");
            }
        }
    }
}
