using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngematicaAppTest.Model;

namespace IngematicaAppTest.Business
{
    public partial class LocalidadBusiness
    {
        public List<LocalidadModel> GetList()
        {
            List<LocalidadModel> lista = SetList();

            return lista;
        }

        public LocalidadModel GetById(int id)
        {
            List<LocalidadModel> lista = SetList();

            LocalidadModel localidad = lista.Where(x => x.IdLocalidad == id).FirstOrDefault();

            return localidad;
        }

        private static List<LocalidadModel> SetList()
        {
            List<LocalidadModel> lista = new List<LocalidadModel>
            {
                new LocalidadModel { IdLocalidad = 1, Nombre = "CAPITAL FEDERAL", DiasDemora = 1 },
                new LocalidadModel { IdLocalidad = 2, Nombre = "DON TORCUATO", DiasDemora = 1 },
                new LocalidadModel { IdLocalidad = 3, Nombre = "PRESIDENTE DERQUI", DiasDemora = 2 },
                new LocalidadModel { IdLocalidad = 4, Nombre = "SAN FERNANDO", DiasDemora = 1 },
                new LocalidadModel { IdLocalidad = 5, Nombre = "NORDELTA", DiasDemora = 2 },
                new LocalidadModel { IdLocalidad = 6, Nombre = "LAS HERAS GRAL.", DiasDemora = 3 },
                new LocalidadModel { IdLocalidad = 7, Nombre = "MORENO", DiasDemora = 1 }
            };
            return lista;
        }
    }
}
