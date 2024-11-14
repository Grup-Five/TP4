using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp4
{
    internal class GestionVuelo
    {
        private List<Vuelo> vuelos = new List<Vuelo>();
    
    public void AgregarVuelo(Vuelo vuelo)
    {
        vuelos.Add(vuelo);
    }

    public void RegistrarPasajeros(string codigoVuelo, int pasajeros)
    {
        Vuelo vuelo = vuelos.FirstOrDefault(v => v.CodigoVuelo == codigoVuelo);
        if (vuelo != null)
        {
            vuelo.PasajerosRegistrados += pasajeros;
        }
    }

    public double CalcularOcupacionMedia()
    {
        if (vuelos.Count == 0) return 0;
        return vuelos.Average(v => v.CalcularOcupacion());
    }

    public Vuelo VueloMayorOcupacion()
    {
        return vuelos.OrderByDescending(v => v.CalcularOcupacion()).FirstOrDefault();
    }

    public Vuelo BuscarVueloPorCodigo(string codigoVuelo)
    {
        return vuelos.FirstOrDefault(v => v.CodigoVuelo == codigoVuelo);
    }

    public List<Vuelo> ListarVuelosOrdenadosPorOcupacion()
    {
        return vuelos.OrderByDescending(v => v.CalcularOcupacion()).ToList();
    }

    public void GuardarDatosXML(string filePath)
    {
        var xmlDoc = new XElement("Vuelos",
            vuelos.Select(v => new XElement("Vuelo",
                new XElement("CodigoVuelo", v.CodigoVuelo),
                new XElement("FechaSalida", v.FechaSalida),
                new XElement("HoraSalida", v.HoraSalida),
                new XElement("FechaLlegada", v.FechaLlegada),
                new XElement("HoraLlegada", v.HoraLlegada),
                new XElement("Piloto", v.Piloto),
                new XElement("Copiloto", v.Copiloto),
                new XElement("CapacidadMaxima", v.CapacidadMaxima),
                new XElement("PasajerosRegistrados", v.PasajerosRegistrados)
            ))
        );
        xmlDoc.Save(filePath);
    }

    public void CargarDatosXML(string filePath)
    {
        var xmlDoc = XElement.Load(filePath);
        vuelos = xmlDoc.Elements("Vuelo").Select(v => new Vuelo
        {
            CodigoVuelo = v.Element("CodigoVuelo").Value,
            FechaSalida = DateTime.Parse(v.Element("FechaSalida").Value),
            HoraSalida = DateTime.Parse(v.Element("HoraSalida").Value),
            FechaLlegada = DateTime.Parse(v.Element("FechaLlegada").Value),
            HoraLlegada = DateTime.Parse(v.Element("HoraLlegada").Value),
            Piloto = v.Element("Piloto").Value,
            Copiloto = v.Element("Copiloto").Value,
            CapacidadMaxima = int.Parse(v.Element("CapacidadMaxima").Value),
            PasajerosRegistrados = int.Parse(v.Element("PasajerosRegistrados").Value)
        }).ToList();
    }
}

