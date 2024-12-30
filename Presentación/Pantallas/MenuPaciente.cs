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
    public partial class MenuPaciente : Form
    {
        public MenuPaciente()
        {
            InitializeComponent();

        }
        private void customizeDesing()
        {
            PSubMenuRegistrar.Visible = false;

        }
        private void hideSubMenu()
        {
            if (PSubMenuRegistrar.Visible == true)
                PSubMenuRegistrar.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            showSubMenu(PSubMenuRegistrar);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openContenedor(new Form1());
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Form activeForm = null;
        private void openContenedor(Form hijo)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = hijo;
            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(hijo);
            panelContenedor.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            AgendarCita AgendarCita = new AgendarCita();
            AgendarCita.label5.Text = label1.Text;
            AgendarCita.label4.Text = label2.Text;
            openContenedor(AgendarCita);

            hideSubMenu();
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
