using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIIBAPPDB
{
    public partial class VentanaSedes : Form
    {
        public VentanaSedes()
        {
            InitializeComponent();
        }

        private void cmbSedes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSedes.SelectedItem.ToString() == "Quito")
            {
                VentanaIniciarSecion VIS = new VentanaIniciarSecion();
                VIS.ShowDialog();
            } else
            {
                MessageBox.Show("Disponible Proximamente...");
                
            }
        }

        private void VentanaSedes_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
