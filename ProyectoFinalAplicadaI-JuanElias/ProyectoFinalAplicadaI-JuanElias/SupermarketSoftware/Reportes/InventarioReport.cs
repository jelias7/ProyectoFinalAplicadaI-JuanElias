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
    public partial class InventarioReport : Form
    {
        private List<Inventarios> ListaInventario;
        public InventarioReport(List<Inventarios> inventarios)
        {
            this.ListaInventario = inventarios;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoInventario listado = new ListadoInventario();
            listado.SetDataSource(ListaInventario);

            crystalReportViewer1.ReportSource = ListaInventario;
            crystalReportViewer1.Refresh();
        }
    }
}
