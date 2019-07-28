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
    public partial class ClientesReport : Form
    {
        private List<Clientes> ListaClientes;
        public ClientesReport(List<Clientes> clientes)
        {
            this.ListaClientes = clientes;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoClientes listado = new ListadoClientes();
            listado.SetDataSource(ListaClientes);

            crystalReportViewer1.ReportSource = ListaClientes;
            crystalReportViewer1.Refresh();
        }
    }
}
