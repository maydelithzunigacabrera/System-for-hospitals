using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentación
{
    public partial class RegistrarPaciente : Form
    {
        nPaciente nPaciente = new nPaciente();

        public RegistrarPaciente()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtdni.Text!="" && txtnombre.Text!=""&&txtdistrito.Text!=""&&txtdirecc.Text!=""&&txtnombre.Text!=""&&txtpass.Text!="")
            {
                nPaciente.RegistrarPaciente(Convert.ToInt32(txtdni.Text), txtnombre.Text, dateTimePicker1.Value.ToString("yyyyMMdd")
               , txtdistrito.Text, txtdirecc.Text, txtusuario.Text, txtpass.Text, dateTimePicker2.Value.ToString("yyyyMMdd"));
                dataGridView1.DataSource = nPaciente.ListarPacientes();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();


        }

        private void RegistrarPaciente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nPaciente.ListarPacientes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtdni.Text != "" && txtnombre.Text != "" && txtdistrito.Text != "" && txtdirecc.Text != "" && txtnombre.Text != "" && txtpass.Text != "")
            {
                //int NumeroDeFila = dataGridView1.CurrentRow.Index;
                //int a;
                //a = (int)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
                nPaciente.ModificarPaciente(Convert.ToInt32(txtdni.Text),txtnombre.Text, dateTimePicker1.Value.ToString("yyyyMMdd"), txtdistrito.Text,txtdirecc.Text,txtusuario.Text,txtpass.Text, dateTimePicker2.Value.ToString("yyyyMMdd"));


                dataGridView1.DataSource = nPaciente.ListarPacientes();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            int NumeroDeFila = dataGridView1.CurrentRow.Index;
            int a;
            a = (int)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
            txtdni.Text = "" + a;
            txtnombre.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[1].Value;
            //dateTimePicker1.Text= dataGridView1.Rows[NumeroDeFila].Cells[2].Value.ToString();
            txtdistrito.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[3].Value;
            txtdirecc.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[4].Value;
            txtusuario.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[5].Value;
            txtpass.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[6].Value;
            //dateTimePicker2.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[7].Value;

            //dataGridView1.DataSource = nPaciente.ListarPacientes();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtdni.Text != "" && txtnombre.Text != "" && txtdistrito.Text != "" && txtdirecc.Text != "" && txtnombre.Text != "" && txtpass.Text != "")
            {
                int NumeroDeFila = dataGridView1.CurrentRow.Index;
                int DNI = (int)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
                nPaciente.EliminarPaciente(DNI);
                dataGridView1.DataSource = nPaciente.ListarPacientes();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();
        }
    }
}
