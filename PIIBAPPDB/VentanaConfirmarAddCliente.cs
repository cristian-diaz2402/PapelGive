using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PIIBAPPDB
{
    public partial class VentanaConfirmarAddCliente : Form
    {
        static SqlConnection conn = DataAccess.getConn();
        SqlCommand comm = null;

        public VentanaConfirmarAddCliente()
        {
            InitializeComponent();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("El cliente fue ingresado con éxito");
                    this.btnConfirmar.Enabled = false;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show(" ¡¡ERROR!!, El cliente ya existe");
                        this.btnConfirmar.Enabled = false;
                }
                }
            conn.Close();
        }
                     

        private void VentanaConfirmarAddCliente_Load(object sender, EventArgs e)
        {
            CenterToParent();
            conn.Open();
            string strComm = "sp_InsertarCliente";
            comm = new SqlCommand(strComm, conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Cedula", MenuClientes.Cedula);
            comm.Parameters.AddWithValue("@PrimerNombre", MenuClientes.PrimerNombre);
            comm.Parameters.AddWithValue("@SegundoNombre", MenuClientes.SegundoNombre);
            comm.Parameters.AddWithValue("@PrimerApellido", MenuClientes.PrimerApellido);
            comm.Parameters.AddWithValue("@SegundoApellido", MenuClientes.SegundoApellido);
            comm.Parameters.AddWithValue("@Direccion", MenuClientes.Direccion);
            comm.Parameters.AddWithValue("@Telefono", MenuClientes.Telefono);
            comm.Parameters.AddWithValue("@Correo", MenuClientes.Correo);
            comm.Parameters.AddWithValue("@NombreEmpresa", MenuClientes.NombreEmpresa);
            comm.Parameters.AddWithValue("@Ruc", MenuClientes.RUC);

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
