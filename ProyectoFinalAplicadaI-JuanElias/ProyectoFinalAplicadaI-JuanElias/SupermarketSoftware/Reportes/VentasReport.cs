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
    public partial class VentasReport : Form
    {
        private List<Ventas> ListaVentas;
        public VentasReport(List<Ventas> ventas)
        {
            this.ListaVentas = ventas;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoVentas listado = new ListadoVentas();
            listado.SetDataSource(ListaVentas);

            crystalReportViewer1.ReportSource = ListaVentas;
            crystalReportViewer1.Refresh();
        }
    }
}
