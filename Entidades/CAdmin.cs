using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CAdmin
    {
    public int CodigoAdmin { get; set; }
    public string Nombre { get; set; }
    public int DNIAdministrador { get; set; }
    public string Usuario { get; set; }
    public string Contrasena { get; set; }

    public override string ToString()
    {
         return Nombre;
    }

    }
}   


