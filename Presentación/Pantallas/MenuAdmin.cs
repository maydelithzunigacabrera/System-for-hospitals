using Presentación.Pantallas;
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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            PSubMenuRegistrar.Visible = false;
            PSubMenuReportes.Visible = false;
        }
        private void hideSubMenu()
        {
            if (PSubMenuRegistrar.Visible == true)
                PSubMenuRegistrar.Visible = false;
            if (PSubMenuReportes.Visible == true)
                PSubMenuReportes.Visible = false;
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

       
        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            showSubMenu(PSubMenuRegistrar);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openContenedor(new RegistrarPaciente());
            hideSubMenu();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openContenedor(new RegistrarAdmin());
            hideSubMenu();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            openContenedor(new Pantallas.RegistrarEspecialidad());
            hideSubMenu();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            openContenedor(new Pantallas.RegistrarDoctor());
            hideSubMenu();
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(PSubMenuReportes);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openContenedor(new ListadoCitas());
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private Form activeForm = null;
        private void openContenedor(Form hijo)
        {
            if(activeForm!=null)
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

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openContenedor(new Pantallas.ListadoCitas());
            hideSubMenu();
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
