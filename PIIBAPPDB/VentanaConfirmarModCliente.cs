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
    public partial class VentanaConfirmarModCliente : Form
    {
        static SqlConnection conn = DataAccess.getConn();
        SqlCommand comm = null;
        SqlCommand Com = null;
        public VentanaConfirmarModCliente()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentanaConfirmarModCliente_Load(object sender, EventArgs e)
        {
            CenterToParent();
            conn.Open();
            string strComm = "sp_ModificarCliente";
            comm = new SqlCommand(strComm, conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Cedula", MenuClientes.Cedula);
            comm.Parameters.AddWithValue("@PrimerNombre", MenuClientes.PrimerNombre);
            comm.Parameters.AddWithValue("@SegundoNombre", MenuClientes.SegundoNombre);
            comm.Parameters.AddWithValue("@PrimerApellido", MenuClientes.PrimerApellido);
            comm.Parameters.AddWithValue("@SegundoApellido", MenuClientes.SegundoApellido);
            comm.Parameters.AddWithValue("@Direccion", MenuClientes.Direccion);
            comm.Parameters.AddWithValue("@Telefono", MenuClientes.Telefono);
            comm.Parameters.AddWithValue("@Correo", MenuClientes.Correo);
            comm.Parameters.AddWithValue("@NombreEmpresa", MenuClientes.NombreEmpresa);
            comm.Parameters.AddWithValue("@Ruc", MenuClientes.RUC);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("El cliente fue Modificado con éxito");
                this.btnConfirmar.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show(" ¡¡ERROR!!, El cliente ya existe");
                    this.btnConfirmar.Enabled = false;
                }
            }
            conn.Close();
        }
    }
}
