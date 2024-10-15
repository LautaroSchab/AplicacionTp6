using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public int numTelefono { get; set; }
        public string username { get; set; }
        public string contrasena { get; set; }
    }
}
