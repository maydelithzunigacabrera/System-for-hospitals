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
    public class nPaciente
    {
        dPaciente pacientedatos;

        public nPaciente()
        {
            pacientedatos=new dPaciente(); 
        }

        public string RegistrarPaciente(int DNI, string nombre, string nacimiento, string distrito, string direccion, string usuario, string contrasena, string afiliacion)
        {
          
            CPaciente paciente = new CPaciente()
            {
                DNIPaciente = DNI,
                NombreCompleto = nombre,
                FechaNacimiento = nacimiento,
                Distrito = distrito,
                Direccion = direccion,
                Usuario = usuario,
                Contrasena = contrasena,
                FechaAfiliacion = afiliacion
            };
            return pacientedatos.insertar(paciente);
        }

        public string ModificarPaciente(int DNI, string nombre, string nacimiento, string distrito, string direccion, string usuario, string contrasena, string afiliacion)
        {
            
            CPaciente paciente = new CPaciente()
            {
                DNIPaciente = DNI,
                NombreCompleto = nombre,
                FechaNacimiento = nacimiento,
                Distrito = distrito,
                Direccion = direccion,
                Usuario = usuario,
                Contrasena = contrasena,
                FechaAfiliacion = afiliacion
            };
            return pacientedatos.Modificar(paciente);
        }

        public string EliminarPaciente(int DNI)
        {
            CPaciente paciente = new CPaciente()
            {
                DNIPaciente = DNI
            };
            return pacientedatos.Eliminar(paciente);
        }

        public DataTable ListarPacientes()
        {
            return pacientedatos.ListarPacients();
        }
        public DataTable loggearPACIENTE(String Usuario, String pass)
        {
            return pacientedatos.loggearPACIENTE(Usuario, pass);
        }
    }
}
