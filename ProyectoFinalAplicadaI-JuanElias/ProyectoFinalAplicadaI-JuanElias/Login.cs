using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoFinalAplicadaI_JuanElias
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public void Sesion()
        {
            try
            {
                string ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(ConStr))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Usuario, Clave FROM Usuarios WHERE Usuario='" + UsuariotextBox.Text + "' AND Clave='" + ClavetextBox.Text + "'", conexion))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            MainForm f = new MainForm();
                            f.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Datos incorrectos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existe en la base de datos.");
            }

        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            Sesion();
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
