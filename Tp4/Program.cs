using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Tp4
{
    internal class Program
    {
        private const string ArchivoDatos = "aerolinea.xml";
        private static Aerolinea aerolinea = CargarDatosXML();

 static void Main(string[] args)
 {
     int opcionMenu;
     bool salir = false;

     Console.WriteLine("Bienvenido, ingrese una opcion");
     Console.WriteLine("Ingrese la opcion que desea elegir:\n" +
         "0. Salir del sistema. \n" +
         "1. Agregar un vuelo. \n" +
         "2. Registrar pasajeros en un vuelo. \n" +
         "3. Calcular ocupación media de la flota. \n" +
         "4. Vuelo con mayor ocupación. \n" +
         "5. Buscar vuelo por código. \n" +
         "6. Listar vuelos ordenados por ocupación.");
     do
     {

         opcionMenu = int.Parse(Console.ReadLine());

         switch (opcionMenu)
         {
             case 0:
                 GuardarDatosXML();
                 Console.WriteLine("Saliendo del sistema...");
                 salir = true;
                 return;
             case 1:
                 AgregarVuelo();
                 break;
             case 2:
                 RegistrarPasajeros();
                 break;
             case 3:
                 CalcularOcupacionMedia();
                 break;
             case 4:
                 MostrarVueloMayorOcupacion();
                 break;
             case 5:
                 BuscarVueloPorCodigo();
                 break;
             case 6:
                 ListarVuelosPorOcupacion();
                 break;
             case 7:
                 GuardarDatosXML();
                 Console.WriteLine("Datos guardados correctamente.");
                 break;
             default:
                 Console.WriteLine("El numero ingresado no es válido");
                 break;
         }

         Console.WriteLine("Seleccione alguna de las opciones del menu si desea realizar otra operación.");

     } while (!salir);

 }
 public static void MostrarOpciones()
 {
     Console.WriteLine("\n=== Sistema de Gestión de Vuelos ===\n");
     Console.WriteLine("1- Agregar un nuevo vuelo.");
     Console.WriteLine("2- Registrar pasajeros en un vuelo.");
     Console.WriteLine("3- Calcular ocupación media de la flota.");
     Console.WriteLine("4- Mostrar vuelo con mayor ocupación.");
     Console.WriteLine("5- Buscar vuelo por código.");
     Console.WriteLine("6- Listar vuelos por ocupación.");
     Console.WriteLine("7- Guardar datos.");
     Console.WriteLine("0- Salir.");
     Console.Write("Seleccione una opción: ");
 }

 public static void AgregarVuelo()
 {
     Console.Write("Ingrese el código de vuelo: ");
     string codigoVuelo = Console.ReadLine();
     Console.Write("Ingrese fecha y hora de salida (yyyy-mm-dd hh:mm): ");
     DateTime fechaSalida = DateTime.Parse(Console.ReadLine());
     Console.Write("Ingrese fecha y hora de llegada (yyyy-mm-dd hh:mm): ");
     DateTime fechaLlegada = DateTime.Parse(Console.ReadLine());
     Console.Write("Ingrese el nombre del piloto: ");
     string piloto = Console.ReadLine();
     Console.Write("Ingrese el nombre del copiloto: ");
     string copiloto = Console.ReadLine();
     Console.Write("Ingrese la capacidad máxima del vuelo: ");
     int capacidadMaxima = int.Parse(Console.ReadLine());

     aerolinea.Vuelos.Add(new Vuelo
     {
         CodigoVuelo = codigoVuelo,
         FechaHoraSalida = fechaSalida,
         FechaHoraLlegada = fechaLlegada,
         Piloto = piloto,
         Copiloto = copiloto,
         CapacidadMaxima = capacidadMaxima,
         PasajerosActuales = 0
     });

     Console.WriteLine("Vuelo agregado correctamente.");
 }

 public static void RegistrarPasajeros()
 {
     Console.Write("Ingrese el código de vuelo: ");
     string codigoVuelo = Console.ReadLine();
     Vuelo vuelo = aerolinea.Vuelos.Find(v => v.CodigoVuelo == codigoVuelo);

     if (vuelo == null)
     {
         Console.WriteLine("Vuelo no encontrado.");
         return;
     }

     Console.Write("Ingrese el número de pasajeros a registrar: ");
     int pasajeros = int.Parse(Console.ReadLine());

     if (vuelo.PasajerosActuales + pasajeros > vuelo.CapacidadMaxima)
     {
         Console.WriteLine("No hay suficiente capacidad en el vuelo.");
     }
     else
     {
         vuelo.PasajerosActuales += pasajeros;
         Console.WriteLine("Pasajeros registrados correctamente.");
     }
 }

 public static void CalcularOcupacionMedia()
 {
     if (aerolinea.Vuelos.Count == 0)
     {
         Console.WriteLine("No hay vuelos registrados.");
         return;
     }

     double ocupacionTotal = 0;
     foreach (Vuelo vuelo in aerolinea.Vuelos)
     {
         ocupacionTotal += vuelo.PorcentajeOcupacion;
     }

     double ocupacionMedia = ocupacionTotal / aerolinea.Vuelos.Count;
     Console.WriteLine($"Ocupación media de la flota: {ocupacionMedia:F2}%");
 }

 public static void MostrarVueloMayorOcupacion()
 {
     Vuelo vueloMaxOcupacion = null;
     double maxOcupacion = 0;

     foreach (Vuelo vuelo in aerolinea.Vuelos)
     {
         if (vuelo.PorcentajeOcupacion > maxOcupacion)
         {
             maxOcupacion = vuelo.PorcentajeOcupacion;
             vueloMaxOcupacion = vuelo;
         }
     }

     if (vueloMaxOcupacion != null)
     {
         Console.WriteLine($"Vuelo con mayor ocupación: {vueloMaxOcupacion.CodigoVuelo} - Ocupación: {maxOcupacion:F2}%");
     }
     else
     {
         Console.WriteLine("No hay vuelos registrados.");
     }
 }

 public static void BuscarVueloPorCodigo()
 {
     Console.Write("Ingrese el código de vuelo: ");
     string codigo = Console.ReadLine();
     Vuelo vuelo = aerolinea.Vuelos.Find(v => v.CodigoVuelo == codigo);

     if (vuelo != null)
     {
         Console.WriteLine($"Código: {vuelo.CodigoVuelo} - Ocupación: {vuelo.PorcentajeOcupacion:F2}%");
         Console.WriteLine($"Salida: {vuelo.FechaHoraSalida} - Llegada: {vuelo.FechaHoraLlegada}");
         Console.WriteLine($"Piloto: {vuelo.Piloto} - Copiloto: {vuelo.Copiloto}");
     }
     else
     {
         Console.WriteLine("Vuelo no encontrado.");
     }
 }

 public static void ListarVuelosPorOcupacion()
 {
     foreach (var vuelo in aerolinea.Vuelos.OrderByDescending(v => v.PorcentajeOcupacion))
     {
         Console.WriteLine($"Código: {vuelo.CodigoVuelo} - Ocupación: {vuelo.PorcentajeOcupacion:F2}%");
     }
 }

 public static void GuardarDatosXML()
 {
     try
     {
         using (StreamWriter writer = new StreamWriter(ArchivoDatos))
         {
             XmlSerializer serializer = new XmlSerializer(typeof(Aerolinea));
             serializer.Serialize(writer, aerolinea);
         }
     }
     catch (Exception ex)
     {
         Console.WriteLine("Error al guardar los datos: " + ex.Message);
     }
 }

 public static Aerolinea CargarDatosXML()
 {
     if (!File.Exists(ArchivoDatos))
     {
         return new Aerolinea();
     }

     try
     {
         using (StreamReader reader = new StreamReader(ArchivoDatos))
         {
             XmlSerializer serializer = new XmlSerializer(typeof(Aerolinea));
             return (Aerolinea)serializer.Deserialize(reader);
         }
     }
     catch
     {
         Console.WriteLine("Error al cargar los datos.");
         return new Aerolinea();
     }
 }

        /*1Agregar un vuelo: Permite al usuario agregar un nuevo vuelo indicando su código de vuelo,fecha y hora de salida,
          fecha y hora de llegada, tripulantes de cabina (nombres de piloto y copiloto) y capacidad máxima.

           2Registrar pasajeros en un vuelo: Permite al usuario ingresar el número de pasajeros que subieron a un vuelo
           específico (indicando su código de vuelo).

           3Calcular ocupación media de la flota: Calcula el promedio de ocupación de todos los vuelos registrados.

           4Vuelo con mayor ocupación: Identifica y muestra el vuelo que tiene el mayor porcentaje de ocupación.

           5Buscar vuelo por código: Permite al usuario ingresar el código de un vuelo específico y muestra sus detalles
           si existe, junto con su porcentaje de ocupación.

           6Listar vuelos ordenados por ocupación: Muestra todos los vuelos ordenados según su porcentaje de ocupación,
           de mayor a menor.

           7Cargar datos: Guarda los datos en un archivo XML. Los datos deben recuperarse cada vez que se inicie
           el programa. */

    }
}
