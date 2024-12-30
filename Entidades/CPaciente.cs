using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CPaciente
    {
        public int DNIPaciente { get; set; }
        public string NombreCompleto { get; set; }
        public string FechaNacimiento { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string FechaAfiliacion { get; set; }
     
        public override string ToString()
        {
            return NombreCompleto;
        }


    }
}
