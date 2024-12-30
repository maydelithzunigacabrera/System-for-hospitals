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
    public class dCita
    {
        Database db = new Database();
        public SqlConnection cn;
        public SqlCommand comando;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;

        public string insertar(CCita cita)
        {
            try
            {


                SqlCommand comando
               = new SqlCommand("INSERT INTO Cita ([DNIPaciente],[IdDoctor],[Fecha])values (@dnipaciente, @iddoctor, @fecha)", db.ConectaDb());

                comando.Parameters.AddWithValue("@dnipaciente", cita.Paciente.DNIPaciente);
                comando.Parameters.AddWithValue("@iddoctor", cita.Doctor.IdDoctor);
                comando.Parameters.AddWithValue("@fecha", cita.Fecha);


                comando.ExecuteNonQuery();

                MessageBox.Show("Se inserto la cita al sistema");


            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_insertarCI " + ex.Message);
            }
            return "0";
        }

        public string Modificar(CCita cita)
        {
            try
            {
                SqlCommand comando
                        = new SqlCommand("UPDATE  Cita  set [DNIPaciente]=@dnipaciente,[IdDoctor]=@iddoctor,[Fecha]=@fecha  WHERE [CodigoCita]=@codigocita ", db.ConectaDb());

                comando.Parameters.AddWithValue("@codigocita", cita.CodigoCita);
                comando.Parameters.AddWithValue("@dnipaciente", cita.Paciente.DNIPaciente);
                comando.Parameters.AddWithValue("@iddoctor", cita.Doctor.IdDoctor);
                comando.Parameters.AddWithValue("@fecha", cita.Fecha);



                comando.ExecuteNonQuery();

                MessageBox.Show("Se modifico la cita del sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_modificarCI " + ex.Message);
            }
            return "0";

        }

        public string Eliminar(CCita cita)
        {

            try
            {
                SqlCommand comando
                        = new SqlCommand("DELETE FROM Cita  WHERE [CodigoCita]=@codigocita ", db.ConectaDb());

                comando.Parameters.AddWithValue("@codigocita", cita.CodigoCita);

                comando.ExecuteNonQuery();

                MessageBox.Show("Se elimino la cita del sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_eliminarCI  " + ex.Message);
            }
            return "0";
        }
        public List<CCita> ListarTodo()
        {
            try
            {
                List<CCita> lscitas = new List<CCita>();
                CCita cita = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd
                   = new SqlCommand("Select * from  Cita  ", con);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cita = new CCita();
                    cita.CodigoCita = (int)reader["CodigoCita"];
                    cita.Paciente.DNIPaciente = (int)reader["DNIPaciente"];
                    cita.Doctor.IdDoctor = (int)reader["IdDoctor"];
                    cita.Fecha = (string)reader["Fecha"];



                    lscitas.Add(cita);
                }
                reader.Close();
                return lscitas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error pro_ListCpaciente " + ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }

        }

        public DataTable listarcitas(int dni)
        {

            try
            {

                comando = new SqlCommand("SELECT * FROM Cita WHERE [DNIPaciente] =@DNIPaciente  ", db.ConectaDb());
                comando.Parameters.AddWithValue("DNIPaciente", dni);
             
                da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);

                

                    return dt;

               
            }
            catch (Exception ex)
            {

                MessageBox.Show("eRRor en listar citas x dni " + ex);
                return null;
            }
        }
        public DataTable listartodascitas()
        {

            try
            {

                comando = new SqlCommand("SELECT cita.DNIPaciente,Paciente.NombreCompleto, cita.Fecha, Doctor.Nombre," +
                    " Especialidad.Especialidad FROM Cita inner  JOIN Doctor ON Cita.IdDoctor = Doctor.IdDoctor inner join Paciente on cita.DNIPaciente = Paciente.DNIPaciente inner join Especialidad on Doctor.IdEspecialidad = Especialidad.IdEspecialidad  ", db.ConectaDb());
                
                da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);



                return dt;


            }
            catch (Exception ex)
            {

                MessageBox.Show("listar citas general " + ex);
                return null;
            }
        }
    }
}
