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
    public partial class rSecciones : Form
    {
        public rSecciones()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {

            IDnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            MyErrorProvider.Clear();

        }
        private Secciones LlenaClase()
        {
            Secciones s = new Secciones();
            s.SeccionId = Convert.ToInt32(IDnumericUpDown.Value);
            s.Nombre = NombretextBox.Text;

            return s;
        }

        private void LlenaCampo(Secciones s)
        {
            IDnumericUpDown.Value = s.SeccionId;
            NombretextBox.Text = s.Nombre;           
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Secciones> Repositorio = new RepositorioBase<Secciones>();
            Secciones s = Repositorio.Buscar((int)IDnumericUpDown.Value);
            return (s != null);
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
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Secciones> Repositorio = new RepositorioBase<Secciones>();
            Secciones s = new Secciones();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            s = Repositorio.Buscar(id);
            if (s != null)
                LlenaCampo(s);
            else
                MessageBox.Show("No encontrado.");
        }
        public static bool RepetirSeccion(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Secciones.Any(p => p.Nombre.Equals(descripcion)))
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
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                MyErrorProvider.SetError(NombretextBox, "No puede ser vacio.");
                paso = false;
            }
            if (RepetirSeccion(NombretextBox.Text))
            {
                MyErrorProvider.SetError(NombretextBox, "No se pueden repetir.");
                paso = false;
            }
            return paso;
        }
            private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Secciones> Repositorio = new RepositorioBase<Secciones>();
            Secciones s = new Secciones();
            bool paso = false;
            s = LlenaClase();

            if (IDnumericUpDown.Value == 0)
            {
                if (!Validar())
                    return;
                paso = Repositorio.Guardar(s);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Repositorio.Modificar(s);
            }

            if (paso)
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Secciones> Repositorio = new RepositorioBase<Secciones>();

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
