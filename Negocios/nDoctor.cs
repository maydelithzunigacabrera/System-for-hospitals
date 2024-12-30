using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using Negocios;

namespace Negocios
{
    public class nDoctor
    {
        dDoctor doctordatos;

        public nDoctor()
        {
            doctordatos = new dDoctor();
        }

        public string RegistrarDoctor(string nombre, int idespecialidad)
        {
            CEspecialidad especialidad = new CEspecialidad()
            {
                IdEspecialidad = idespecialidad,
            };

            CDoctor doctor = new CDoctor()
            {
                Nombre = nombre,
                Especialidad = especialidad
            };
            return doctordatos.insertar(doctor);
        }

        public string ModificarDoctor(int idDoc, string nombre, int idespecialidad)
        {
            CEspecialidad especialidad = new CEspecialidad()
            {
                IdEspecialidad = idespecialidad,
            };

            CDoctor doctor = new CDoctor()
            {
                IdDoctor = idDoc,
                Nombre = nombre,
                Especialidad = especialidad
            };
            return doctordatos.Modificar(doctor);

        }

        public string EliminarDoctor(int id)
        {
            CDoctor doctor = new CDoctor()
            {
                IdDoctor = id
            };
            return doctordatos.Eliminar(doctor);
        }

        public List<CDoctor> ListarDoctores()
        {
            return doctordatos.ListarTodo();
        }
        public DataTable ListDoctor()
        {
            return doctordatos.ListDoctor();
        }

        public List<CDoctor> listcomv(int id)
        {
            return doctordatos.listcomv(id);
        }

    }
}
