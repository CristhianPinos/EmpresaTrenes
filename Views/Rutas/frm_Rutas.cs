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

namespace EmpresaTrenes.Views.Rutas
{
    public partial class frm_Rutas : Form
    {
        RutasController _rutasController = new RutasController();
        RutasModel rutaModel = new RutasModel();
        int id = 0;
        public frm_Rutas()
        {
            InitializeComponent();
        }
        private void frm_Rutas_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
        private void CargarLista()
        {
            var listaRutas = _rutasController.ObtenerTodas();
            lst_Rutas.DataSource = null;
            lst_Rutas.DataSource = listaRutas;
            lst_Rutas.DisplayMember = "ID_Ruta";
            lst_Rutas.ValueMember = "ID_Ruta";
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_IDTren.Text) || string.IsNullOrWhiteSpace(txt_IDEstacionOrigen.Text) ||
                string.IsNullOrWhiteSpace(txt_IDEstacionDestino.Text) || string.IsNullOrWhiteSpace(txt_Fecha.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }

            rutaModel = new RutasModel
            {
                ID_Tren = Convert.ToInt32(txt_IDTren.Text),
                ID_Estacion_Origen = Convert.ToInt32(txt_IDEstacionOrigen.Text),
                ID_Estacion_Destino = Convert.ToInt32(txt_IDEstacionDestino.Text),
                Fecha = Convert.ToDateTime(txt_Fecha.Text)
            };

            if (id == 0)
            {
                var nuevaRuta = _rutasController.Insertar(rutaModel);
                if (nuevaRuta != null)
                {
                    MessageBox.Show("Ruta guardada correctamente");
                }
                else
                {
                    MessageBox.Show("Error al guardar la ruta");
                }
            }
            else
            {
                rutaModel.ID_Ruta = id;
                var resultado = _rutasController.Actualizar(rutaModel);
                if (resultado == "OK")
                {
                    MessageBox.Show("Ruta actualizada correctamente");
                }
                else
                {
                    MessageBox.Show("Error al actualizar la ruta");
                }
            }

            LimpiarCampos();
            CargarLista();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Rutas.SelectedItem != null)
            {
                int idRuta = Convert.ToInt32(lst_Rutas.SelectedValue);
                var resultado = _rutasController.Eliminar(idRuta);

                if (resultado == "OK")
                {
                    MessageBox.Show("Ruta eliminada correctamente");
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la ruta");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una ruta para eliminar");
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
            txt_IDTren.Text = "";
            txt_IDEstacionOrigen.Text = "";
            txt_IDEstacionDestino.Text = "";
            txt_Fecha.Text = "";
            id = 0;
        }
        private void lst_Rutas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lst_Rutas.SelectedValue != null)
            {
                var ruta = _rutasController.ObtenerRutaPorId((int)lst_Rutas.SelectedValue);
                this.id = ruta.ID_Ruta;
                txt_IDTren.Text = ruta.ID_Tren.ToString();
                txt_IDEstacionOrigen.Text = ruta.ID_Estacion_Origen.ToString();
                txt_IDEstacionDestino.Text = ruta.ID_Estacion_Destino.ToString();
                txt_Fecha.Text = ruta.Fecha.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Seleccione una ruta de la lista");
            }
        }
    }
}
