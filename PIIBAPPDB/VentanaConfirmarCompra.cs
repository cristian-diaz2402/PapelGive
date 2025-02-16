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
    public partial class VentanaConfirmarCompra : Form
    {
        static SqlConnection conn = DataAccess.getConn();
        SqlCommand comm = null;
        SqlCommand com = null;
        SqlCommand co = null;
        public VentanaConfirmarCompra()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                
                comm.ExecuteNonQuery();
                com.ExecuteNonQuery();
                co.ExecuteNonQuery();
                MessageBox.Show("La compra fue realizada exitosamente");
                this.btnConfirmar.Enabled = false;

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show(" ¡¡ERROR!!, La compra ya existe");
                    this.btnConfirmar.Enabled = false;
                }
            }
            conn.Close();
        }
        
        private void VentanaConfirmarCompra_Load(object sender, EventArgs e)
        {
            conn.Close();
            Random random = new Random();
            double numeroAleatorio = random.NextDouble() * 99 + 1;
            double VxP = Math.Round(numeroAleatorio, 2);

            double cant = int.Parse(MenuCompras.Cantidad);
            double cantidad = Math.Round(cant, 2);

            double total1 = (cantidad * VxP);
            double semitotal = Math.Round(total1, 2);

            double iv = (semitotal * 12) / 100;
            double iva = Math.Round(iv, 2);

            double total2 = (semitotal + iva);
            double totalfinal = Math.Round(total2, 2);

            txtIva.Text = iva.ToString();
            txtPrecioPaquete.Text = VxP.ToString();
            txtCostoPrevio.Text = semitotal.ToString();
            txtCantidad.Text = cantidad.ToString();
            txtMontoTotal.Text = totalfinal.ToString();
            CenterToParent();
            conn.Open();

            decimal Totaldodecimal = decimal.Parse(txtMontoTotal.Text);
            decimal IvaDecimal = decimal.Parse(txtIva.Text);
            string strComm = "sp_Comprar";
            comm = new SqlCommand(strComm, conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@NumeroOrden", MenuCompras.NumeroOrden);
            comm.Parameters.AddWithValue("@Total", Totaldodecimal);
            comm.Parameters.AddWithValue("@IVA", IvaDecimal);
            comm.Parameters.AddWithValue("@Fecha", MenuCompras.Fecha);
            comm.Parameters.AddWithValue("@ModoPago", MenuCompras.ModoPago);

            string Comm = "sp_ItemC";
            com = new SqlCommand(Comm, conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cantidad", MenuCompras.Cantidad);
            com.Parameters.AddWithValue("@NumeroOrden", MenuCompras.NumeroOrden);
            com.Parameters.AddWithValue("@CodigoBarras", MenuCompras.CodigoBarra);
            com.Parameters.AddWithValue("@RUC", MenuCompras.RUC);


            int canti = int.Parse(MenuCompras.Cantidad);
            string Com = "sp_actualizarCantProducto";
            co = new SqlCommand(Com, conn);
            co.CommandType = CommandType.StoredProcedure;
            co.Parameters.AddWithValue("@CodigoBarra", MenuCompras.CodigoBarra);
            co.Parameters.AddWithValue("@Cantidad", canti);




        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();

        }
    }
}
