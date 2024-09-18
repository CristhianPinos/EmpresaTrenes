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

namespace EmpresaTrenes.Views.Pasajeros
{
    public partial class frm_Pasajeros : Form
    {
        PasajerosController _pasajerosController = new PasajerosController();
        PasajerosModel pasajeroModel = new PasajerosModel();
        int id = 0;
        public frm_Pasajeros()
        {
            InitializeComponent();
        }

        private void frm_Pasajeros_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
        private void CargarLista()
        {
            var listaPasajeros = _pasajerosController.ObtenerTodos();
            lst_Pasajeros.DataSource = null;
            lst_Pasajeros.DataSource = listaPasajeros;
            lst_Pasajeros.DisplayMember = "Nombre";
            lst_Pasajeros.ValueMember = "ID_Pasajero";
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del pasajero");
                return;
            }

            pasajeroModel = new PasajerosModel
            {
                Nombre = txt_Nombre.Text,
                ID_Ruta = Convert.ToInt32(txt_IDRuta.Text)
            };

            if (id == 0)
            {
                var nuevoPasajero = _pasajerosController.Insertar(pasajeroModel);
                if (nuevoPasajero != null)
                {
                    MessageBox.Show("Pasajero guardado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al guardar el pasajero");
                }
            }
            else
            {
                pasajeroModel.ID_Pasajero = id;
                var resultado = _pasajerosController.Actualizar(pasajeroModel);
                if (resultado == "OK")
                {
                    MessageBox.Show("Pasajero actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el pasajero");
                }
            }

            LimpiarCampos();
            CargarLista();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Pasajeros.SelectedItem != null)
            {
                int idPasajero = Convert.ToInt32(lst_Pasajeros.SelectedValue);
                var resultado = _pasajerosController.Eliminar(idPasajero);

                if (resultado == "OK")
                {
                    MessageBox.Show("Pasajero eliminado correctamente");
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el pasajero");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pasajero para eliminar");
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
            txt_Nombre.Text = "";
            txt_IDRuta.Text = "";
            id = 0;
        }

        private void lst_Pasajeros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lst_Pasajeros.SelectedValue != null)
            {
                var pasajero = _pasajerosController.ObtenerTrenPorId((int)lst_Pasajeros.SelectedValue);
                this.id = pasajero.ID_Pasajero;
                txt_Nombre.Text = pasajero.Nombre;
                txt_IDRuta.Text = pasajero.ID_Ruta.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un pasajero de la lista");
            }
        }
    }
}
