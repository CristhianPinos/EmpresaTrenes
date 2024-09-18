using EmpresaTrenes.Controllers;
using EmpresaTrenes.Models;
using Microsoft.Reporting.WinForms;
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
    public partial class frm_Reportes_Trenes : Form
    {
        TrenesController _trenesController = new TrenesController();
        public frm_Reportes_Trenes()
        {
            InitializeComponent();
        }

        private void frm_Reportes_Trenes_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Login.Reportes.Trenes.rdlc";

            List<TrenesModel> trenesModel = _trenesController.ObtenerTodos();
            ReportDataSource fuentedatos = new ReportDataSource("DataSet1", trenesModel);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(fuentedatos);

            reportViewer1.RefreshReport();
        }
    }
}
