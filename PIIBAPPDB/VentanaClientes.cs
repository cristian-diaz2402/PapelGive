using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIIBAPPDB
{
    public partial class MenuClientes : Form
    {

        public MenuClientes()
        {
            InitializeComponent();
        }
        public static string PrimerNombre = "";
        public static string SegundoNombre = "";
        public static string PrimerApellido = "";
        public static string SegundoApellido = "";
        public static string Cedula = "";
        public static string Correo = "";
        public static string Telefono = "";
        public static string NombreEmpresa = "";
        public static string RUC = "";
        public static string Direccion = "";

        private void MenuClientes_Load(object sender, EventArgs e)
        {
            strComm = "sp_BuscarNom_Cli";
            SqlCommand cmd = new SqlCommand(strComm, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Buscar", "");
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewClientes.DataSource = tabla;
            EnableUpdateButton();
            dataGridViewClientes.ReadOnly = true;

        }
        SqlConnection conn = DataAccess.getConn();
        private static string strComm = null;
        SqlCommand comm = null;

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            strComm = "sp_BuscarNom_Cli";
            SqlCommand cmd = new SqlCommand(strComm, conn);
            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@Buscar", this.txtCajaBuscar.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridViewClientes.DataSource = tabla;
            
        }

        private void txtCajaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
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
                strComm = "sp_BuscarNom_Cli";
                SqlCommand cmd = new SqlCommand("sp_BuscarNom_Cli", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Buscar", this.txtCajaBuscar.Text);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridViewClientes.DataSource = tabla;
                conn.Close();

                // Evitar que el Enter genere un sonido de "beep"
                e.Handled = true;
            }

        }
        private void EnableUpdateButton()
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(txtPrimerNombre.Text) &&
                                   !string.IsNullOrWhiteSpace(txtSegundoNombre.Text) &&
                                   !string.IsNullOrWhiteSpace(txtPrimerApellido.Text) &&
                                   !string.IsNullOrWhiteSpace(txtSegundoApellido.Text) &&
                                   !string.IsNullOrWhiteSpace(txtCedula.Text) &&
                                   !string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                                   !string.IsNullOrWhiteSpace(txtDir.Text) &&
                                   !string.IsNullOrWhiteSpace(txtNomEmpresa.Text) &&
                                   !string.IsNullOrWhiteSpace(txtRUC.Text) &&
                                   !string.IsNullOrWhiteSpace(txtTelef.Text);
            btnAgregar.Enabled = allFieldsFilled;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool errorEnTelefono = false;
            bool errorEnCedula = false;
            bool errorEnRUC = false;


            string input = txtTelef.Text;
            // Verificar si los dos primeros caracteres no son "09"
            if (input.Length < 2 || input.Substring(0, 2) != "09" || input.Length != 10)
            {
                // Si los dos primeros caracteres no son "09", mostrar un mensaje de error
                MessageBox.Show("El numero celular es invalido, debe comenzar con 09 y tener 10 digitos");
                errorEnTelefono = true;
            }
            if (this.txtCedula.Text.Length != 10)
            {
                MessageBox.Show("Numero de Cedula invalido, debe contener 10 digitos");
                errorEnCedula = true;
            }
            if (this.txtRUC.Text.Length != 13)
            {
                MessageBox.Show("Numero de RUC invalido, debe contener 13 digitos");
                errorEnRUC = true;
            }
            if (!errorEnTelefono && !errorEnCedula && !errorEnRUC)
            {
                Form Confirmar = new VentanaConfirmarAddCliente();
                PrimerNombre = txtPrimerNombre.Text;
                SegundoNombre = txtSegundoNombre.Text;
                PrimerApellido = txtPrimerApellido.Text;
                SegundoApellido = txtSegundoApellido.Text;
                Cedula = txtCedula.Text;
                Correo = txtCorreo.Text;
                Telefono = txtTelef.Text;
                NombreEmpresa = txtNomEmpresa.Text;
                RUC = txtRUC.Text;
                Direccion = txtDir.Text;
                Confirmar.ShowDialog();
            }
        }


    private void btnAgregar_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void txtPrimerNombre_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtSegundoNombre_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtPrimerApellido_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtSegundoApellido_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
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

        private void txtNomEmpresa_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtRUC_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtDir_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es una letra ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un número ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
            if (txtCedula.Text.Length >= 10 && e.KeyChar != '\b')
            {
                // Si tiene 10 o más caracteres y la tecla presionada no es una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
        }

        private void txtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es una letra ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
        }

        private void txtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es una letra ni una tecla de borrar, se ignora la entrada del usuario
                e.Handled = true;
            }
        }

        private void txtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es una letra ni una tecla de borrar, se ignora la entrada del usuario
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

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '\b')
            {
                // Si el carácter no es válido, suprimirlo
                e.Handled = true;
            }
        }

        private void txtNomEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != ' ' && e.KeyChar != '\b')
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

        private void txtDir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                // Si el carácter no es válido, suprimirlo
                e.Handled = true;
            }
        }

        private void txtCajaBuscar_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool errorEnTelefono = false;
            bool errorEnCedula = false;
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
            if (this.txtCedula.Text.Length != 10)
            {
                MessageBox.Show("Numero de Cedula invalido, debe contener 10 digitos");
                errorEnCedula = true;
            }
            if (this.txtRUC.Text.Length != 13)
            {
                MessageBox.Show("Numero de RUC invalido, debe contener 13 digitos");
                errorEnRUC = true;
            }
            string strCom = "SELECT TOP 1 id_cliente FROM Clientes where id_cliente = '" + this.txtCedula.Text + "'";
            comm = new SqlCommand(strCom, conn); // Asignar la conexión a comm
            conn.Open(); // Abrir la conexión
            object resultado = comm.ExecuteScalar();
            conn.Close(); // Cerrar la conexión después de usarla
            if (resultado == null)
            {
                MessageBox.Show(" ¡¡ERROR!!, no puedes modificar la C.I.");
                errorEnId = true;
            }            
            if (!errorEnTelefono && !errorEnCedula &&!errorEnRUC && !errorEnId)
            {
                Form Confirmar = new VentanaConfirmarModCliente();
                PrimerNombre = txtPrimerNombre.Text;
                SegundoNombre = txtSegundoNombre.Text;
                PrimerApellido = txtPrimerApellido.Text;
                SegundoApellido = txtSegundoApellido.Text;
                Cedula = txtCedula.Text;
                Correo = txtCorreo.Text;
                Telefono = txtTelef.Text;
                NombreEmpresa = txtNomEmpresa.Text;
                RUC = txtRUC.Text;
                Direccion = txtDir.Text;
                Confirmar.ShowDialog();
            }
        }

        private void dataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Habilitar el botón si se ha seleccionado una fila
                button1.Enabled = true;
            }
        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string contenidoCelda = dataGridViewClientes.SelectedCells[0].Value.ToString(); // Contenido de la celda [0]
            string[] partes = contenidoCelda.Split(' '); // Dividir la cadena en palabras utilizando el espacio como separador
            if (partes.Length >= 4)
            {
                txtPrimerNombre.Text = partes[0];
                txtSegundoNombre.Text = partes[1];
                txtPrimerApellido.Text = partes[2];
                txtSegundoApellido.Text = partes[3];
            }
            txtCedula.Text = dataGridViewClientes.SelectedCells[1].Value.ToString();
            txtNomEmpresa.Text = dataGridViewClientes.SelectedCells[2].Value.ToString();
            txtRUC.Text = dataGridViewClientes.SelectedCells[3].Value.ToString();
            txtTelef.Text = dataGridViewClientes.SelectedCells[4].Value.ToString();
            txtCorreo.Text = dataGridViewClientes.SelectedCells[5].Value.ToString();
            txtDir.Text = dataGridViewClientes.SelectedCells[6].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                Form Confirmar = new VentanaConfirmarBorrCliente();
                Cedula = txtCedula.Text;
                Confirmar.ShowDialog();
            }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPrimerNombre.Clear();
            txtSegundoNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();

            txtCedula.Clear();
            txtNomEmpresa.Clear();
            txtRUC.Clear();
            txtTelef.Clear();
            txtCorreo.Clear();
            txtDir.Clear();
        }
    }
    }

