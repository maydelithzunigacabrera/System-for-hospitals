using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CCita
    {
        public int CodigoCita { get; set; }
        public string Fecha { get; set; }
        public CPaciente Paciente{ get; set; }
        public CDoctor Doctor { get; set; }

    }
}
