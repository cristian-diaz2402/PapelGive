using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PIIBAPPDB
{
    public partial class VentanaConfirmarVenta : Form
    {
        SqlConnection conn = null;
        SqlCommand commm = null;
        SqlCommand comm = null;
        SqlCommand com = null;
        SqlCommand co = null;

        public VentanaConfirmarVenta()
        {
            InitializeComponent();
            conn = DataAccess.getConn();
            comm = new SqlCommand();
            com = new SqlCommand();
            co = new SqlCommand();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Totaldodecimal = decimal.Parse(txtMontoTotal.Text);
                decimal IvaDecimal = decimal.Parse(txtIva.Text);
                int canti = int.Parse(MenuVentas.Cantidad);

                // Configura y ejecuta el procedimiento almacenado sp_Vender
                string strComm = "sp_Vender";
                comm = new SqlCommand(strComm, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@NumeroFactura", MenuVentas.NumeroFactura);
                comm.Parameters.AddWithValue("@Total", Totaldodecimal);
                comm.Parameters.AddWithValue("@IVA", IvaDecimal);
                comm.Parameters.AddWithValue("@Fecha", MenuVentas.Fecha);
                comm.Parameters.AddWithValue("@CI", MenuVentas.CedulaRUC);
                comm.Parameters.AddWithValue("@ModoPago", MenuVentas.ModoPago);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();

                // Configura y ejecuta el procedimiento almacenado sp_ItemV
                string Comm = "sp_ItemV";
                com = new SqlCommand(Comm, conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Cantidad", canti);
                com.Parameters.AddWithValue("@NumeroFactura", MenuVentas.NumeroFactura);
                com.Parameters.AddWithValue("@CodigoBarra", MenuVentas.CodigoBarra);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();

                // Configura y ejecuta el procedimiento almacenado sp_actualizarCantProductoV
                string Com = "sp_actualizarCantProductoV";
                co = new SqlCommand(Com, conn);
                co.CommandType = CommandType.StoredProcedure;
                co.Parameters.AddWithValue("@CodigoBarra", MenuVentas.CodigoBarra);
                co.Parameters.AddWithValue("@Cantidad", canti);
                conn.Open();
                co.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("La venta fue realizada exitosamente");
                this.btnConfirmar.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("¡¡ERROR!!, El cliente no existe");
                    this.btnConfirmar.Enabled = false;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        private void VentanaConfirmarVenta_Load(object sender, EventArgs e)
        {
            conn.Close();

            string strCom = "SELECT TOP 1 precio_porPaq FROM Productos where id_producto = '" + MenuVentas.CodigoBarra + "'";
            commm = new SqlCommand(strCom, conn);
            conn.Open();
            object resultado = commm.ExecuteScalar();
            conn.Close();
            double VxP = Convert.ToDouble(resultado);
            double cantidad = Convert.ToDouble(MenuVentas.Cantidad);

            double total1 = (cantidad * VxP);
            double semitotal = Math.Round(total1, 2);
            double iv = (semitotal * 12) / 100;
            double iva = Math.Round(iv, 2);
            double total2 = semitotal + iva;
            double totalfinal = Math.Round(total2, 2);

            txtIva.Text = iva.ToString();
            txtPrecioPaquete.Text = VxP.ToString();
            txtCostoPrevio.Text = semitotal.ToString();
            txtCantidad.Text = cantidad.ToString();
            txtMontoTotal.Text = totalfinal.ToString();
            CenterToParent();
        }
    }
}
