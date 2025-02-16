using System;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using System.Linq;

namespace PIIBAPPDB
{
    public partial class MenuBotones : Form
    {
        private string Valor;
        public MenuBotones()
        {
            InitializeComponent();
        }

        private void MenuBotones_Load(object sender, EventArgs e)
        {

        }

        private void btnClients_Click_1(object sender, EventArgs e)
        {

                MenuClientes MC = new MenuClientes();
                AddOwnedForm(MC);
                MC.FormBorderStyle = FormBorderStyle.None;
                MC.TopLevel = false;
                MC.Dock = DockStyle.Fill;
                this.Controls.Add(MC);
                this.Tag = MC;
                MC.BringToFront();
                MC.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.txtRol.Text == "Administrador")
            {
                MenuEmpleados ME = new MenuEmpleados();
                AddOwnedForm(ME);
                ME.FormBorderStyle = FormBorderStyle.None;
                ME.TopLevel = false;
                ME.Dock = DockStyle.Fill;
                this.Controls.Add(ME);
                this.Tag = ME;
                ME.BringToFront();
                ME.Show();
            }
            if (this.txtRol.Text == "Empleado")
            {
                MessageBox.Show("Acceso solo Administradores");
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtRol.Text == "Administrador")
            {
                MenuProveedores MP = new MenuProveedores();
                AddOwnedForm(MP);
                MP.FormBorderStyle = FormBorderStyle.None;
                MP.TopLevel = false;
                MP.Dock = DockStyle.Fill;
                this.Controls.Add(MP);
                this.Tag = MP;
                MP.BringToFront();
                MP.Show();
            }
            if (this.txtRol.Text == "Empleado")
            {
                MessageBox.Show("Acceso solo Administradores");
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPedid_Click(object sender, EventArgs e)
        {
            MenuCompras MP = new MenuCompras();
            AddOwnedForm(MP);
            MP.FormBorderStyle = FormBorderStyle.None;
            MP.TopLevel = false;
            MP.Dock = DockStyle.Fill;
            this.Controls.Add(MP);
            this.Tag = MP;
            MP.BringToFront();
            MP.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            MenuCaja MC = new MenuCaja();
            AddOwnedForm(MC);
            MC.FormBorderStyle = FormBorderStyle.None;
            MC.TopLevel = false;
            MC.Dock = DockStyle.Fill;
            this.Controls.Add(MC);
            this.Tag = MC;
            MC.BringToFront();
            MC.txtrol.Text = this.txtRol.Text;
            MC.txtUs.Text = this.txtU.Text;
            MC.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            MenuProductos MC = new MenuProductos();
            AddOwnedForm(MC);
            MC.FormBorderStyle = FormBorderStyle.None;
            MC.TopLevel = false;
            MC.Dock = DockStyle.Fill;
            this.Controls.Add(MC);
            this.Tag = MC;
            MC.BringToFront();
            MC.Show();
        }

        private void txtq_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            MenuSolicitudes MS = new MenuSolicitudes();
            AddOwnedForm(MS);
            MS.FormBorderStyle = FormBorderStyle.None;
            MS.TopLevel = false;
            MS.Dock = DockStyle.Fill;
            this.Controls.Add(MS);
            this.Tag = MS;
            MS.BringToFront();
            MS.Show();
        }

    }
}
