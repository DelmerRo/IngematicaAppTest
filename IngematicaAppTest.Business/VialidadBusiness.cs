using IngematicaAppTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngematicaAppTest.Business
{
    public partial class VialidadBusiness
    {
        public List<VialidadModel> GetList()
        {
            List<VialidadModel> lista = SetList();

            return lista;
        }

        public VialidadModel GetById(int id)
        {
            List<VialidadModel> lista = SetList();

            VialidadModel tipoTransporte = lista.Where(x => x.IdVialidad == id).FirstOrDefault();

            return tipoTransporte;
        }

        private static List<VialidadModel> SetList()
        {
            List<VialidadModel> lista = new List<VialidadModel>
            {
                new VialidadModel { IdVialidad = 1, Nombre = "Ruta", Adicional = 0.1m },
                new VialidadModel { IdVialidad = 2, Nombre = "Autopista", Adicional = 0.0m }
            };
            return lista;
        }

    }
}
