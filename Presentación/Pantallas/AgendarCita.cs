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
using Negocios;
using Entidades;

namespace Presentación.Pantallas
{
    public partial class AgendarCita : Form
    {
        nCita nCita = new nCita();

        public AgendarCita()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void AgendarCita_Load(object sender, EventArgs e)
        {
            listarespec();

            int a = Convert.ToInt32(label4.Text);


            dataGridView1.DataSource = nCita.listarcitas(a);
        }

        private void listarespec()
        { 
            comboBox1.DataSource = new dEspecialidad().listcomb();
            comboBox1.ValueMember = "IdEspecialidad";
            comboBox1.DisplayMember = "Especialidad";
            
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

        {
            CEspecialidad objselect  =(CEspecialidad)comboBox1.SelectedItem;

            comboBox2.DataSource = new dDoctor().listcomv(objselect.IdEspecialidad);
            comboBox2.ValueMember = "IdDoctor";
            comboBox2.DisplayMember = "Nombre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CDoctor objselect = (CDoctor)comboBox2.SelectedItem;

            nCita.RegistrarCita(Convert.ToInt32(label4.Text), objselect.IdDoctor, dateTimePicker1.Value.ToString("yyyyMMdd"));
                 int a = Convert.ToInt32(label4.Text);


            dataGridView1.DataSource = nCita.listarcitas(a);


            MessageBox.Show("Por favor debe completar todos los datos");
           

        }
    }
}
