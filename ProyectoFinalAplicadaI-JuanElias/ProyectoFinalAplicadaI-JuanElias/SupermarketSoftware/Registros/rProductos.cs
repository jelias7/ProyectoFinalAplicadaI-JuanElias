﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAplicadaI_JuanElias.SupermarketSoftware.Registros
{
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
        }

        private void AddProveedorbutton_Click(object sender, EventArgs e)
        {
            rProveedores r = new rProveedores();
            r.Show();
        }

        private void AddSeccionbutton_Click(object sender, EventArgs e)
        {
            rSecciones r = new rSecciones();
            r.Show();
        }
    }
}
