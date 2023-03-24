using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Clases
{
    public class Administrador
    {
        [Key]
        public int IDAdministrador { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }


    }
}
