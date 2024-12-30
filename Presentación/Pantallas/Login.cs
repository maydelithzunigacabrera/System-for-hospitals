using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using System.Data.SqlClient;
using Negocios;

namespace Presentación.Pantallas
{
    public partial class Login : Form
    {

        Database db = new Database();
        nAdmin nAdmin = new nAdmin();
        nPaciente nPaciente = new nPaciente();


        public Login()
        {
            InitializeComponent();
           
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           

            if (nAdmin.loggearAdmin(textBox1.Text, textBox2.Text) != null)
            {
                dataGridView1.DataSource = nAdmin.loggearAdmin(textBox1.Text, textBox2.Text);
                if (dataGridView1.RowCount >= 0)

                {
                    MessageBox.Show("ingresaste al sistema");
                    String nombre = (string)dataGridView1.Rows[0].Cells[0].Value;
                    string dni = "" + (int)dataGridView1.Rows[0].Cells[1].Value;
                    MenuAdmin MenuAdmin = new MenuAdmin();
                    MenuAdmin.label1.Text = nombre;
                    MenuAdmin.label2.Text = dni;
                    this.Hide();
                    MenuAdmin.Show();

                }
            }      
            
           
             if (nPaciente.loggearPACIENTE(textBox1.Text, textBox2.Text)!=null)
            {

                dataGridView1.DataSource = nPaciente.loggearPACIENTE(textBox1.Text, textBox2.Text);
                if (dataGridView1.RowCount >= 0)
                {
                    MessageBox.Show("ingresaste al sistema");
                    String nombre = (string)dataGridView1.Rows[0].Cells[0].Value;
                    string dni = "" + (int)dataGridView1.Rows[0].Cells[1].Value;
                    MenuPaciente MenuPaciente = new MenuPaciente();
                    MenuPaciente.label1.Text = nombre;
                    MenuPaciente.label2.Text = dni;
                    this.Hide();
                    MenuPaciente.Show();
                }
            }

            //if(dataGridView1.RowCount==0) {

            //    MessageBox.Show("clave y/o usuario incorrect ");

            //}
                
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
