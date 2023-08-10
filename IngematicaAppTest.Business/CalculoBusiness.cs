using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngematicaAppTest.Business
{
    public partial class CalculoBusiness
    {
        public DateTime CalcularFechaLlegada( DateTime fechaPartida, int idLocalidadDestino, int idTipoTransporte, int idVialidad)
        {
            LocalidadBusiness localidadBusiness = new LocalidadBusiness();
            TipoTransporteBusiness tipoTransporteBusiness = new TipoTransporteBusiness();
            VialidadBusiness vialidadBusiness = new VialidadBusiness(); 

            int diasDemora = localidadBusiness.GetById(idLocalidadDestino).DiasDemora;
            decimal coeficienteDemora = tipoTransporteBusiness.GetById(idTipoTransporte).CoeficineteDemora;
            decimal adicionalVialidad = vialidadBusiness.GetById(idVialidad).Adicional;

            decimal coeficienteTotal = coeficienteDemora +  adicionalVialidad;
            int diasTotales = (int)Math.Round(diasDemora * coeficienteTotal);
          
            DateTime fechaLlegada = fechaPartida.AddDays(diasTotales);
            while (fechaPartida <= fechaLlegada)
            {
                if (fechaPartida.DayOfWeek == DayOfWeek.Saturday || fechaPartida.DayOfWeek == DayOfWeek.Sunday)
                {
                    fechaLlegada = fechaLlegada.AddDays(1);
                }
                    fechaPartida = fechaPartida.AddDays(1);
            }

            return fechaLlegada;
        }
    }
}
