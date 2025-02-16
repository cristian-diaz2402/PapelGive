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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIIBAPPDB
{
    public partial class MenuProductos : Form
    {
        public MenuProductos()
        {
            InitializeComponent();
        }
        SqlConnection conn = DataAccess.getConn();
        private static string strComm = null;
        SqlCommand comm = null;
        SqlCommand comma = null;


        public static string CodigoBarra = "";
        public static string NombreProducto = "";
        public static decimal PrecioXpaquete;

        private void MenuProductos_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            int count = 1;
            while (count != 0)
            {
                int numeroAleatorio = random.Next(0, 100000);
                string numeroFormateado = numeroAleatorio.ToString("D5");
                string strC = "SELECT COUNT(*) FROM Productos WHERE id_producto = '" + numeroFormateado + "'";
                comm = new SqlCommand(strC, conn);

                try
                {
                    conn.Open();
                    count = (int)comm.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha surgido un error: " + ex.Message);
                    return;
                }
                finally
                {
                    conn.Close();
                }
                if (count == 0)
                {
                    this.txtCodBarra.Text = numeroFormateado;
                }
            }

            strComm = "sp_BuscarNom_Prod";
            SqlCommand cmd = new SqlCommand(strComm, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", this.txtCajaBuscar.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewProductos.DataSource = tabla;



            EnableUpdateButton();
            dataGridViewProductos.ReadOnly = true;
        }

        private void EnableUpdateButton()
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(txtNomProd.Text) &&
                                   !string.IsNullOrWhiteSpace(txtCodBarra.Text) &&
                                   !string.IsNullOrWhiteSpace(txtPrecio.Text);                                   
            btnAgregar.Enabled = allFieldsFilled;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNomProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es una letra ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
        }

        private void txtNomProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                // Si el carácter no es válido, suprimirlo
                e.Handled = true;
            }
        }

        private void txtCodBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un número ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
            if (txtCodBarra.Text.Length >= 5 && e.KeyChar != '\b')
            {
                // Si tiene 10 o más caracteres y la tecla presionada no es una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, el punto decimal, la tecla de retroceso y la tecla de suprimir
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == ',' && (sender as System.Windows.Forms.TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }

            // Permitir solo dos dígitos después del punto
            if ((sender as System.Windows.Forms.TextBox).Text.Contains(","))
            {
                string[] parts = (sender as System.Windows.Forms.TextBox).Text.Split(',');
                if (parts.Length > 1 && parts[1].Length >= 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un número ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                decimal PrecioXPaquete = decimal.Parse(txtPrecio.Text);
                Form Confirmar = new VentanaConfirmarAddProd();
                NombreProducto = txtNomProd.Text;
                PrecioXpaquete = PrecioXPaquete;
                CodigoBarra = txtCodBarra.Text;
                Confirmar.ShowDialog();

        }

        private void txtNomProd_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtCodBarra_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            strComm = "sp_BuscarNom_Prod";
            SqlCommand cmd = new SqlCommand(strComm, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", this.txtCajaBuscar.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewProductos.DataSource = tabla;
        }

        private void txtCajaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es una letra ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
            if (txtCajaBuscar.Text.Length >= 10 && e.KeyChar != '\b')
            {
                // Si tiene 10 o más caracteres y la tecla presionada no es una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                strComm = "sp_BuscarNom_Prod";
                SqlCommand cmd = new SqlCommand(strComm, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", this.txtCajaBuscar.Text);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridViewProductos.DataSource = tabla;

                txtCajaBuscar.Clear();

                // Evitar que el Enter genere un sonido de "beep"
                e.Handled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool errorEnId2 = false;
            string commando = "SELECT TOP 1 id_producto FROM Productos where id_producto = '" + this.txtCodBarra.Text + "'";
            comm = new SqlCommand(commando, conn); // Asignar la conexión a comm
            conn.Open(); // Abrir la conexión
            object respuesta = comm.ExecuteScalar();
            conn.Close(); // Cerrar la conexión después de usarla
            if (respuesta == null)
            {
                MessageBox.Show(" ¡¡ERROR!!, No puedes modificar el codigo de barras");
                errorEnId2 = true;
            }
            if (!errorEnId2)
            {
                decimal PrecioXPaquete = decimal.Parse(txtPrecio.Text);
                Form Confirmar = new VentanaConfirmarModProd();
                NombreProducto = txtNomProd.Text;
                PrecioXpaquete = PrecioXPaquete;
                CodigoBarra = txtCodBarra.Text;
                Confirmar.ShowDialog();
            }
        }

        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNomProd.Text = dataGridViewProductos.SelectedCells[1].Value.ToString();
            txtCodBarra.Text = dataGridViewProductos.SelectedCells[0].Value.ToString();
            txtPrecio.Text = dataGridViewProductos.SelectedCells[2].Value.ToString();
        }

        private void dataGridViewProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                // Habilitar el botón si se ha seleccionado una fila
                btnModificar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Form Confirmar = new VentanaConfirmarBorrProd();
            CodigoBarra = txtCodBarra.Text;
            Confirmar.ShowDialog();
        }

        private void txtCajaBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int count = 1;
            while (count != 0)
            {
                int numeroAleatorio = random.Next(0, 100000);
                string numeroFormateado = numeroAleatorio.ToString("D5");
                string strC = "SELECT COUNT(*) FROM Productos WHERE id_producto = '" + numeroFormateado + "'";
                comm = new SqlCommand(strC, conn);

                try
                {
                    conn.Open();
                    count = (int)comm.ExecuteScalar();
                } catch (Exception ex)
                {
                    MessageBox.Show("Ha surgido un error: "+ex.Message);
                    return;
                }finally
                {
                    conn.Close();
                }
                if (count == 0)
                {
                    this.txtCodBarra.Text = numeroFormateado;
                    this.txtNomProd.Clear();
                    this.txtPrecio.Clear();
                }
                
             }
        }



        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
