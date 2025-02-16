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
    public partial class VentanaConfirmarBorrProd : Form
    {
        SqlConnection conn = DataAccess.getConn();
        private static string strComm = null;
        SqlCommand comm = null;
        public VentanaConfirmarBorrProd()
        {
            InitializeComponent();
        }

        private void VentanaConfirmarBorrProd_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string strCom = "SELECT TOP 1 id_producto FROM Productos where id_producto = '" + MenuProductos.CodigoBarra + "'";
            comm = new SqlCommand(strCom, conn); // Asignar la conexión a comm
            conn.Open(); // Abrir la conexión
            object resultado = comm.ExecuteScalar();
            conn.Close(); // Cerrar la conexión después de usarla
            if (resultado == null)
            {
                MessageBox.Show(" ¡¡ERROR!!, No existe el Producto");

            }
            else
            {
                string deleteCommand = "DELETE FROM Productos WHERE id_producto = '" + MenuProductos.CodigoBarra + "'";
                comm = new SqlCommand(deleteCommand, conn);
                conn.Open();
                int rowsAffected = comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Se a Eliminado el producto con Éxito");
            }
        }
    }
}
