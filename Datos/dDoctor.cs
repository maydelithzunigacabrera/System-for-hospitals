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
    public class dDoctor
    {
        Database db = new Database();
        public SqlConnection cn;
        public SqlCommand comando;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;

        public string insertar(CDoctor doctor)
        {
            try
            {


                SqlCommand comando
               = new SqlCommand("INSERT INTO Doctor ([Nombre],[IdEspecialidad]) values (@nombre, @id) ", db.ConectaDb());

                comando.Parameters.AddWithValue("@nombre", doctor.Nombre);
                comando.Parameters.AddWithValue("@id", doctor.Especialidad.IdEspecialidad);

                comando.ExecuteNonQuery();

                MessageBox.Show("Se inserto el doctor al sistema");


            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_insertarDO " + ex.Message);
            }
            return "0";
        }

        public string Modificar(CDoctor doctor)
        {
            try
            {
                SqlCommand comando
                        = new SqlCommand("UPDATE  Doctor  set [Nombre]=@nombre,[IdEspecialidad]=@id  WHERE [IdDoctor]=@idD ", db.ConectaDb());

                comando.Parameters.AddWithValue("@idD", doctor.IdDoctor);
                comando.Parameters.AddWithValue("@nombre", doctor.Nombre);
                comando.Parameters.AddWithValue("@id", doctor.Especialidad);


                comando.ExecuteNonQuery();

                MessageBox.Show("Se modifico el administrador al sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_modificarDO " + ex.Message);
            }
            return "0";

        }

        public string Eliminar(CDoctor doctor)
        {

            try
            {
                SqlCommand comando
                        = new SqlCommand("DELETE FROM Doctor  WHERE [IdDoctor]=@idD ", db.ConectaDb());

                comando.Parameters.AddWithValue("@idD", doctor.IdDoctor);

                comando.ExecuteNonQuery();

                MessageBox.Show("Se elimino el administrador al sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_eliminarDO  " + ex.Message);
            }
            return "0";
        }
        public List<CDoctor> ListarTodo()
        {
            try
            {
                List<CDoctor> Lsdoctor = new List<CDoctor>();
                CDoctor doctor = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd
                   = new SqlCommand("Select * from Doctor", con);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctor = new CDoctor();
                    doctor.IdDoctor = (int)reader["IdDoctor"];
                    doctor.Nombre = (string)reader["Nombre"];
                    doctor.Especialidad.Especialidad = (string)reader["Especialidad"];

                    Lsdoctor.Add(doctor);
                }
                reader.Close();
                return Lsdoctor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error pro_ListCdoctor " + ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }

        }
        public DataTable ListDoctor()
        {

            try
            {

                comando = new SqlCommand("SELECT Nombre, Especialidad FROM Doctor INNER JOIN Especialidad ON Doctor.IdEspecialidad = Especialidad.IdEspecialidad; ", db.ConectaDb());
               
                da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error listDosc " + ex);
                return null;
            }
        }

        public List<CDoctor> listcomv(int id)
        {
            try
            {
                List<CDoctor> lsdoctores = new List<CDoctor>();
                CDoctor doctor = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("Select [IdDoctor],[Nombre] from  Doctor where IdEspecialidad=@idespecialidad", con);
                cmd.Parameters.AddWithValue("@idespecialidad", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctor = new CDoctor();
                    doctor.IdDoctor = (int)reader["IdDoctor"];
                    doctor.Nombre = (string)reader["Nombre"];
                    lsdoctores.Add(doctor);
                }
                reader.Close();
                return lsdoctores;
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
