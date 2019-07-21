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
    public partial class rProveedores : Form
    {
        public rProveedores()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {

            IDnumericUpDown.Value = 0;
            NombrestextBox.Text = string.Empty;
            ContactotextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            TlfmaskedTextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            MyErrorProvider.Clear();

        }
        private Proveedores LlenaClase()
        {
            Proveedores p = new Proveedores();
            p.ProveedorId = Convert.ToInt32(IDnumericUpDown.Value);
            p.Nombres = NombrestextBox.Text;
            p.Contacto = ContactotextBox.Text;
            p.Email = EmailtextBox.Text;
            p.Telefono = TlfmaskedTextBox.Text;
            p.Direccion = DirecciontextBox.Text;
            return p;
        }

        private void LlenaCampo(Proveedores p)
        {
            IDnumericUpDown.Value = p.ProveedorId;
            NombrestextBox.Text = p.Nombres;
            ContactotextBox.Text = p.Contacto;
            EmailtextBox.Text = p.Email;
            TlfmaskedTextBox.Text = p.Telefono;
            DirecciontextBox.Text = p.Direccion;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            Proveedores p = Repositorio.Buscar((int)IDnumericUpDown.Value);
            return (p != null);
        }
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            Proveedores p = new Proveedores();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            p = Repositorio.Buscar(id);
            if (p != null)
                LlenaCampo(p);
            else
                MessageBox.Show("No encontrado.");
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public static bool RepetirProveedor(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Proveedores.Any(p => p.Nombres.Equals(descripcion)))
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
        public static bool RepetirEmail(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Proveedores.Any(p => p.Email.Equals(descripcion)))
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
        public static bool RepetirTelefono(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Proveedores.Any(p => p.Telefono.Equals(descripcion)))
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
        public static bool RepetirDireccion(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Proveedores.Any(p => p.Direccion.Equals(descripcion)))
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
        public static bool RepetirContacto(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Proveedores.Any(p => p.Contacto.Equals(descripcion)))
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
            if (string.IsNullOrWhiteSpace(NombrestextBox.Text))
            {
                MyErrorProvider.SetError(NombrestextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(EmailtextBox.Text))
            {
                MyErrorProvider.SetError(EmailtextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ContactotextBox.Text))
            {
                MyErrorProvider.SetError(ContactotextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                MyErrorProvider.SetError(DirecciontextBox, "No puede ser vacio.");
                paso = false;
            }
            if (!TlfmaskedTextBox.MaskCompleted)
            {
                MyErrorProvider.SetError(TlfmaskedTextBox, "No puede ser vacio.");
                paso = false;
            }
            return paso;
        }
        private bool ValidarRepeticion()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (RepetirProveedor(NombrestextBox.Text))
            {
                MyErrorProvider.SetError(NombrestextBox, "No se pueden repetir.");
                paso = false;
            }
            if (RepetirContacto(ContactotextBox.Text))
            {
                MyErrorProvider.SetError(ContactotextBox, "No se pueden repetir.");
                paso = false;
            }
            if (RepetirEmail(EmailtextBox.Text))
            {
                MyErrorProvider.SetError(EmailtextBox, "No se pueden repetir.");
                paso = false;
            }
            if (RepetirTelefono(TlfmaskedTextBox.Text))
            {
                MyErrorProvider.SetError(TlfmaskedTextBox, "No se pueden repetir.");
                paso = false;
            }
            if (RepetirDireccion(DirecciontextBox.Text))
            {
                MyErrorProvider.SetError(DirecciontextBox, "No se pueden repetir.");
                paso = false;
            }
            return paso;
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            Proveedores p = new Proveedores();
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

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();

            MyErrorProvider.Clear();

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (Repositorio.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No existe.");
        }

        private void TelefonotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
    }
}
