using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CDoctor
    {
        public int IdDoctor { get; set; }
        public string Nombre { get; set; } 
        public CEspecialidad Especialidad { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
