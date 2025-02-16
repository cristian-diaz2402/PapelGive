using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIIBAPPDB
{
    public partial class VentanaRegistroVentas : Form
    {
        SqlConnection conn = DataAccess.getConn();
        private static string strComm = null;
        SqlCommand comm = null;
        SqlCommand com = null;
        public VentanaRegistroVentas()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            strComm = "sp_BuscarNumFact";
            SqlCommand cmd = new SqlCommand(strComm, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Buscar", this.txtCajaBuscar.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewVentas.DataSource = tabla;
        }

        private void txtCajaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es una letra ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                strComm = "sp_BuscarNumFact";
                SqlCommand cmd = new SqlCommand(strComm, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Buscar", this.txtCajaBuscar.Text);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridViewVentas.DataSource = tabla;

                txtCajaBuscar.Clear();
            }
        }

        private void VentanaRegistroVentas_Load(object sender, EventArgs e)
        {
            strComm = "sp_BuscarNumFact";
            SqlCommand cmd = new SqlCommand(strComm, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Buscar", "");
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewVentas.DataSource = tabla;
            dataGridViewVentas.ReadOnly = true;
        }
    }
}
