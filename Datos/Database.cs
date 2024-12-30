using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class Database
    {
        private SqlConnection conn;
        public SqlCommand comando;
        public SqlConnection ConectaDb()
        {
            try
            {
                string cadenaconexion = "Data Source=Localhost; Initial Catalog=DBTF; Integrated Security=True";
                //DESKTOP-KRO8EJA\\SEBASDATOS
                conn = new SqlConnection(cadenaconexion);
                conn.Open();
                return conn;
            }
            catch (SqlException )
            {
                return null;
            }
        }
        public void DesconectaDb()
        {
            conn.Close();
        }


       




    }
}
