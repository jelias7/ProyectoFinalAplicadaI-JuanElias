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
    public partial class ProveedoresReport : Form
    {
        private List<Proveedores> ListaProveedores;
        public ProveedoresReport(List<Proveedores> proveedores)
        {
            this.ListaProveedores = proveedores;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoProveedores listado = new ListadoProveedores();
            listado.SetDataSource(ListaProveedores);

            crystalReportViewer1.ReportSource = ListaProveedores;
            crystalReportViewer1.Refresh();
        }
    }
}
