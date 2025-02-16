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
    public partial class MenuProveedores : Form
    {

        public MenuProveedores()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EnableUpdateButton()
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                                   !string.IsNullOrWhiteSpace(txtDir.Text) &&
                                   !string.IsNullOrWhiteSpace(txtNomEmpresa.Text) &&
                                   !string.IsNullOrWhiteSpace(txtRUC.Text) &&
                                   !string.IsNullOrWhiteSpace(txtTelef.Text);
            btnAgregar.Enabled = allFieldsFilled;
        }
        public static string Correo = "";
        public static string Telefono = "";
        public static string NombreEmpresa = "";
        public static string RUC = "";
        public static string Direccion = "";

        SqlConnection conn = DataAccess.getConn();
        private static string strComm = null;
        SqlCommand comm = null;
        private void txtNomEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                // Si el carácter no es válido, suprimirlo
                e.Handled = true;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '\b')
            {
                // Si el carácter no es válido, suprimirlo
                e.Handled = true;
            }
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un número ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
            if (txtRUC.Text.Length >= 13 && e.KeyChar != '\b')
            {
                // Si tiene 10 o más caracteres y la tecla presionada no es una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
        }

        private void txtTelef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un número ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
            if (txtTelef.Text.Length >= 10 && e.KeyChar != '\b')
            {
                // Si tiene 10 o más caracteres y la tecla presionada no es una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
        }

        private void txtDir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                // Si el carácter no es válido, suprimirlo
                e.Handled = true;
            }
        }

        private void MenuProveedores_Load(object sender, EventArgs e)
        {
            strComm = "sp_BuscarNom_Prov";
            SqlCommand cmd = new SqlCommand(strComm, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Buscar", "");
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewProveedores.DataSource = tabla;



            EnableUpdateButton();
            dataGridViewProveedores.ReadOnly = true;
        }

        private void txtNomEmpresa_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtRUC_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtTelef_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtDir_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtCajaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ' && e.KeyChar != '_' && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es una letra ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
            if (txtCajaBuscar.Text.Length >= 13 && e.KeyChar != '\b')
            {
                // Si tiene 10 o más caracteres y la tecla presionada no es una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {

                SqlCommand cmd = new SqlCommand("sp_BuscarNom_Prov", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Buscar", this.txtCajaBuscar.Text);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridViewProveedores.DataSource = tabla;
                conn.Close();

                // Evitar que el Enter genere un sonido de "beep"
                e.Handled = true;
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            strComm = "sp_BuscarNom_Prov";
            SqlCommand cmd = new SqlCommand(strComm, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Buscar", this.txtCajaBuscar.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewProveedores.DataSource = tabla;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool errorEnTelefono = false;
            bool errorEnRUC = false;


            string input = txtTelef.Text;
            // Verificar si los dos primeros caracteres no son "09"
            if (input.Length < 2 || input.Substring(0, 2) != "09" || input.Length != 10)
            {
                // Si los dos primeros caracteres no son "09", mostrar un mensaje de error
                MessageBox.Show("El numero celular es invalido, debe comenzar con 09 y tener 10 digitos");
                errorEnTelefono = true;
            }
            if (this.txtRUC.Text.Length != 13)
            {
                MessageBox.Show("Numero de RUC invalido, debe contener 13 digitos");
                errorEnRUC = true;
            }
            if (!errorEnTelefono && !errorEnRUC)
            {
                Form Confirmar = new VentanaConnfirmarAddProv();
                Correo = txtCorreo.Text;
                Telefono = txtTelef.Text;
                NombreEmpresa = txtNomEmpresa.Text;
                RUC = txtRUC.Text;
                Direccion = txtDir.Text;
                Confirmar.ShowDialog();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool errorEnTelefono = false;
            bool errorEnRUC = false;
            bool errorEnId = false;


            string input = txtTelef.Text;
            // Verificar si los dos primeros caracteres no son "09"
            if (input.Length < 2 || input.Substring(0, 2) != "09" || input.Length != 10)
            {
                // Si los dos primeros caracteres no son "09", mostrar un mensaje de error
                MessageBox.Show("El numero celular es invalido, debe comenzar con 09 y tener 10 digitos");
                errorEnTelefono = true;
            }
            if (this.txtRUC.Text.Length != 13)
            {
                MessageBox.Show("Numero de RUC invalido, debe contener 13 digitos");
                errorEnRUC = true;
            }
            string strCom = "SELECT TOP 1 id_proveedor FROM Proveedores where id_proveedor = '" + this.txtRUC.Text + "'";
            comm = new SqlCommand(strCom, conn); // Asignar la conexión a comm
            conn.Open(); // Abrir la conexión
            object resultado = comm.ExecuteScalar();
            conn.Close(); // Cerrar la conexión después de usarla
            if (resultado == null)
            {
                MessageBox.Show(" ¡¡ERROR!!, no puedes modificar el RUC");
                errorEnId = true;
            }
            if (!errorEnTelefono && !errorEnRUC && !errorEnId)
            {
                Form Confirmar = new VentanaConfirmarModProv();
                Correo = txtCorreo.Text;
                Telefono = txtTelef.Text;
                NombreEmpresa = txtNomEmpresa.Text;
                RUC = txtRUC.Text;
                Direccion = txtDir.Text;
                Confirmar.ShowDialog();
            }
        }

        private void dataGridViewProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtNomEmpresa.Text = dataGridViewProveedores.SelectedCells[0].Value.ToString();
            txtRUC.Text = dataGridViewProveedores.SelectedCells[1].Value.ToString();
            txtTelef.Text = dataGridViewProveedores.SelectedCells[2].Value.ToString();
            txtCorreo.Text = dataGridViewProveedores.SelectedCells[3].Value.ToString();
            txtDir.Text = dataGridViewProveedores.SelectedCells[4].Value.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Form Confirmar = new VentanaConfirmarBorrProv();
            RUC = txtRUC.Text;
            Confirmar.ShowDialog();
        }

        private void dataGridViewProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProveedores.SelectedRows.Count > 0)
            {
                // Habilitar el botón si se ha seleccionado una fila
                btnModificar.Enabled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNomEmpresa.Clear();
            txtRUC.Clear();
            txtTelef.Clear();
            txtCorreo.Clear();
            txtDir.Clear();
        }
    }
}