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
using BLL;
using Entidades;
using System.Linq.Expressions;

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

            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Expression<Func<Usuarios, bool>> filtro = x => true;
            List<Usuarios> usuario = new List<Usuarios>();
            var username = UsuariotextBox.Text;
            var password = ClavetextBox.Text;
            filtro = x => x.Usuario.Equals(username);
            usuario = Repositorio.GetList(filtro);

            if (usuario.Count > 0)
            {
                if (usuario.Exists(x => x.Usuario.Equals(username)))
                {
                    if (usuario.Exists(x => x.Clave.Equals(Eramake.eCryptography.Encrypt(password))))
                    {

                        List<Usuarios> id = Repositorio.GetList(U => U.Usuario == UsuariotextBox.Text);
                        MainForm f = new MainForm(id[0].UsuarioId);
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Clave incorrecta.", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else
            {
                if (UsuariotextBox.Text == string.Empty || ClavetextBox.Text == string.Empty)
                    MessageBox.Show("Ingrese en todos los campos.", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (usuario.Count == 0)
                    {
                        Repositorio.Guardar(new Usuarios()
                        {
                            Usuario = "admin",
                            Clave = Eramake.eCryptography.Encrypt("admin"),
                            Nombres = "Juan Elias",
                            Email = "juanelias@admin.com",
                            FechaCreacion = DateTime.Now
                        });
                        MessageBox.Show("Al no existir usuario se ha creado uno." + Environment.NewLine + "Usuario = admin" + Environment.NewLine + "Clave = admin", "Supermarket Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }      
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            Sesion();
        }
    }
}
