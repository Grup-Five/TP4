using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp4
{
    [Serializable]
    internal class Vuelo
    {
       public string CodigoVuelo { get; set; }
       public DateTime FechaHoraSalida { get; set; }
       public DateTime FechaHoraLlegada { get; set; }
       public string Piloto { get; set; }
       public string Copiloto { get; set; }
       public int CapacidadMaxima { get; set; }
       public int PasajerosActuales { get; set; }
       public double PorcentajeOcupacion => CapacidadMaxima > 0 ? (double)PasajerosActuales / CapacidadMaxima * 100 : 0;
    }
}

