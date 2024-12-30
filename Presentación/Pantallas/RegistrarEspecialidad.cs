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

namespace Presentación.Pantallas
{
    public partial class RegistrarEspecialidad : Form
    {
        nEspecialidad nEspecialidad=new nEspecialidad();
        public RegistrarEspecialidad()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtespecialidad.Text != "")
            {
                nEspecialidad.RegistrarEspecialidad(txtespecialidad.Text);
                txtespecialidad.Clear();

                dataGridView1.DataSource = nEspecialidad.ListarEspecialidad();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtespecialidad.Focus();
        }

        private void RegistrarEspecialidad_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nEspecialidad.ListarEspecialidad();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int NumeroDeFila = dataGridView1.CurrentRow.Index;
            txtespecialidad.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[1].Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtespecialidad.Text != "")
            {
                int NumeroDeFila = dataGridView1.CurrentRow.Index;
                int id = (int)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
                nEspecialidad.ModificarEspecialidad(id,txtespecialidad.Text);
                txtespecialidad.Clear();

                dataGridView1.DataSource = nEspecialidad.ListarEspecialidad();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtespecialidad.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtespecialidad.Text != "")
            {
                int NumeroDeFila = dataGridView1.CurrentRow.Index;
                int id = (int)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
                nEspecialidad.EliminarEspecialidad(id);
                txtespecialidad.Clear();

                dataGridView1.DataSource = nEspecialidad.ListarEspecialidad();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtespecialidad.Focus();
        }
    }
}
