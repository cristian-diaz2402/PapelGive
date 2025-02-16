using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using ToolTip = System.Windows.Forms.ToolTip;

namespace PIIBAPPDB
{
    
    public partial class FrmVentanaPrincipal : Form
    {
        private MenuBotones menuBotonesForm;
        private MenuCaja menuCajaForm;
        private List<Form> formulariosAbiertos = new List<Form>();
        public FrmVentanaPrincipal()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            panelBarraAux.Width = 0;
            CenterToScreen();
            AbrirFormularios<MenuBotones>();
            menuBotonesForm.txtRol.Text = this.txtValor.Text;
            menuBotonesForm.txtU.Text = this.txtUser.Text;
            this.txtValor.Visible = false;
            this.txtUser.Visible = false;
            //       mostrarMenuBotones();
        }


        private void AbrirFormularios<MiForm>()where MiForm :Form, new()
        {
            foreach (var form in formulariosAbiertos)
            {
                if (!(form is MenuBotones))
                {
                    
                    form.Close();
                }
            }
            formulariosAbiertos.Clear();

            Form formulario;
            formulario = panelContenedor.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.Dock = DockStyle.Fill;
                panelContenedor.Controls.Add(formulario);
                panelContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulariosAbiertos.Add(formulario);
                if (formulario is MenuBotones)
                {
                    menuBotonesForm = (MenuBotones)formulario;
                }
                if (formulario is MenuCaja)
                {
                    menuCajaForm = (MenuCaja)formulario;
                }
            }

            else
            {

               
                formulario.BringToFront();
          

            }
        }




        private void btnCrearModificar_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuClientes>();
        }

        private void btnCrearModificar_MouseEnter(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuProductos>();

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuVentas>();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuCompras>();
        }


        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            if (this.txtValor.Text == "Administrador")
            {
                AbrirFormularios<MenuProveedores>();
            }
            if (this.txtValor.Text == "Empleado")
            {
                MessageBox.Show("Accedo solo Administradores");
            }
            

        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            if (this.txtValor.Text == "Administrador")
            {
                AbrirFormularios<MenuEmpleados>();
            }
            if (this.txtValor.Text == "Empleado")
            {
                MessageBox.Show("Accedo solo Administradores");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void PanelT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenedor_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panelBarraAux.Width == 0)
            {
                panelBarraAux.Width = 240;
                btnClientes.BackColor = Color.FromArgb(192, 0, 0);
                btnProductos.BackColor = Color.FromArgb(192, 0, 0);
                btnVentas.BackColor = Color.FromArgb(192, 0, 0);
                btnCompras.BackColor = Color.FromArgb(192, 0, 0);
                btnProveedor.BackColor = Color.FromArgb(192, 0, 0);
                btnEmpleados.BackColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                if (panelBarraAux.Width == 240)
                {
                    panelBarraAux.Width = 0;
                    btnEmpleados.BackColor = Color.FromArgb(192, 0, 0);
                    btnClientes.BackColor = Color.FromArgb(192, 0, 0);
                    btnProductos.BackColor = Color.FromArgb(192, 0, 0);
                    btnVentas.BackColor = Color.FromArgb(192, 0, 0);
                    btnCompras.BackColor = Color.FromArgb(192, 0, 0);
                    btnProveedor.BackColor = Color.FromArgb(192, 0, 0);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuClientes>();
        }

        private void btnVent_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuVentas>();
        }

        private void btnProv_Click(object sender, EventArgs e)
        {
            if (this.txtValor.Text == "Administrador")
            {
                AbrirFormularios<MenuProveedores>();
            }
            if (this.txtValor.Text == "Empleado")
            {
                MessageBox.Show("Acceso solo Administradores");
            }
        }

        private void btnPedid_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuCompras>();
        }

        private void btnEmple_Click(object sender, EventArgs e)
        {
            if (this.txtValor.Text == "Administrador")
            {
                AbrirFormularios<MenuEmpleados>();
            }
            if (this.txtValor.Text == "Empleado")
            {
                MessageBox.Show("Acceso solo Administradores");
            }
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuProductos>();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuCaja>();
            menuCajaForm.txtrol.Text = this.txtValor.Text;
            menuCajaForm.txtUs.Text = this.txtUser.Text;
            
        }

        private void btnCaj_Click(object sender, EventArgs e)
        {
            AbrirFormularios<MenuCaja>();
            menuCajaForm.txtrol.Text = this.txtValor.Text;
            menuCajaForm.txtUs.Text = this.txtUser.Text;
        }





        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            VentanaIniciarSecion VIS = new VentanaIniciarSecion();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVentanaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }

        }
    }
}
