using ProyectoFinalAplicadaI_JuanElias.SupermarketSoftware.Consultas;
using ProyectoFinalAplicadaI_JuanElias.SupermarketSoftware.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAplicadaI_JuanElias
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuarios r = new rUsuarios();
            r.Show();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuarios c = new cUsuarios();
            c.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var select = MessageBox.Show("¿Seguro?", "Supermarket Sotfware.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (select == DialogResult.Yes)
                Application.Exit();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rInventarios rInventarios = new rInventarios();
            rInventarios.Show();
        }
    }
}
