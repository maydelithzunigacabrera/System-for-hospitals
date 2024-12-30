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
    public class dPaciente
    {
        Database db =new Database();
        public SqlConnection cn;
        public SqlCommand comando;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;

        public string insertar(CPaciente paciente)
        {
            try
            {


                SqlCommand comando
               = new SqlCommand("INSERT INTO Paciente ([DNIPaciente],[NombreCompleto],[FechaNacimiento],[Distrito],[Direccion],[Usuario],[Contraseña],[FechaAfiliacion]) values (@dnipaciente, @nombre, @fechanaci,@distrito,@direccion,@usuario,@contrasena,@fechaafiliacion)", db.ConectaDb());

                comando.Parameters.AddWithValue("@dnipaciente", paciente.DNIPaciente);
                comando.Parameters.AddWithValue("@nombre", paciente.NombreCompleto);
                comando.Parameters.AddWithValue("@fechanaci", paciente.FechaNacimiento);
                comando.Parameters.AddWithValue("@distrito", paciente.Distrito);
                comando.Parameters.AddWithValue("@direccion", paciente.Direccion);
                comando.Parameters.AddWithValue("@usuario", paciente.Usuario);
                comando.Parameters.AddWithValue("@contrasena", paciente.Contrasena);
                comando.Parameters.AddWithValue("@fechaafiliacion", paciente.FechaAfiliacion);

                comando.ExecuteNonQuery();

                MessageBox.Show("Se inserto el paciente al sistema");


            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_insertarPA " + ex.Message);
            }
            return "0";
        }

        public string Modificar(CPaciente paciente)
        {
            try
            {
                SqlCommand comando
                        = new SqlCommand("UPDATE  Paciente  set [DNIPaciente]=@dnipaciente,[NombreCompleto]=@nombre,[FechaNacimiento]=@fechanaci,[Distrito]=@distrito,[Direccion]=@direccion,[Usuario]=@usuario,[Contraseña]=@contrasena,[FechaAfiliacion]=@fechaafiliacion  WHERE [DNIPaciente]=@dnipaciente ", db.ConectaDb());

                comando.Parameters.AddWithValue("@dnipaciente", paciente.DNIPaciente);
                comando.Parameters.AddWithValue("@nombre", paciente.NombreCompleto);
                comando.Parameters.AddWithValue("@fechanaci", paciente.FechaNacimiento);
                comando.Parameters.AddWithValue("@distrito", paciente.Distrito);
                comando.Parameters.AddWithValue("@direccion", paciente.Direccion);
                comando.Parameters.AddWithValue("@usuario", paciente.Usuario);
                comando.Parameters.AddWithValue("@contrasena", paciente.Contrasena);
                comando.Parameters.AddWithValue("@fechaafiliacion", paciente.FechaAfiliacion);


                comando.ExecuteNonQuery();

                MessageBox.Show("Se modifico el paciente al sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_modificarPA " + ex.Message);
            }
            return "0";

        }

        public string Eliminar(CPaciente paciente)
        {

            try
            {
                SqlCommand comando
                        = new SqlCommand("DELETE FROM Paciente  WHERE [DNIPaciente]=@dnipaciente ", db.ConectaDb());

                comando.Parameters.AddWithValue("@dnipaciente", paciente.DNIPaciente);

                comando.ExecuteNonQuery();

                MessageBox.Show("Se elimino el paciente al sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_eliminarPA  " + ex.Message);
            }
            return "0";
        }
        public List<CPaciente> ListarTodo()
        {
            try
            {
                List<CPaciente> Lspacientes = new List<CPaciente>();
                CPaciente paciente = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd
                   = new SqlCommand("Select * from  Paciente  ", con);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    paciente = new CPaciente();
                    paciente.DNIPaciente = (int)reader["DNIPaciente"];
                    paciente.NombreCompleto = (string)reader["NombreCompleto"];
                    paciente.FechaNacimiento = (string)reader["FechaNacimiento"];
                    paciente.Distrito = (string)reader["Distrito"];
                    paciente.Direccion = (string)reader["Direccion"];
                    paciente.Usuario = (string)reader["Usuario"];
                    paciente.Contrasena = (string)reader["Contrasena"];
                    paciente.FechaAfiliacion = (string)reader["FechaAfiliacion"];


                    Lspacientes.Add(paciente);
                }
                reader.Close();
                return Lspacientes;
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


        public DataTable ListarPacients() {

            try
            {
                comando = new SqlCommand("Select * from  Paciente  ", db.ConectaDb());
                da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("listado  " + ex);
                return null;
            }

        }





        public DataTable loggearPACIENTE(String Usuario, string pass)
        {

            try
            {

                comando = new SqlCommand("SELECT NombreCompleto ,DNIPaciente FROM Paciente WHERE Usuario =@usuario AND Contraseña =@pass ", db.ConectaDb());
                comando.Parameters.AddWithValue("Usuario", Usuario);
                comando.Parameters.AddWithValue("pass", pass);
                da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                   
                    return dt;

                }
                else
                {
                    
                    return null;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("clave y/o usuario incorrect paciente " + ex);
                return null;
            }
        }
    }
}
