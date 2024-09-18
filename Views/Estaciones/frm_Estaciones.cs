using EmpresaTrenes.Controllers;
using EmpresaTrenes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaTrenes.Views.Estaciones
{
    public partial class frm_Estaciones : Form
    {
        EstacionesController _estacionesController = new EstacionesController();
        EstacionesModel estacionModel = new EstacionesModel();
        int id = 0;
        public frm_Estaciones()
        {
            InitializeComponent();
        }
        private void frm_Estaciones_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
        private void CargarLista()
        {
            var listaEstaciones = _estacionesController.ObtenerTodos();
            lst_Estaciones.DataSource = null;
            lst_Estaciones.DataSource = listaEstaciones;
            lst_Estaciones.DisplayMember = "Ciudad";
            lst_Estaciones.ValueMember = "ID_Estacion";
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Ciudad.Text))
            {
                MessageBox.Show("Por favor, ingrese la ciudad de la estacion");
                return;
            }

            estacionModel = new EstacionesModel
            {
                Ciudad = txt_Ciudad.Text
            };

            if (id == 0)
            {
                var nuevaEstacion = _estacionesController.Insertar(estacionModel);
                if (nuevaEstacion != null)
                {
                    MessageBox.Show("Estacion guardada correctamente");
                }
                else
                {
                    MessageBox.Show("Error al guardar la estacion");
                }
            }
            else
            {
                estacionModel.ID_Estacion = id;
                var resultado = _estacionesController.Actualizar(estacionModel);
                if (resultado == "OK")
                {
                    MessageBox.Show("Estacion actualizada correctamente");
                }
                else
                {
                    MessageBox.Show("Error al actualizar la estacion");
                }
            }

            LimpiarCampos();
            CargarLista();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Estaciones.SelectedItem != null)
            {
                int idEstacion = Convert.ToInt32(lst_Estaciones.SelectedValue);
                var resultado = _estacionesController.Eliminar(idEstacion);

                if (resultado == "OK")
                {
                    MessageBox.Show("Estacion eliminada correctamente");
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la estacion");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una estacion para eliminar");
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
            txt_Ciudad.Text = "";
            id = 0;
        }
        private void lst_Estaciones_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lst_Estaciones.SelectedValue != null)
            {
                var estacion = _estacionesController.ObtenerTrenPorId((int)lst_Estaciones.SelectedValue);
                this.id = estacion.ID_Estacion;
                txt_Ciudad.Text = estacion.Ciudad;
            }
            else
            {
                MessageBox.Show("Seleccione una estacion de la lista");
            }
        }
    }
}