using EmpresaTrenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTrenes.Controllers
{
    internal class EstacionesController
    {
        public List<EstacionesModel> ObtenerTodos()
        {
            return EstacionesModel.ObtenerTodos();
        }
        public EstacionesModel ObtenerTrenPorId(int idEstacion)
        {
            return EstacionesModel.ObtenerPorId(idEstacion);
        }
        public EstacionesModel Insertar(EstacionesModel estacion)
        {
            return EstacionesModel.Insertar(estacion);
        }
        public string Actualizar(EstacionesModel estacion)
        {
            return EstacionesModel.Actualizar(estacion);
        }
        public string Eliminar(int idEstacion)
        {
            return EstacionesModel.Eliminar(idEstacion);
        }
    }
}
