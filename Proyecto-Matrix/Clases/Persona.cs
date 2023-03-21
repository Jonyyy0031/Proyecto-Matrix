using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Matrix.Clases
{
    public class Persona
    {
        [Key]
        public int Idpersona { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }


    }
}
