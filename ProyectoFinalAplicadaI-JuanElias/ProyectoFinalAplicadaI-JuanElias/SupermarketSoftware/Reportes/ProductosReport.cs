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
    public partial class ProductosReport : Form
    {
        private List<Productos> ListaProductos;
        public ProductosReport(List<Productos> productos)
        {
            this.ListaProductos = productos;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoProductos listado = new ListadoProductos();
            listado.SetDataSource(ListaProductos);

            crystalReportViewer1.ReportSource = ListaProductos;
            crystalReportViewer1.Refresh();
        }
    }
}
