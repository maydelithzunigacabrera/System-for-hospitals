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
    public class dAdmin
    {
        Database db = new Database();
        public SqlConnection cn;
        public SqlCommand comando;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;

        public string insertar(CAdmin admin)
        {
            try
            {
                bool verificacion = false;
                SqlCommand comando1
                 = new SqlCommand("SELECT * FROM Administrador WHERE  DNIAdministrador = @dni ", db.ConectaDb());

                comando1.Parameters.AddWithValue("@dni", admin.DNIAdministrador);

                int i = comando1.ExecuteNonQuery();
               
                if (i > 0)
                {
                    verificacion = false;
                    
                }
                else
                {
                    verificacion = true;

                }

                if (verificacion==true)
                {
                        MessageBox.Show("ya existe el DNI en el sistema");
                }

                else
                {
                    SqlCommand comando
                   = new SqlCommand("INSERT INTO Administrador ([Nombre],[DNIAdministrador],[Usuario],[Contraseña]) values (@nombre, @dni, @usuario, @pass) ", db.ConectaDb());

                    comando.Parameters.AddWithValue("@nombre", admin.Nombre);
                    comando.Parameters.AddWithValue("@dni", admin.DNIAdministrador);
                    comando.Parameters.AddWithValue("@usuario", admin.Usuario);
                    comando.Parameters.AddWithValue("@pass", admin.Contrasena);
                    comando.ExecuteNonQuery();

                    MessageBox.Show("Se inserto el administrador al sistema");
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_insertarAD " + ex.Message); 
            }
            return "0";
        }

        public string Modificar(CAdmin admin)
        {
            try {
                SqlCommand comando
                        = new SqlCommand("UPDATE  Administrador  set [Nombre]=@nombre,[DNIAdministrador]=@dni,[Usuario]=@usuario,[Contraseña]=@pass  WHERE [CodigoAdmin]=@id ", db.ConectaDb());

                comando.Parameters.AddWithValue("@id", admin.CodigoAdmin);
                comando.Parameters.AddWithValue("@nombre", admin.Nombre);
                comando.Parameters.AddWithValue("@dni", admin.DNIAdministrador);
                comando.Parameters.AddWithValue("@usuario", admin.Usuario);
                comando.Parameters.AddWithValue("@pass", admin.Contrasena);
                comando.ExecuteNonQuery();

                MessageBox.Show("Se modifico el administrador al sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_modificarAD " + ex.Message);
            }
            return "0";

        }

        public string Eliminar(CAdmin admin)
        {

            try
            {
                SqlCommand comando
                        = new SqlCommand("DELETE FROM Administrador  WHERE [CodigoAdmin]=@id ", db.ConectaDb());

                comando.Parameters.AddWithValue("@id", admin.CodigoAdmin);
               
                comando.ExecuteNonQuery();

                MessageBox.Show("Se elimino el administrador al sistema");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error en pro_eliminarAD  " + ex.Message);
            }
            return "0";
        }
        public List<CAdmin> ListarTodo()
        {
            try
            {
                List<CAdmin> LsAdmi = new List<CAdmin>();
                CAdmin Admin = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd
                   = new SqlCommand("Select * from  Administrador  ", con);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Admin = new CAdmin();
                    Admin.CodigoAdmin = (int)reader["CodigoAdmin"];
                    Admin.Nombre = (string)reader["Nombre"];
                    Admin.DNIAdministrador = (int)reader["DNIAdministrador"];
                    Admin.Usuario = (string)reader["Usuario"];
                    Admin.Contrasena = (string)reader["Contraseña"];
                    LsAdmi.Add(Admin);
                }
                reader.Close();
                return LsAdmi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error pro_ListCadmin " + ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
           
        }


        public DataTable loggearAdmin(String Usuario, string pass)
        {

            try
            {
                
                comando = new SqlCommand("SELECT Nombre ,DNIAdministrador FROM Administrador WHERE Usuario =@usuario AND Contraseña =@pass ", db.ConectaDb());
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

                MessageBox.Show("Errro proclogadmin "+ ex);
                return null;
            }
        }


    }
}