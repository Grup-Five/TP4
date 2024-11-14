using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp4
{
    internal class Aerolinea
    {
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public List<Vuelo> Vuelos { get; set; }
        public Aerolinea()
{
    Vuelos = new List<Vuelo>();
}
    }
}
