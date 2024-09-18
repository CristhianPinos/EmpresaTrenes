using EmpresaTrenes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTrenes.Controllers
{
    internal class RutasController
    {
        public List<RutasModel> ObtenerTodas()
        {
            return RutasModel.ObtenerTodas();
        }
        public RutasModel ObtenerRutaPorId(int idRuta)
        {
            return RutasModel.ObtenerPorId(idRuta);
        }
        public RutasModel Insertar(RutasModel ruta)
        {
            return RutasModel.Insertar(ruta);
        }
        public string Actualizar(RutasModel ruta)
        {
            return RutasModel.Actualizar(ruta);
        }
        public string Eliminar(int idRuta)
        {
            return RutasModel.Eliminar(idRuta);
        }
    }
}
