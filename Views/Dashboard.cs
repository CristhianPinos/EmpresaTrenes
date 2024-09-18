using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpresaTrenes.Views.Trenes;
using EmpresaTrenes.Views.Estaciones;
using EmpresaTrenes.Views.Rutas;
using EmpresaTrenes.Views.Pasajeros;

namespace EmpresaTrenes.Views
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void trenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Trenes _frm_Trenes = new frm_Trenes();
            _frm_Trenes.ShowDialog();
        }

        private void estacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Estaciones _frm_Estaciones = new frm_Estaciones();
            _frm_Estaciones.ShowDialog();
        }

        private void rutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Rutas _frm_Rutas = new frm_Rutas();
            _frm_Rutas.ShowDialog();
        }

        private void pasajerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Pasajeros _frm_Pasajeros = new frm_Pasajeros();
            _frm_Pasajeros.ShowDialog();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Trenes_Principal _frm_Trenes_Principal = new frm_Trenes_Principal();
            _frm_Trenes_Principal.ShowDialog();
        }
    }
}
