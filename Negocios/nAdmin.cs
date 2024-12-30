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
    public class nAdmin
    {
        dAdmin admindatos;

        public nAdmin()
        {
            admindatos = new dAdmin();
        }

        public string RegistrarAdmin( string nombre, int DNI,  string usuario, string contrasena)
        {
            CAdmin admin = new CAdmin()
            {
                Nombre = nombre,
                DNIAdministrador = DNI,
                Usuario=usuario,
                Contrasena=contrasena
            };
            return admindatos.insertar(admin);
        }

        public string ModificarAdmin(int codigo, string nombre, int DNI, string usuario, string contrasena)
        {
            CAdmin admin = new CAdmin()
            {
                CodigoAdmin = codigo,
                Nombre = nombre,
                DNIAdministrador = DNI,
                Usuario = usuario,
                Contrasena = contrasena
            };
            return admindatos.Modificar(admin);
        }

        public string EliminarAdmin(int codigo)
        {
            CAdmin admin = new CAdmin()
            {
                CodigoAdmin = codigo

            };
            return admindatos.Eliminar(admin);
        }

        public List<CAdmin> ListarAdmin()
        {
            return admindatos.ListarTodo();
        }
        public DataTable loggearAdmin(String Usuario, String pass)
        {
            return admindatos.loggearAdmin(Usuario, pass);
        }

    }
}
