using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIIBAPPDB
{
    public partial class VentanaRegistroCajas : Form
    {
        SqlConnection conn = DataAccess.getConn();
        private static string strComm = null;
        SqlCommand comm = null;
        public VentanaRegistroCajas()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            conn.Close();
            bool errorbus = false;
            bool errorfecha = false;
            string formatoFecha = "yyyy-MM-dd";
            // Validación del número de factura
            if (!DateTime.TryParseExact(txtCajaBuscar.Text, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                // La fecha ingresada tiene el formato correcto
                MessageBox.Show("Fecha invalida, debe tener el formato yyyy-MM-dd");
                errorfecha = true;
            }
                if (!errorbus && !errorfecha && DateTime.TryParseExact(txtCajaBuscar.Text, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaValidada))
                {
                    string fecha = fechaValidada.ToString("yyyy-MM-dd");
                    strComm = "sp_BuscarCaja";
                    SqlCommand cmd = new SqlCommand(strComm, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("fecha", fecha);
                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dataGridViewCajas.DataSource = tabla;
                }
            }
        

        private void txtCajaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter && string.IsNullOrEmpty(txtCajaBuscar.Text))
            {
                string strComm = "sp_MostrarCajas";
                SqlCommand cmd = new SqlCommand(strComm, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridViewCajas.DataSource = tabla;
                conn.Close();
                txtCajaBuscar.Clear();

                // Evitar que el Enter genere un sonido de "beep"
                e.Handled = true;
            }
            }

        private void txtCajaBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void VentanaRegistroCajas_Load(object sender, EventArgs e)
        {
            string strComm = "sp_MostrarCajas";
            SqlCommand cmd = new SqlCommand(strComm, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewCajas.DataSource = tabla;
            dataGridViewCajas.ReadOnly = true;
        }
    }
}

