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
    public partial class VentanaConfirmarBorrEmple : Form
    {
        SqlConnection conn = DataAccess.getConn();
        private static string strComm = null;
        SqlCommand comm = null;
        public VentanaConfirmarBorrEmple()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string strCom = "SELECT TOP 1 id_empleado FROM Empleados where id_empleado = '" + MenuEmpleados.Cedula + "'";
            comm = new SqlCommand(strCom, conn); // Asignar la conexión a comm
            conn.Open(); // Abrir la conexión
            object resultado = comm.ExecuteScalar();
            conn.Close(); // Cerrar la conexión después de usarla
            if (resultado == null)
            {
                MessageBox.Show(" ¡¡ERROR!!, No existe el Empleado");

            }
            else
            {
                string deleteCommand = "DELETE FROM Empleados WHERE id_empleado = '" + MenuEmpleados.Cedula + "'";
                comm = new SqlCommand(deleteCommand, conn);
                conn.Open();
                int rowsAffected = comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Se a Eliminado el Empleado con Éxito");
            }
        }

        private void VentanaConfirmarBorrEmple_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
