using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Negocios;
using Entidades;
using System.Data;

namespace Negocios
{
    public class nCita
    {
        dCita citadatos;

        public nCita()
        {
            citadatos = new dCita();
        }

        public string RegistrarCita( int DNIP, int idD, string fecha)
        {
            //string s = fecha.ToShortDateString();
            //string dia, mes, anio;
            //int pos1, pos2;
            //pos1 = s.IndexOf("/");
            //pos2 = s.IndexOf("/", pos1 + 1);
            //dia = s.Substring(0, pos1);
            //mes = s.Substring(pos1 + 1, pos2 - pos1 - 1);
            //anio = s.Substring(pos2 + 1, s.Length - pos2 - 1);

            CPaciente paciente = new CPaciente()
            {
                DNIPaciente = DNIP,
            };

            CDoctor doctor = new CDoctor()
            {
                IdDoctor = idD,
            };

            CCita cita = new CCita()
            {
                
                Paciente = paciente,
                Doctor = doctor,
                Fecha = fecha,
            };
            return citadatos.insertar(cita);
        }

        public string ModificarCita(int codigocita, int DNIP, int idD, DateTime fecha)
        {

            string s = fecha.ToShortDateString();
            string dia, mes, anio;
            int pos1, pos2;
            pos1 = s.IndexOf("/");
            pos2 = s.IndexOf("/", pos1 + 1);
            dia = s.Substring(0, pos1);
            mes = s.Substring(pos1 + 1, pos2 - pos1 - 1);
            anio = s.Substring(pos2 + 1, s.Length - pos2 - 1);
            CPaciente paciente = new CPaciente()
            {
                DNIPaciente = DNIP,
            };

            CDoctor doctor = new CDoctor()
            {
                IdDoctor = idD,
            };

            CCita cita = new CCita()
            {
                CodigoCita = codigocita,
                Paciente = paciente,
                Doctor = doctor,
                Fecha = anio + "/" + mes + "/" + dia,
            };
            return citadatos.Modificar(cita);
        }

        public string EliminarCita(int cod)
        {
            CCita cita = new CCita()
            {
                CodigoCita = cod
            };
            return citadatos.Eliminar(cita);
        }

        public List<CCita> ListarCita()
        {
            return citadatos.ListarTodo();
        }

        public DataTable listarcitas(int dni)
        {
            return citadatos.listarcitas(dni);
        }
        public DataTable listartodascitas()
        {
            return citadatos.listartodascitas();
        }


    }
}
