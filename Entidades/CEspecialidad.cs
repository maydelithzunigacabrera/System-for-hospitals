using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CEspecialidad
    {
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public override string ToString()
        {
            return Especialidad;
        }
    }
}
