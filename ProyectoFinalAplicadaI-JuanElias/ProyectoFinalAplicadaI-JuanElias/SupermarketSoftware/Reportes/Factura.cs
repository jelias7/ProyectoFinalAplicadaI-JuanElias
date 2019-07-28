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
    public partial class Factura : Form
    {
        private List<VentasDetalle> ListaVenta;
        public Factura(List<VentasDetalle> detalles)
        {
            this.ListaVenta = detalles;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoFactura listado = new ListadoFactura();
            listado.SetDataSource(ListaVenta);

            crystalReportViewer1.ReportSource = ListaVenta;
            crystalReportViewer1.Refresh();
        }
    }
}
