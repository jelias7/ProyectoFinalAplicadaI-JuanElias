using BLL;
using Entidades;
using ProyectoFinalAplicadaI_JuanElias.SupermarketSoftware.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAplicadaI_JuanElias.SupermarketSoftware.Consultas
{
    public partial class cVentas : Form
    {
        private List<Ventas> Lista;
        public cVentas()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Ventas>();
            RepositorioBase<Ventas> r = new RepositorioBase<Ventas>();

            if (RangocheckBox.Checked == true)
            {
                if (CriteriotextBox.Text.Trim().Length > 0)
                {
                    switch (FiltrocomboBox.Text)
                    {
                        case "Todo":
                            listado = r.GetList(p => true);
                            break;

                        case "ID":
                            int parse;
                            if (!int.TryParse(CriteriotextBox.Text, out parse))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                int id = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.VentaId == id);
                            }
                            break;
                        case "Cliente":
                            listado = r.GetList(p => p.Cliente.Contains(CriteriotextBox.Text));
                            break;
                        case "Modo":
                            listado = r.GetList(p => p.Modo.Contains(CriteriotextBox.Text));
                            break;
                        case "ITBIS":
                            decimal parse2;
                            if (!decimal.TryParse(CriteriotextBox.Text, out parse2))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                decimal pr = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Itbis == pr);
                            }
                            break;
                        case "Subtotal":
                            decimal parse3;
                            if (!decimal.TryParse(CriteriotextBox.Text, out parse3))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                decimal co = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Subtotal == co);
                            }
                            break;
                        case "Total":
                            decimal parse4;
                            if (!decimal.TryParse(CriteriotextBox.Text, out parse4))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                decimal ga = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Total == ga);
                            }
                            break;

                    }
                    listado = listado.Where(c => c.Fecha.Date >= DesdedateTimePicker.Value.Date && c.Fecha.Date <= HastadateTimePicker.Value.Date).ToList();
                }
                else
                {
                    if (FiltrocomboBox.Text == string.Empty)
                    {
                        MessageBox.Show("El filtro no puede estar vacio.");
                    }
                    else
                       if ((string)FiltrocomboBox.Text != "Todo")
                    {
                        if (CriteriotextBox.Text == string.Empty)
                        {
                            MessageBox.Show("Al seleccionar uno diferente de Todo necesita escribir algo en el criterio.");
                        }
                    }
                    listado = r.GetList(p => true);
                    listado = listado.Where(c => c.Fecha.Date >= DesdedateTimePicker.Value.Date && c.Fecha.Date <= HastadateTimePicker.Value.Date).ToList();
                }
                Lista = listado;
                ConsultadataGridView.DataSource = listado;
            }
            else
            {
                if (CriteriotextBox.Text.Trim().Length > 0)
                {
                    switch (FiltrocomboBox.Text)
                    {
                        case "Todo":
                            listado = r.GetList(p => true);
                            break;

                        case "ID":
                            int parse;
                            if (!int.TryParse(CriteriotextBox.Text, out parse))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                int id = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.VentaId == id);
                            }
                            break;
                        case "Cliente":
                            listado = r.GetList(p => p.Cliente.Contains(CriteriotextBox.Text));
                            break;
                        case "Modo":
                            listado = r.GetList(p => p.Modo.Contains(CriteriotextBox.Text));
                            break;
                        case "ITBIS":
                            decimal parse2;
                            if (!decimal.TryParse(CriteriotextBox.Text, out parse2))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                decimal pr = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Itbis == pr);
                            }
                            break;
                        case "Subtotal":
                            decimal parse3;
                            if (!decimal.TryParse(CriteriotextBox.Text, out parse3))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                decimal co = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Subtotal == co);
                            }
                            break;
                        case "Total":
                            decimal parse4;
                            if (!decimal.TryParse(CriteriotextBox.Text, out parse4))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                decimal ga = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Total == ga);
                            }
                            break;
                    }
                }
                else
                {
                    if (FiltrocomboBox.Text == string.Empty)
                    {
                        MessageBox.Show("El filtro no puede estar vacio.");
                    }
                    else
                       if ((string)FiltrocomboBox.Text != "Todo")
                    {
                        if (CriteriotextBox.Text == string.Empty)
                        {
                            MessageBox.Show("Al seleccionar uno diferente de Todo necesita escribir algo en el criterio.");
                        }
                    }
                    else
                    {
                        listado = r.GetList(p => true);
                    }
                }
                Lista = listado;
                ConsultadataGridView.DataSource = listado;
            }
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (ConsultadataGridView.RowCount == 0)
            {
                MessageBox.Show("No se puede imprimir");
                return;
            }
            else
            {
                VentasReport v = new VentasReport(Lista);
                v.ShowDialog();
            }

        }
    }
}
