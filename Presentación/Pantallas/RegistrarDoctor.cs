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
using Entidades;
using Negocios;

namespace Presentación.Pantallas
{
    public partial class RegistrarDoctor : Form
    {
        nDoctor nDoctor = new nDoctor();
        private nEspecialidad gespecialidad = new nEspecialidad();
        nEspecialidad nEspecialidad = new nEspecialidad();
        int seleccion =0;
        CEspecialidad especialidad = null;
        public RegistrarDoctor()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarDoctor_Load(object sender, EventArgs e)
        {
            listarespec();
            dataGridView1.DataSource = nDoctor.ListDoctor();
          
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && cbespecialidad.SelectedIndex != -1)
            {
                nDoctor.RegistrarDoctor(txtnombre.Text, seleccion);
                txtnombre.Clear();
                //cbespecialidad.SelectedIndex = -1;
                txtnombre.Clear();


                //dataGridView1.DataSource = nDoctor.ListarDoctores();
                dataGridView1.DataSource = nDoctor.ListDoctor();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && cbespecialidad.SelectedIndex != -1)
            {
                int NumeroDeFila = dataGridView1.CurrentRow.Index;
                int id = (int)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
                nDoctor.ModificarDoctor(id,txtnombre.Text, Convert.ToInt32(cbespecialidad.Text));
                txtnombre.Clear();
                cbespecialidad.SelectedIndex = -1;
                txtnombre.Clear();


                dataGridView1.DataSource = nDoctor.ListarDoctores();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
            {
                int NumeroDeFila = dataGridView1.CurrentRow.Index;
            int a;

          
                txtnombre.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
                
                cbespecialidad.Text = (string)dataGridView1.Rows[NumeroDeFila].Cells[1].Value;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && cbespecialidad.SelectedIndex != -1)
            {
                int NumeroDeFila = dataGridView1.CurrentRow.Index;
                int id = (int)dataGridView1.Rows[NumeroDeFila].Cells[0].Value;
                nDoctor.EliminarDoctor(id);
                txtnombre.Clear();
                cbespecialidad.SelectedIndex = -1;
                txtnombre.Clear();


                dataGridView1.DataSource = nDoctor.ListarDoctores();
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtnombre.Focus();
        }

        private void cbespecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            CEspecialidad selleccion = (CEspecialidad)cbespecialidad.SelectedItem;
            //especialidad = cbespecialidad.SelectedItem as CEspecialidad;
            seleccion = selleccion.IdEspecialidad;
            //MessageBox.Show("P " + selleccion.IdEspecialidad);
        }
        private void listarespec() {


            cbespecialidad.DataSource = new dEspecialidad().listcomb();
            cbespecialidad.ValueMember = "IdEspecialidad";
            cbespecialidad.DisplayMember = "Especialidad"; 
        }
    }
}
