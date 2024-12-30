using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CHistorialPaciente
    { 
        public int IdHistorial { get; set; }
        public int Peso { get; set; }
        public int Altura { get; set; }
        public string TipoSangre { get; set; }
        public string Enfermedades { get; set; }
        public string Alergias { get; set; }
        public CPaciente Paciente { get; set; }


    }
}
