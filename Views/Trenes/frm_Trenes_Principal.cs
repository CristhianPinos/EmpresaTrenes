using EmpresaTrenes.Controllers;
using EmpresaTrenes.Models;
using EmpresaTrenes.Views.Rutas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaTrenes.Views.Trenes
{
    public partial class frm_Trenes_Principal : Form
    {
        TrenesController _trenesController = new TrenesController();
        List<TrenesModel> _trenesModel = new List<TrenesModel>();
        public frm_Trenes_Principal()
        {
            InitializeComponent();
        }
        public void cargaDataGridView()
        {
            dgv_Trenes.DataSource = null;
            _trenesModel = _trenesController.ObtenerTodos();
            dgv_Trenes.DataSource = _trenesModel;
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            frm_Reportes_Trenes _Reportes_Trenes = new frm_Reportes_Trenes();
            _Reportes_Trenes.ShowDialog();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Trenes_Principal_Load(object sender, EventArgs e)
        {
            cargaDataGridView();
        }
    }
}
