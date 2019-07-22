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
    public partial class rInventarios : Form
    {
        private int id;
        public rInventarios(int id)
        {
            this.id = id;
            InitializeComponent();
        }
        private void Limpiar()
        {

            IDnumericUpDown.Value = 0;
            ProductotextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            MyErrorProvider.Clear();

        }
        private Inventarios LlenaClase()
        {
            Inventarios i = new Inventarios();
            i.InventarioId = Convert.ToInt32(IDnumericUpDown.Value);
            i.Producto = ProductotextBox.Text;
            i.Fecha = FechadateTimePicker.Value;
            i.UsuarioId = id;
            return i;
        }

        private void LlenaCampo(Inventarios i)
        {
            IDnumericUpDown.Value = i.InventarioId;
            ProductotextBox.Text = i.Producto;
            FechadateTimePicker.Value = i.Fecha;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Inventarios> Repositorio = new RepositorioBase<Inventarios>();
            Inventarios i = Repositorio.Buscar((int)IDnumericUpDown.Value);
            return (i != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Inventarios> Repositorio = new RepositorioBase<Inventarios>();
            Inventarios i = new Inventarios();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            i = Repositorio.Buscar(id);
            if (i != null)
                LlenaCampo(i);
            else
                MessageBox.Show("No encontrado.");
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(ProductotextBox.Text))
            {
                MyErrorProvider.SetError(ProductotextBox, "No puede ser vacio.");
                paso = false;
            }
            if(FechadateTimePicker.Value > DateTime.Now)
            {
                MyErrorProvider.SetError(FechadateTimePicker, "No puede ser despues que hoy.");
                paso = false;
            }
            return paso;
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Inventarios> Repositorio = new RepositorioBase<Inventarios>();
            Inventarios i = new Inventarios();
            bool paso = false;


            if (!Validar())
                return;

            i = LlenaClase();


            if (IDnumericUpDown.Value == 0)
            {
                paso = Repositorio.Guardar(i);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar.", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Repositorio.Modificar(i);
            }

            if (paso)
                MessageBox.Show("Guardado", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Inventarios> Repositorio = new RepositorioBase<Inventarios>();

            MyErrorProvider.Clear();


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
