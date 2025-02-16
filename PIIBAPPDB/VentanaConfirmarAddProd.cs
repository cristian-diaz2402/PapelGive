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
    public partial class VentanaConfirmarAddProd : Form
    {
        public VentanaConfirmarAddProd()
        {
            InitializeComponent();
        }
        static SqlConnection conn = DataAccess.getConn();
        SqlCommand comm = null;
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("El Producto fue ingresado con éxito");
                this.btnConfirmar.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show(" ¡¡ERROR!!, El Producto ya existe");
                    this.btnConfirmar.Enabled = false;
                }
            }
            conn.Close();
        }

        private void VentanaConfirmarAddProd_Load(object sender, EventArgs e)
        {
            CenterToParent();
            conn.Open();
            string strComm = "sp_InsertarProductos";
            comm = new SqlCommand(strComm, conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@NombreProducto", MenuProductos.NombreProducto);
            comm.Parameters.AddWithValue("@CodigoBarra", MenuProductos.CodigoBarra);
            comm.Parameters.AddWithValue("@PrecioPaquete", MenuProductos.PrecioXpaquete);
        }
    }
}
