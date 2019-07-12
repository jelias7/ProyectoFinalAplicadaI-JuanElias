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

namespace ProyectoFinalAplicadaI_JuanElias.SupermarketSoftware.Reportes
{
    public partial class ReporteUsuarios : Form
    {
        private List<Usuarios> Lista;

        public ReporteUsuarios(List<Usuarios> usuarios)
        {
            this.Lista = usuarios;
            InitializeComponent();
        }

        private void crystalReportViewer_Load(object sender, EventArgs e)
        {
            ListadoUsuarios listadoUsuarios = new ListadoUsuarios();
            listadoUsuarios.SetDataSource(Lista);

            crystalReportViewer.ReportSource = listadoUsuarios;
            crystalReportViewer.Refresh();
        }
    }
}
