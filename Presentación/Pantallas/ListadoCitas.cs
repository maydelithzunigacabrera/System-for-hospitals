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

namespace Presentación.Pantallas
{
    public partial class ListadoCitas : Form
    {

        nCita nCita = new nCita();
        public ListadoCitas()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListadoCitas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nCita.listartodascitas();
        }
    }
}
