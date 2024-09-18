using EmpresaTrenes.Controllers;
using EmpresaTrenes.Models;
using EmpresaTrenes.Config;
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
    public partial class frm_Trenes : Form
    {
        TrenesController _trenesController = new TrenesController();
        TrenesModel trenModel = new TrenesModel();
        int id = 0;
        public frm_Trenes()
        {
            InitializeComponent();
        }
        private void frm_Trenes_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
        private void CargarLista()
        {
            var listaTrenes = _trenesController.ObtenerTodos();
            lst_Trenes.DataSource = null;
            lst_Trenes.DataSource = listaTrenes;
            lst_Trenes.DisplayMember = "Modelo";
            lst_Trenes.ValueMember = "ID_Tren";
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Modelo.Text))
            {
                MessageBox.Show("Por favor, ingrese el modelo del tren");
                return;
            }

            trenModel = new TrenesModel
            {
                Modelo = txt_Modelo.Text
            };

            if (id == 0)
            {
                var nuevoTren = _trenesController.Insertar(trenModel);
                if (nuevoTren != null)
                {
                    MessageBox.Show("Tren guardado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al guardar el tren");
                }
            }
            else
            {
                trenModel.ID_Tren = id;
                var resultado = _trenesController.Actualizar(trenModel);
                if (resultado == "OK")
                {
                    MessageBox.Show("Tren actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el tren");
                }
            }

            LimpiarCampos();
            CargarLista();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Trenes.SelectedItem != null)
            {
                int idTren = Convert.ToInt32(lst_Trenes.SelectedValue);
                var resultado = _trenesController.Eliminar(idTren);

                if (resultado == "OK")
                {
                    MessageBox.Show("Tren eliminado correctamente");
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el tren");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un tren para eliminar");
            }
        }
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LimpiarCampos()
        {
            txt_Modelo.Text = "";
            id = 0;
        }
        private void lst_Trenes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lst_Trenes.SelectedValue != null)
            {
                var tren = _trenesController.ObtenerTrenPorId((int)lst_Trenes.SelectedValue);
                this.id = tren.ID_Tren;
                txt_Modelo.Text = tren.Modelo;
            }
            else
            {
                MessageBox.Show("Seleccione un tren de la lista");
            }
        }
    }
}