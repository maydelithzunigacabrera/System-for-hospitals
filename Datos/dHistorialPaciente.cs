using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;
using System.Windows.Forms;

namespace Datos
{
    public class dHistorialPaciente
    {
        Database db = new Database();
        public SqlConnection cn;
        public SqlCommand comando;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;

        public string insertar(CHistorialPaciente historial)
        {
            try
            {


                SqlCommand comando
               = new SqlCommand("INSERT INTO HistorialPaciente ([DNIPaciente],[Peso],[Altura],[TipoSangre],[Enfermedades],[Alergias])values (@dnipaciente, @peso, @altura, @tiposangre,@enfermedades,@alergias)", db.ConectaDb());

                comando.Parameters.AddWithValue("@dnipaciente", historial.Paciente.DNIPaciente);
                comando.Parameters.AddWithValue("@peso", historial.Peso);
                comando.Parameters.AddWithValue("@altura", historial.Altura);
                comando.Parameters.AddWithValue("@tiposangre", historial.TipoSangre);
                comando.Parameters.AddWithValue("@enfermedades", historial.Enfermedades);
                comando.Parameters.AddWithValue("@alergias", historial.Alergias);


                comando.ExecuteNonQuery();

                MessageBox.Show("Se inserto el historial al sistema");


            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_insertarHI " + ex.Message);
            }
            return "0";
        }

        public string Modificar(CHistorialPaciente historial)
        {
            try
            {
                SqlCommand comando
                        = new SqlCommand("UPDATE  HistorialPaciente  set [DNIPaciente]=@dnipaciente,[Peso]=@peso,[Altura]=@altura,[TipoSangre]=@tiposangre,[Enfermedades]=@enfermedades,[Alergias]=alergias  WHERE [IdHistorial]=@idhistorial ", db.ConectaDb());

                comando.Parameters.AddWithValue("@idhistorial", historial.IdHistorial);
                comando.Parameters.AddWithValue("@dnipaciente", historial.Paciente.DNIPaciente);
                comando.Parameters.AddWithValue("@peso", historial.Peso);
                comando.Parameters.AddWithValue("@altura", historial.Altura);
                comando.Parameters.AddWithValue("@tiposangre", historial.TipoSangre);
                comando.Parameters.AddWithValue("@enfermedades", historial.Enfermedades);
                comando.Parameters.AddWithValue("@alergias", historial.Alergias);



                comando.ExecuteNonQuery();

                MessageBox.Show("Se modifico el historial del sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_modificarHI " + ex.Message);
            }
            return "0";

        }

        public string Eliminar(CHistorialPaciente historial)
        {

            try
            {
                SqlCommand comando
                        = new SqlCommand("DELETE FROM HistorialPaciente  WHERE [IdHistorial]=@idhistorial ", db.ConectaDb());

                comando.Parameters.AddWithValue("@idhistorial", historial.IdHistorial);

                comando.ExecuteNonQuery();

                MessageBox.Show("Se elimino el historial del sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_eliminarHI  " + ex.Message);
            }
            return "0";
        }
        public List<CHistorialPaciente> ListarTodo()
        {
            try
            {
                List<CHistorialPaciente> lshistorial = new List<CHistorialPaciente>();
                CHistorialPaciente historial = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd
                   = new SqlCommand("Select * from  HistorialPaciente  ", con);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    historial = new CHistorialPaciente();
                    historial.IdHistorial = (int)reader["IdHistorial"];
                    historial.Paciente.DNIPaciente = (int)reader["DNIPaciente"];
                    historial.Peso = (int)reader["Peso"];
                    historial.Altura = (int)reader["Altura"];
                    historial.Enfermedades = (string)reader["Enfermedades"];
                    historial.Alergias =(string)reader["Alergias"];




                    lshistorial.Add(historial);
                }   
                reader.Close();
                return lshistorial;
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


    }
}
