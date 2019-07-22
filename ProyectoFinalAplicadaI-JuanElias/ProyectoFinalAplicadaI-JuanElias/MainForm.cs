using MetroFramework;
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
        public int id { get; set; }
        public MainForm(int id)
        {
            this.id = id;
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
            var select = MessageBox.Show("¿Seguro?", "Supermarket Sotfware.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (select == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
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

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos rProductos = new rProductos();
            rProductos.Show();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rClientes rClientes = new rClientes();
            rClientes.Show();
        }

        private void InformacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Sistema creado por Juan Elias Rosario Mena." + Environment.NewLine + "Ingenieria en Sistemas y Computacion." + Environment.NewLine + "Universidad Catolica Nordestana", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVentas rVentas = new rVentas();
            rVentas.Show();
        }

        private void SeccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rSecciones rSecciones = new rSecciones();
            rSecciones.Show();
        }

        private void ProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProveedores rProveedores = new rProveedores();
            rProveedores.Show();
        }

        private void SeccionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cSecciones cSecciones = new cSecciones();
            cSecciones.Show();
        }

        private void ProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProveedores cProveedores = new cProveedores();
            cProveedores.Show();
        }

        private void ClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cClientes cClientes = new cClientes();
            cClientes.Show();
        }

        private void InventarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cInventarios cInventarios = new cInventarios();
            cInventarios.Show();
        }

        private void ProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProductos cProductos = new cProductos();
            cProductos.Show();
        }

        private void ConsultarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cVentas cVentas = new cVentas();
            cVentas.Show();
        }
    }
}
