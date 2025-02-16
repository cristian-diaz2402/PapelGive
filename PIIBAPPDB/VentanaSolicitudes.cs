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
    public partial class MenuSolicitudes : Form
    {
        public MenuSolicitudes()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSoliCompra_Click(object sender, EventArgs e)
        {
            MenuCompras MC = new MenuCompras();
            AddOwnedForm(MC);
            MC.FormBorderStyle = FormBorderStyle.None;
            MC.TopLevel = false;
            MC.Dock = DockStyle.Fill;
            this.Controls.Add(MC);
            this.Tag = MC;
            MC.BringToFront();
            MC.Show();
        }

        private void btnSoliVenta_Click(object sender, EventArgs e)
        {
            MenuVentas MV = new MenuVentas();
            AddOwnedForm(MV);
            MV.FormBorderStyle = FormBorderStyle.None;
            MV.TopLevel = false;
            MV.Dock = DockStyle.Fill;
            this.Controls.Add(MV);
            this.Tag = MV;
            MV.BringToFront();
            MV.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            VentanaRegistroCajas MC = new VentanaRegistroCajas();
            AddOwnedForm(MC);
            MC.FormBorderStyle = FormBorderStyle.None;
            MC.TopLevel = false;
            MC.Dock = DockStyle.Fill;
            this.Controls.Add(MC);
            this.Tag = MC;
            MC.BringToFront();
            MC.Show();
        }
    }
}
