using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using Negocios;

namespace Negocios
{
    public class nHistorial
    {
        dHistorialPaciente historialdatos;

        public nHistorial()
        {
            historialdatos = new dHistorialPaciente();
        }

        public string RegistrarHistorial(int peso, int altura, string tiposangre, string enfermedades, string alergias, int DniP)
        {
            CPaciente paciente = new CPaciente()
            {
                DNIPaciente = DniP,
            };

            CHistorialPaciente historial = new CHistorialPaciente()
            {
                Peso = peso,
                Altura = altura,
                TipoSangre = tiposangre,
                Enfermedades = enfermedades,
                Alergias = alergias,
                Paciente = paciente,

            };
            return historialdatos.insertar(historial);
        }

        public string ModificarHistorial(int idH, int peso, int altura, string tiposangre, string enfermedades, string alergias, int DniP)
        {
            CPaciente paciente = new CPaciente()
            {
                DNIPaciente = DniP,
            };

            CHistorialPaciente historial = new CHistorialPaciente()
            {
                IdHistorial = idH,
                Peso = peso,
                Altura = altura,
                TipoSangre = tiposangre,
                Enfermedades = enfermedades,
                Alergias = alergias,
                Paciente = paciente,

            };
            return historialdatos.Modificar(historial);
        }

        public string EliminarHistorial(int id)
        {
            CHistorialPaciente historial = new CHistorialPaciente()
            {
                IdHistorial = id
            };
            return historialdatos.Eliminar(historial);
        }

        public List<CHistorialPaciente> ListarHistorial()
        {
            return historialdatos.ListarTodo();
        }

    }
}
