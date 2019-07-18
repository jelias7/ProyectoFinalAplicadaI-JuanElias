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
using System.Data.SqlClient;
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
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Expression<Func<Usuarios, bool>> filtro = x => true;
            List<Usuarios> usuario = new List<Usuarios>();
            var username = UsuariotextBox.Text;
            var password = ClavetextBox.Text;
            filtro = x => x.Usuario.Equals(username);
            usuario = repositorio.GetList(filtro);

                if (usuario.Exists(x => x.Usuario.Equals(username)))
                {
                    if (usuario.Exists(x => x.Clave.Equals(password)))
                    {
                        MainForm f = new MainForm();
                        f.Show();
                        this.Hide();
                    }
                }          
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            Sesion();
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
