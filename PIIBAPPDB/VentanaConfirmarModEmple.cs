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
    public partial class VentanaConfirmarModEmple : Form
    {
        static SqlConnection conn = DataAccess.getConn();
        SqlCommand comm = null;
        public VentanaConfirmarModEmple()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentanaConfirmarModEmple_Load(object sender, EventArgs e)
        {
            CenterToParent();
            conn.Open();

            string strComm = "sp_ModificarEmpleado";
            comm = new SqlCommand(strComm, conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Cedula", MenuEmpleados.Cedula);
            comm.Parameters.AddWithValue("@PrimerNombre", MenuEmpleados.PrimerNombre);
            comm.Parameters.AddWithValue("@SegundoNombre", MenuEmpleados.SegundoNombre);
            comm.Parameters.AddWithValue("@PrimerApellido", MenuEmpleados.PrimerApellido);
            comm.Parameters.AddWithValue("@SegundoApellido", MenuEmpleados.SegundoApellido);
            comm.Parameters.AddWithValue("@Direccion", MenuEmpleados.Direccion);
            comm.Parameters.AddWithValue("@Telefono", MenuEmpleados.Telefono);
            comm.Parameters.AddWithValue("@Correo", MenuEmpleados.Correo);
            comm.Parameters.AddWithValue("@Rol", MenuEmpleados.Rol);
            comm.Parameters.AddWithValue("@Ocupacion", MenuEmpleados.Ocupacion);
            comm.Parameters.AddWithValue("@Clave", MenuEmpleados.Password);
            comm.Parameters.AddWithValue("@NombreUsuario", MenuEmpleados.NombreUsuario);
            comm.Parameters.AddWithValue("@NombreSede", "Quito");
            comm.Parameters.AddWithValue("@Sueldo", MenuEmpleados.Sueldo);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("El cliente fue Modificado con éxito");
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
