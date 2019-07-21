using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAplicadaI_JuanElias.SupermarketSoftware.Registros
{
    public partial class rVentas : Form
    {
        public List<VentasDetalle> Detalle { get; set; }
        public rVentas()
        {
            InitializeComponent();
            Cliente();
            Producto();
            this.Detalle = new List<VentasDetalle>();
        }
        private void Cliente()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            var listado = new List<Clientes>();
            listado = db.GetList(p => true);
            ClientecomboBox.DataSource = listado;
            ClientecomboBox.DisplayMember = "Nombres";
            ClientecomboBox.ValueMember = "ClienteId";

        }
        private void Producto()
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            var listado = new List<Productos>();
            listado = db.GetList(p => true);
            ProductocomboBox.DataSource = listado;
            ProductocomboBox.DisplayMember = "Producto";
            ProductocomboBox.ValueMember = "ProductoId";

        }
        private void Clientebutton_Click(object sender, EventArgs e)
        {
            rClientes rClientes = new rClientes();
            rClientes.Show();
        }

        private void Productobutton_Click(object sender, EventArgs e)
        {
            rProductos rProductos = new rProductos();
            rProductos.Show();
        }
        private void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = Detalle;
        }
        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            ClientecomboBox.Text = string.Empty;
            ProductocomboBox.Text = string.Empty;
            PreciotextBox.Text = string.Empty;
            CantidadnumericUpDown.Value = 1;
            DisponiblestextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            ITBIStextBox.Text = string.Empty;
            SubtotaltextBox.Text = string.Empty;
            TotaltextBox.Text = string.Empty;
            ModocheckedListBox.Refresh();
            this.Detalle = new List<VentasDetalle>();
            MyErrorProvider.Clear();
            CargarGrid();
        }
        private void LlenaCampo(Ventas v)
        {
            IDnumericUpDown.Value = v.VentaId;
            ClientecomboBox.Text = v.Cliente;
            CantidadnumericUpDown.Value = v.Cantidad;
            FechadateTimePicker.Value = v.Fecha;
            ITBIStextBox.Text = v.Itbis.ToString();
            SubtotaltextBox.Text = v.Subtotal.ToString();
            TotaltextBox.Text = v.Total.ToString();
            ModocheckedListBox.ToString();
            this.Detalle = v.Detalle;
            CargarGrid();
        }
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ventas> Repositorio = new RepositorioBase<Ventas>();
            Ventas v = new Ventas();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            v = Repositorio.Buscar(id);
            if (v != null)
                LlenaCampo(v);
            else
                MessageBox.Show("No encontrado.");
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private Ventas LlenaClase()
        {
            Ventas v = new Ventas();
            v.Detalle = this.Detalle;
            v.VentaId = Convert.ToInt32(IDnumericUpDown.Value);
            v.Cliente = ClientecomboBox.Text;
            v.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);
            v.Fecha = FechadateTimePicker.Value;
            v.Itbis = Convert.ToDecimal(ITBIStextBox.Text);
            v.Subtotal = Convert.ToDecimal(SubtotaltextBox.Text);
            v.Total = Convert.ToDecimal(TotaltextBox.Text);
            return v;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();
            Ventas ventas = db.Buscar((int)IDnumericUpDown.Value);
            return (ventas != null);
        }
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
            if (string.IsNullOrWhiteSpace(ClientecomboBox.Text))
            {
                MyErrorProvider.SetError(ClientecomboBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ProductocomboBox.Text))
            {
                MyErrorProvider.SetError(ProductocomboBox, "No puede ser vacio.");
                paso = false;
            }
            if (FechadateTimePicker.Value != DateTime.Now)
            {
                MyErrorProvider.SetError(FechadateTimePicker, "No puede ser diferente.");
                paso = false;
            }
            return paso;
        }
            private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ventas> Repositorio = new RepositorioBase<Ventas>();
            Ventas p = new Ventas();
            bool paso = false;
            p = LlenaClase();

            if (!Validar())
                return;

            if (IDnumericUpDown.Value == 0)
            {
                paso = Repositorio.Guardar(p);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar.", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Repositorio.Modificar(p);
            }

            if (paso)
                MessageBox.Show("Guardado", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }
        private bool ValidarEliminar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (IDnumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(IDnumericUpDown, "Busquelo y luego eliminelo.");
                IDnumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }
        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ventas> Repositorio = new RepositorioBase<Ventas>();

            MyErrorProvider.Clear();
            if (!ValidarEliminar())
                return;

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (Repositorio.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No existe.");
        }
    }
}
