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
        public frm_Reportes_Trenes()
        {
            InitializeComponent();
        }

        private void frm_Reportes_Trenes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.Trenes' Puede moverla o quitarla según sea necesario.
            this.trenesTableAdapter.Fill(this.dataSet1.Trenes);


            this.reportViewer1.RefreshReport();
        }
    }
}
