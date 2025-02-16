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
    public partial class VentanaIniciarSecion : Form
    {
        SqlConnection conn = DataAccess.getConn();
        private static string strComm = null;
        SqlCommand comm = null;
        public VentanaIniciarSecion()
        {
            InitializeComponent();
            txtContraseña.PasswordChar = '*';
        }
        private void EnableUpdateButton()
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(txtUsuario.Text) &&
                                   !string.IsNullOrWhiteSpace(txtContraseña.Text) &&
                                   comboBox1.SelectedIndex != -1;
            btnIniciar.Enabled = allFieldsFilled;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string rol = comboBox1.SelectedItem.ToString();
                string strCom = "SELECT TOP 1 nomb_usuario FROM Empleados where nomb_usuario = '" + txtUsuario.Text + "' and clave = '"+txtContraseña.Text+"' and rol='"+rol+"'";
                comm = new SqlCommand(strCom, conn);
                conn.Open();
                object resultado = comm.ExecuteScalar();
                conn.Close();
                if(resultado !=null){
                    string ValorCmb = comboBox1.SelectedItem.ToString();
                    FrmVentanaPrincipal VP = new FrmVentanaPrincipal();
                    VP.txtValor.Text = ValorCmb;
                    VP.txtUser.Text = this.txtUsuario.Text;
                    VP.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario, contraseña o rol incorrectos, porfavor verifique sus datos");
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("¡¡ERROR!! " + ex.Message);
            }
            

        }

        private void VentanaIniciarSecion_Load(object sender, EventArgs e)

        {
            EnableUpdateButton();
            CenterToScreen();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            EnableUpdateButton();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '\b')
            {
                // Si el carácter no es válido, suprimirlo
                e.Handled = true;
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '$' && e.KeyChar != '@' && e.KeyChar != '!' && e.KeyChar != '%' && e.KeyChar != '#' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '\b')
            {
                // Si el carácter no es válido, suprimirlo
                e.Handled = true;
            }
        }
    }
}
