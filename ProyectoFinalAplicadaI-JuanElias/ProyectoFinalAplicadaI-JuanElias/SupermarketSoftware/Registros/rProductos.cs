using BLL;
using DAL;
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
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
            Producto();
            ProductocomboBox.Text = null;
            Proveedor();
            ProveedorcomboBox.Text = null;
            Seccion();
            SeccioncomboBox.Text = null;
        }
        private void Producto()
        {
            RepositorioBase<Inventarios> db = new RepositorioBase<Inventarios>();
            var listado = new List<Inventarios>();
            listado = db.GetList(p => true);
            ProductocomboBox.DataSource = listado;
            ProductocomboBox.DisplayMember = "Producto";
            ProductocomboBox.ValueMember = "InventarioId";
        }
        private void Proveedor()
        {
            RepositorioBase<Proveedores> db = new RepositorioBase<Proveedores>();
            var listado = new List<Proveedores>();
            listado = db.GetList(p => true);
            ProveedorcomboBox.DataSource = listado;
            ProveedorcomboBox.DisplayMember = "Nombres";
            ProveedorcomboBox.ValueMember = "ProveedorId";
        }
        private void Seccion()
        {
            RepositorioBase<Secciones> db = new RepositorioBase<Secciones>();
            var listado = new List<Secciones>();
            listado = db.GetList(p => true);
            SeccioncomboBox.DataSource = listado;
            SeccioncomboBox.DisplayMember = "Nombre";
            SeccioncomboBox.ValueMember = "SeccionId";
        }
        private void AddProveedorbutton_Click(object sender, EventArgs e)
        {
            rProveedores r = new rProveedores();
            r.Show();
        }

        private void AddSeccionbutton_Click(object sender, EventArgs e)
        {
            rSecciones r = new rSecciones();
            r.Show();
        }
        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            CodigonumericUpDown.Value = 0;
            ProductocomboBox.Text = string.Empty;
            ProveedorcomboBox.Text = string.Empty;
            SeccioncomboBox.Text = string.Empty;
            CantidadtextBox.Text = string.Empty;
            PrecionumericUpDown.Value = 0;
            CostonumericUpDown.Value = 0;
            GananciatextBox.Text = string.Empty;
            ItbistextBox.Text = string.Empty;
            MyErrorProvider.Clear();
        }
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void LlenaCampo(Productos p)
        {
            IDnumericUpDown.Value = p.ProductoId;
            CodigonumericUpDown.Value = p.Codigo;
            ProductocomboBox.Text = p.Producto;
            ProveedorcomboBox.Text = p.Proveedor;
            SeccioncomboBox.Text = p.Seccion;
            CantidadtextBox.Text = p.Cantidad.ToString();
            PrecionumericUpDown.Value = p.Precio;
            CostonumericUpDown.Value = p.Costo;
            GananciatextBox.Text = p.Ganancia.ToString();
            ItbistextBox.Text = p.ITBIS.ToString();
        }
        private Productos LlenaClase()
        {
            Productos p = new Productos();
            p.ProductoId = Convert.ToInt32(IDnumericUpDown.Value);
            p.Codigo = Convert.ToInt32(CodigonumericUpDown.Value);
            p.Producto = (string)ProductocomboBox.SelectedItem;
            p.Proveedor = (string)ProveedorcomboBox.SelectedItem;
            p.Seccion = (string)SeccioncomboBox.SelectedItem;
            p.Cantidad = Convert.ToInt32(CantidadtextBox.Text);
            p.Precio = PrecionumericUpDown.Value;
            p.Costo = CostonumericUpDown.Value;
            p.Ganancia = Convert.ToDecimal(GananciatextBox.Text);
            p.ITBIS = Convert.ToDecimal(ItbistextBox.Text);
            return p;
        }
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos p = new Productos();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            p = Repositorio.Buscar(id);
            if (p != null)
                LlenaCampo(p);
            else
                MessageBox.Show("No encontrado.");
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos p = Repositorio.Buscar((int)IDnumericUpDown.Value);
            return (p != null);
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
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();

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
        public static bool RepetirProducto(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Productos.Any(p => p.Producto.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool RepetirCodigo(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Productos.Any(p => p.Codigo.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool ValidarRepeticion()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (RepetirProducto(ProductocomboBox.Text))
            {
                MyErrorProvider.SetError(ProductocomboBox, "No se pueden repetir.");
                paso = false;
            }
            if (RepetirCodigo(CodigonumericUpDown.Text))
            {
                MyErrorProvider.SetError(CodigonumericUpDown, "No se pueden repetir.");
                paso = false;
            }
            return paso;
        }
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
            if (string.IsNullOrWhiteSpace(ProductocomboBox.Text))
            {
                MyErrorProvider.SetError(ProductocomboBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ProveedorcomboBox.Text))
            {
                MyErrorProvider.SetError(ProveedorcomboBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(SeccioncomboBox.Text))
            {
                MyErrorProvider.SetError(SeccioncomboBox, "No puede ser vacio.");
                paso = false;
            }
            if (PrecionumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(PrecionumericUpDown, "No puede ser 0.");
                paso = false;
            }
            if (CostonumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CostonumericUpDown, "No puede ser 0.");
                paso = false;
            }
            if(CostonumericUpDown.Value > PrecionumericUpDown.Value)
            {
                MyErrorProvider.SetError(CostonumericUpDown, "Costo no puede ser mayor que Precio.");
                paso = false;
            }
            return paso;
        }
            private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos p = new Productos();
            bool paso = false;
            p = LlenaClase();

            if (!Validar())
                return;

            if (IDnumericUpDown.Value == 0)
            {
                if (!ValidarRepeticion())
                    return;

                paso = Repositorio.Guardar(p);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Repositorio.Modificar(p);
            }

            if (paso)
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {
           if(PrecionumericUpDown.Value > CostonumericUpDown.Value)
                GananciatextBox.Text = Convert.ToString(PrecionumericUpDown.Value - CostonumericUpDown.Value);
            else
                GananciatextBox.Text = "0";

            //todo No esta perfecto
            double itbis = 0.18;
            double itbisReducido = 0.16;
            if (SeccioncomboBox.Text == "Pescaderia" || SeccioncomboBox.Text == "Farmacia" || SeccioncomboBox.Text == "Refrigerados" || SeccioncomboBox.Text == "Drogueria")
            {
                ItbistextBox.Text = "0";
            }
            else
            {
                if(ProductocomboBox.Text == "Yogurt" || ProductocomboBox.Text == "Mantequilla" || ProductocomboBox.Text == "Cafe" || ProductocomboBox.Text == "Vegetales" || ProductocomboBox.Text == "Azucar" || ProductocomboBox.Text == "Cacao")
                {
                    ItbistextBox.Text = Convert.ToString(PrecionumericUpDown.Value * (decimal)itbisReducido);
                }
                else
                    ItbistextBox.Text = Convert.ToString(PrecionumericUpDown.Value * (decimal)itbis);
            }
        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PrecionumericUpDown.Value > CostonumericUpDown.Value)
                GananciatextBox.Text = Convert.ToString(PrecionumericUpDown.Value - CostonumericUpDown.Value);
            else
                GananciatextBox.Text = "0";
        }
    }
}
