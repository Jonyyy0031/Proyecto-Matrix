using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Clases
{
    public class Empleado
    {
        [Key]
        public int IDEmpleado { get; set; }
        public string UserE { get; set; }
        public string PasswordE { get; set; }
        public string NombreE { get; set; }
        public string Apellido { get ; set; }
        public string Puesto { get; set; }
    }
}
