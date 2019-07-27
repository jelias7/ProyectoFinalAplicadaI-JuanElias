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
    public partial class PersonasReportViewer : Form
    {
        private List<Usuarios> ListaUsuarios;
        public PersonasReportViewer(List<Usuarios> usuarios)
        {
            this.ListaUsuarios = usuarios;
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoU1 listado = new ListadoU1();
            listado.SetDataSource(ListaUsuarios);

            crystalReportViewer1.ReportSource = ListaUsuarios;
            crystalReportViewer1.Refresh();
        }
    }
}
