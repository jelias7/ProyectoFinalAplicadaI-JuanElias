using BLL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAplicadaI_JuanElias.SupermarketSoftware.Registros
{
    public partial class rProductos : Form
    {
        //todo Poner control de fecha de vencimiento
        public rProductos()
        {
            InitializeComponent();
            Producto();
            Proveedor();
            Seccion();
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
            CantidadnumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            CostonumericUpDown.Value = 0;
            GananciatextBox.Text = string.Empty;
            ItbistextBox.Text = string.Empty;
            ItbiscomboBox.Text = string.Empty;
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
            CantidadnumericUpDown.Value = p.Cantidad;
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
            p.Producto = ProductocomboBox.Text;
            p.Proveedor = ProveedorcomboBox.Text;
            p.Seccion = SeccioncomboBox.Text;
            p.Cantidad = (int)CantidadnumericUpDown.Value;
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
        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();

            MyErrorProvider.Clear();

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (Repositorio.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No existe.");
        }

        public static bool RepetirCodigo(int descripcion)
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

            if (RepetirCodigo((int)CodigonumericUpDown.Value))
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
            if(CantidadnumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CantidadnumericUpDown, "No puede ser cero.");
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
            if (string.IsNullOrWhiteSpace(ItbiscomboBox.Text))
            {
                MyErrorProvider.SetError(ItbiscomboBox, "No puede ser vacio.");
                paso = false;
            }
            return paso;
        }
            private void Guardarbutton_Click(object sender, EventArgs e)
            {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos p = new Productos();
            bool paso = false;
            if (!Validar())
                return;

            p = LlenaClase();



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
           decimal defecto = 0;

           if(PrecionumericUpDown.Value > CostonumericUpDown.Value)
                GananciatextBox.Text = Convert.ToString(PrecionumericUpDown.Value - CostonumericUpDown.Value);
            else
                GananciatextBox.Text = defecto.ToString();
        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PrecionumericUpDown.Value > CostonumericUpDown.Value)
                GananciatextBox.Text = Convert.ToString(PrecionumericUpDown.Value - CostonumericUpDown.Value);
            else
                GananciatextBox.Text = "0";
        }

        private void Inventariobutton_Click(object sender, EventArgs e)
        {
            rInventarios rInventarios = new rInventarios();
            rInventarios.Show();
        }

        private void ItbiscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double exento = 0;
            double itbis16 = 0.16;
            double itbis18 = 0.18;

            if (ItbiscomboBox.Text == "Exento")
                ItbistextBox.Text = Convert.ToString(exento);
            else
            {
                if (PrecionumericUpDown.Value > 0)
                {
                    if (ItbiscomboBox.Text == "16%")
                        ItbistextBox.Text = Convert.ToString(PrecionumericUpDown.Value * (decimal)itbis16);
                    if (ItbiscomboBox.Text == "18%")
                        ItbistextBox.Text = Convert.ToString(PrecionumericUpDown.Value * (decimal)itbis18);
                }
            }
        }
    }
}
