using IngematicaAppTest.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngematicaAppTest.Service
{
    public partial class CalculoService
    {
        public DateTime CalcularFechaLlegada(DateTime fechaPartida, int idLocalidadDestino, int idTipoTransporte, int idVialidad )
        {
            CalculoBusiness calculoBusiness = new CalculoBusiness();

            DateTime fechaLLegada = calculoBusiness.CalcularFechaLlegada( fechaPartida, idLocalidadDestino, idTipoTransporte, idVialidad);

            return fechaLLegada;
        }
    }
}
