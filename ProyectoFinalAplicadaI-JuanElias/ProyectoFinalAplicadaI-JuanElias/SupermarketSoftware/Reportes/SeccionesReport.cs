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
    public partial class SeccionesReport : Form
    {
        private List<Secciones> ListaSecciones;
        public SeccionesReport(List<Secciones> secciones)
        {
            this.ListaSecciones = secciones;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoSecciones listado = new ListadoSecciones();
            listado.SetDataSource(ListaSecciones);

            crystalReportViewer1.ReportSource = ListaSecciones;
            crystalReportViewer1.Refresh();
        }
    }
}
