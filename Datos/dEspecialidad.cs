using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.Data;
using System.Windows.Forms;

namespace Datos
{
    public class dEspecialidad
    {
        Database db = new Database();
        public SqlConnection cn;
        public SqlCommand comando;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;

        public string insertar(CEspecialidad especialidad)
        {
            try
            {


                SqlCommand comando
               = new SqlCommand("INSERT INTO Especialidad ([Especialidad]) values (@especialidad) ", db.ConectaDb());

                comando.Parameters.AddWithValue("@especialidad", especialidad.Especialidad);


                comando.ExecuteNonQuery();

                MessageBox.Show("Se inserto la especialidad al sistema");


            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_insertarE " + ex.Message);
            }
            return "0";
        }

        public string Modificar(CEspecialidad especialidad)
        {
            try
            {
                SqlCommand comando
                        = new SqlCommand("UPDATE  Especialidad  set [Especialidad]=@especialidad  WHERE [IdEspecialidad]=@idE ", db.ConectaDb());

                comando.Parameters.AddWithValue("@idE", especialidad.IdEspecialidad);
                comando.Parameters.AddWithValue("@especialidad", especialidad.Especialidad);



                comando.ExecuteNonQuery();

                MessageBox.Show("Se modifico la especialidad al sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_modificarE " + ex.Message);
            }
            return "0";

        }

        public string Eliminar(CEspecialidad especialidad)
        {

            try
            {
                SqlCommand comando
                        = new SqlCommand("DELETE FROM Especialidad  WHERE [IdEspecialidad]=@idE ", db.ConectaDb());

                comando.Parameters.AddWithValue("@idE", especialidad.IdEspecialidad);

                comando.ExecuteNonQuery();

                MessageBox.Show("Se elimino la especialidad al sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_eliminarE  " + ex.Message);
            }
            return "0";
        }

        



        public List<CEspecialidad> ListarTodo()
        {
            try
            {
                List<CEspecialidad> lsespecialidad = new List<CEspecialidad>();
                CEspecialidad especialidad = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd
                   = new SqlCommand("Select * from  Especialidad  ", con);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    especialidad = new CEspecialidad();
                    especialidad.IdEspecialidad = (int)reader["IdEspecialidad"];
                    especialidad.Especialidad = (string)reader["Especialidad"];


                    lsespecialidad.Add(especialidad);
                }
                reader.Close();
                return lsespecialidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error pro_ListCespecialidad " + ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }

        }

        public List<CEspecialidad> ListarID()
        {
            try
            {
                List<CEspecialidad> lsespecialidad = new List<CEspecialidad>();
                CEspecialidad especialidad = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd
                   = new SqlCommand("Select IdEspecialidad from Especialidad  ", con);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    especialidad = new CEspecialidad();
                    especialidad.IdEspecialidad = (int)reader["IdEspecialidad"];
                    lsespecialidad.Add(especialidad);
                }
                reader.Close();
                return lsespecialidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error pro_ListCespecialidad " + ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }

        }

        public List<CEspecialidad> listcomb()
        {
            try
            {
                List<CEspecialidad> lsespecialidad = new List<CEspecialidad>();
                CEspecialidad especialidad = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("Select [IdEspecialidad],[Especialidad] from  Especialidad", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    especialidad = new CEspecialidad();
                    especialidad.IdEspecialidad = (int)reader["IdEspecialidad"];
                    especialidad.Especialidad = (string)reader["Especialidad"];
                    lsespecialidad.Add(especialidad);
                }
                reader.Close();
                return lsespecialidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error pro_ListCespecialiddddddad " + ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }



    }
}
