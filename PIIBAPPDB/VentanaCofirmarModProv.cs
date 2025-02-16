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
    public partial class VentanaConfirmarModProv : Form
    {
        static SqlConnection conn = DataAccess.getConn();
        SqlCommand comm = null;
        public VentanaConfirmarModProv()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("El Proveedor fue Modificado con éxito");
                this.btnConfirmar.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show(" ¡¡ERROR!!, El Proveedor ya existe");
                    this.btnConfirmar.Enabled = false;
                }
            }
            conn.Close();
        }

        private void VentanaCofirmarModProv_Load(object sender, EventArgs e)
        {
            CenterToParent();
            conn.Open();
            string strComm = "sp_ModificarProveedor";
            comm = new SqlCommand(strComm, conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Direccion", MenuProveedores.Direccion);
            comm.Parameters.AddWithValue("@Telefono", MenuProveedores.Telefono);
            comm.Parameters.AddWithValue("@Correo", MenuProveedores.Correo);
            comm.Parameters.AddWithValue("@RUC", MenuProveedores.RUC);
            comm.Parameters.AddWithValue("@NombreSede", "Quito");
            comm.Parameters.AddWithValue("@NombreEmpresarial", MenuProveedores.NombreEmpresa);
        }
    }
}
