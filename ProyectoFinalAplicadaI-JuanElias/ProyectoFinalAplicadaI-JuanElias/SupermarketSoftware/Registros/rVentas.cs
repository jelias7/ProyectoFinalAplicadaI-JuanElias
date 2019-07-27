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
        public List<VentasDetalle> Detalle;
        private int id;
        public rVentas(int id)
        {
            InitializeComponent();
            Cliente();
            Producto();
            this.id = id;
            Detalle = new List<VentasDetalle>();
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
            rClientes rClientes = new rClientes(id);
            rClientes.Show();
        }

        private void Productobutton_Click(object sender, EventArgs e)
        {
            rProductos rProductos = new rProductos(id);
            rProductos.Show();
        }
        private void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = Detalle;
        }
        public void CalcularItbis()
        {
            decimal itbis = 0;
            foreach (var item in Detalle)
            {
                itbis += item.Impuesto;
            }
            ITBIStextBox.Text = itbis.ToString();
        }

        public void CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Detalle)
            {
                total += (item.Precio * item.Cantidad) + item.Impuesto;
            }
            TotaltextBox.Text = total.ToString();
        }

        public void CalcularSubtotal()
        {
            decimal subtotal = 0;
            foreach (var item in Detalle)
            {
                subtotal += item.Precio * item.Cantidad;
            }
            SubtotaltextBox.Text = subtotal.ToString();
        }
        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            ClientecomboBox.Text = null;
            ProductocomboBox.Text = null;
            PreciotextBox.Text = string.Empty;
            CantidadnumericUpDown.Value = 1;
            DisponiblestextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            ITBIStextBox.Text = string.Empty;
            SubtotaltextBox.Text = string.Empty;
            TotaltextBox.Text = string.Empty;
            ModocomboBox.Text = null;
            this.Detalle = new List<VentasDetalle>();
            MyErrorProvider.Clear();
            CargarGrid();
        }
        private void LlenaCampo(Ventas v)
        {
            IDnumericUpDown.Value = v.VentaId;
            ClientecomboBox.Text = v.Cliente;
            CantidadnumericUpDown.Value = 1;
            FechadateTimePicker.Value = v.Fecha;
            ITBIStextBox.Text = v.Itbis.ToString();
            SubtotaltextBox.Text = v.Subtotal.ToString();
            TotaltextBox.Text = v.Total.ToString();
            ModocomboBox.Text = v.Modo;
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
            v.Fecha = FechadateTimePicker.Value;
            v.Modo = ModocomboBox.Text;
            v.Itbis = Convert.ToDecimal(ITBIStextBox.Text);
            v.Subtotal = Convert.ToDecimal(SubtotaltextBox.Text);
            v.Total = Convert.ToDecimal(TotaltextBox.Text);
            v.UsuarioId = id;
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
            Productos p = ProductocomboBox.SelectedItem as Productos;
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
            if (string.IsNullOrWhiteSpace(ModocomboBox.Text))
            {
                MyErrorProvider.SetError(ModocomboBox, "No puede ser vacio.");
                paso = false;
            }
            if (Detalle.Count == 0)
            {
                MessageBox.Show("El grid esta vacio.", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                paso = false;
            }
            return paso;
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Ventas v = new Ventas();
            bool paso = false;


            if (!Validar())
                return;

            v = LlenaClase();

            if (IDnumericUpDown.Value == 0)
            {
                paso = VentaBLL.Guardar(v);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar.", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = VentaBLL.Modificar(v);
            }

            if (paso)
                MessageBox.Show("Guardado", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

            MyErrorProvider.Clear();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (VentaBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No existe.");
        }

        private void ProductocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Productos p = ProductocomboBox.SelectedItem as Productos;
            if (p != null)
            {
                PreciotextBox.Text = Convert.ToString(p.Precio);
                DisponiblestextBox.Text = Convert.ToString(p.Cantidad);
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            Productos p = ProductocomboBox.SelectedItem as Productos;

            if (DetalledataGridView.DataSource != null)
                this.Detalle = (List<VentasDetalle>)DetalledataGridView.DataSource;

            MyErrorProvider.Clear();

            if (ProductocomboBox.SelectedValue != null)
            {
                int d = (int)ProductocomboBox.SelectedValue;

                foreach (var item in Detalle)
                {
                    if (d == item.ProductoId)
                    {
                        MyErrorProvider.SetError(Addbutton, "El producto ya esta en el grid.");
                        return;
                    }
                }

                if (CantidadnumericUpDown.Value > Convert.ToInt32(DisponiblestextBox.Text))
                {
                    MyErrorProvider.SetError(DisponiblestextBox, "No quedan disponibles.");
                    return;
                }
            }
            if (PreciotextBox.Text != string.Empty)
            {
                this.Detalle.Add(new VentasDetalle()
                {
                    ProductoId = (int)ProductocomboBox.SelectedValue,
                    Cantidad = (int)CantidadnumericUpDown.Value,
                    Precio = Convert.ToDecimal(PreciotextBox.Text),
                    Impuesto = p.ITBIS * CantidadnumericUpDown.Value
                });
            }
            CargarGrid();
            CalcularItbis();
            CalcularSubtotal();
            CalcularTotal();
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            Productos p = ProductocomboBox.SelectedItem as Productos;
            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {
                Detalle.RemoveAt(DetalledataGridView.CurrentRow.Index);
                CargarGrid();
                CalcularItbis();
                CalcularSubtotal();
                CalcularTotal();
            }
        }

        private void RVentas_Load(object sender, EventArgs e)
        {
            Nuevobutton.PerformClick();
        }
    }
}
