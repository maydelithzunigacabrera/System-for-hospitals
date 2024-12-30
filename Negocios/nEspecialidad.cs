using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Negocios;
using Entidades;
using System.Windows.Forms;
using System.Data;

namespace Negocios
{
    public class nEspecialidad
    {
        dEspecialidad especialidaddatos;

        public nEspecialidad()
        {
            especialidaddatos = new dEspecialidad();
        }

        public string RegistrarEspecialidad(string nombre)
        {
            CEspecialidad especialidad = new CEspecialidad()
            {
                Especialidad = nombre
            };
            return especialidaddatos.insertar(especialidad);
        }

        public string ModificarEspecialidad(int id, string nombre)
        {
            CEspecialidad especialidad = new CEspecialidad()
            {
                IdEspecialidad = id,
                Especialidad = nombre
            };
            return especialidaddatos.Modificar(especialidad);
        }

        public string EliminarEspecialidad(int id)
        {
            CEspecialidad especialidad = new CEspecialidad()
            {
                IdEspecialidad = id
            };
            return especialidaddatos.Eliminar(especialidad);
        }

        public List<CEspecialidad> ListarEspecialidad()
        {
            return especialidaddatos.ListarTodo();
        }

        public List<CEspecialidad> ListarID()
        {
            return especialidaddatos.ListarID();
        }
        public List<CEspecialidad> listcomb()
        {
            return especialidaddatos.listcomb();
        }

    }
        
}
