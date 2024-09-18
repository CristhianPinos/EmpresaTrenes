using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpresaTrenes.Models;

namespace EmpresaTrenes.Controllers
{
    internal class TrenesController
    {
        public List<TrenesModel> ObtenerTodos()
        {
            return TrenesModel.ObtenerTodos();
        }
        public TrenesModel ObtenerTrenPorId(int idTren)
        {
            return TrenesModel.ObtenerPorId(idTren);
        }
        public TrenesModel Insertar(TrenesModel tren)
        {
            return TrenesModel.Insertar(tren);
        } 
        public string Actualizar(TrenesModel tren)
        {
            return TrenesModel.Actualizar(tren);
        }
        public string Eliminar(int idTren)
        {
            return TrenesModel.Eliminar(idTren);
        }
    }
}
