using IngematicaAppTest.Business;
using IngematicaAppTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngematicaAppTest.Service
{
    public partial class VialidadService
    {
        public List<VialidadModel> GetList()
        {
            VialidadBusiness v = new VialidadBusiness();

            return v.GetList();
        }

        public VialidadModel GetById(int id)
        {
            VialidadBusiness v = new VialidadBusiness();

            VialidadModel vialidad = v.GetById(id);

            return vialidad;
        }
    }
}
