using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIIBAPPDB
{
    public partial class MenuCaja : Form
    {
        public MenuCaja()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuCierreCaja MCC = new MenuCierreCaja();
            AddOwnedForm(MCC);
            MCC.FormBorderStyle = FormBorderStyle.None;
            MCC.TopLevel = false;
            MCC.Dock = DockStyle.Fill;
            this.Controls.Add(MCC);
            this.Tag = MCC;
            MCC.BringToFront();
            MCC.txtUsuario.Text = this.txtUs.Text;
            MCC.Show();
        }

        private void btnSolicitudes_Click(object sender, EventArgs e)
        {



            if (this.txtrol.Text == "Administrador")
            {
                VentanaRegistroCajas MCC = new VentanaRegistroCajas();
                AddOwnedForm(MCC);
                MCC.FormBorderStyle = FormBorderStyle.None;
                MCC.TopLevel = false;
                MCC.Dock = DockStyle.Fill;
                this.Controls.Add(MCC);
                this.Tag = MCC;
                MCC.BringToFront();
                MCC.Show();
            }
            if (this.txtrol.Text == "Empleado")
            {
                MessageBox.Show("Acceso solo Administradores");
            }

        }

        private void txtUs_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrosCompras_Click(object sender, EventArgs e)
        {
            VentanaRegistroCompras MCC = new VentanaRegistroCompras();
            AddOwnedForm(MCC);
            MCC.FormBorderStyle = FormBorderStyle.None;
            MCC.TopLevel = false;
            MCC.Dock = DockStyle.Fill;
            this.Controls.Add(MCC);
            this.Tag = MCC;
            MCC.BringToFront();
            MCC.Show();
        }

        private void btnRegistrosVentas_Click(object sender, EventArgs e)
        {
            VentanaRegistroVentas MCC = new VentanaRegistroVentas();
            AddOwnedForm(MCC);
            MCC.FormBorderStyle = FormBorderStyle.None;
            MCC.TopLevel = false;
            MCC.Dock = DockStyle.Fill;
            this.Controls.Add(MCC);
            this.Tag = MCC;
            MCC.BringToFront();
            MCC.Show();
        }
    }
}
