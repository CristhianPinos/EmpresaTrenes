using EmpresaTrenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTrenes.Controllers
{
    internal class PasajerosController
    {
        public List<PasajerosModel> ObtenerTodos()
        {
            return PasajerosModel.ObtenerTodos();
        }
        public PasajerosModel ObtenerTrenPorId(int idPasajero)
        {
            return PasajerosModel.ObtenerPorId(idPasajero);
        }
        public PasajerosModel Insertar(PasajerosModel pasajero)
        {
            return PasajerosModel.Insertar(pasajero);
        }
        public string Actualizar(PasajerosModel pasajero)
        {
            return PasajerosModel.Actualizar(pasajero);
        }
        public string Eliminar(int idPasajero)
        {
            return PasajerosModel.Eliminar(idPasajero);
        }
    }
}
