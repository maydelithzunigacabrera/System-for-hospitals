using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocios;

namespace Presentación
{
    public partial class RegistrarAdmin : Form
    {
        nAdmin nAdmin = new nAdmin();
        CAdmin Adminseleccionado = null;
        int codadmin;
        public RegistrarAdmin()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && txtdni.Text != "" && txtusuario.Text != "" && txtcontrasena.Text != "")
            {
                nAdmin.RegistrarAdmin(txtnombre.Text, Convert.ToInt32(txtdni.Text), txtusuario.Text, txtcontrasena.Text);
                txtnombre.Clear();
                txtdni.Clear();
                txtusuario.Clear();
                txtcontrasena.Clear();

                dataGridView1.DataSource = nAdmin.ListarAdmin();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && txtdni.Text != "" && txtusuario.Text != "" && txtcontrasena.Text != "")
            {
                int NumeroDeFila = dataGridView1.CurrentRow.Index;
                int id = (int)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
                nAdmin.ModificarAdmin(id,txtnombre.Text, Convert.ToInt32(txtdni.Text), txtusuario.Text, txtcontrasena.Text);
                txtnombre.Clear();
                txtdni.Clear();
                txtusuario.Clear();
                txtcontrasena.Clear();

                dataGridView1.DataSource = nAdmin.ListarAdmin();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void RegistrarAdmin_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nAdmin.ListarAdmin();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
          
            //aqui
            int NumeroDeFila = dataGridView1.CurrentRow.Index;
            int a ;
            txtnombre.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[1].Value;
            a = (int)dataGridView1.Rows[NumeroDeFila].Cells[2].Value;
            txtdni.Text = ""+a;
            txtusuario.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[3].Value;
            txtcontrasena.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[4].Value;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && txtdni.Text != "" && txtusuario.Text != "" && txtcontrasena.Text != "")
            {
                int NumeroDeFila = dataGridView1.CurrentRow.Index;
                int id = (int)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
                nAdmin.EliminarAdmin(id);
                txtnombre.Clear();
                txtdni.Clear();
                txtusuario.Clear();
                txtcontrasena.Clear();

                dataGridView1.DataSource = nAdmin.ListarAdmin();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();
        }
    }
}
