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
        public string CodigoVuuelo { get; set; } 
        public DateTime FechaSalida { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime HoraLLegada { get; set; }
        public string Piloto { get; set; }
        public string Copiloto { get; set; }
        public int CapacidadMaxima { get; set; }




    }
}

