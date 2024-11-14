using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace TSDS-TP4-ComisiónA-ReinosoOctavio-PeraltaSofia-MartinezCandela-CornejoLucas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorVuelos gestorVuelos = new GestorVuelos();
            string filePath = "vuelos.xml";
            gestorVuelos.CargarDatosXML(filePath);
            int opcionMenu;
            bool salir = false;
//hola
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
                        Console.WriteLine("Saliendo del sistema...");
                        salir = true;
                        return;
                    case 1:
                        //AgregarVuelo();
                        break;
                    case 2:
                        //RegistrarPasajeros();
                        break;
                    case 3:
                        //CalcularOcupacion();
                        break;
                    case 4:
                        //MayorOcupacion();
                        break;
                    case 5:
                        //BuscarVuelo();
                        break;
                    case 6:
                       //ListarVuelo
                        break;
                    default:
                        Console.WriteLine("El numero ingresado no es válido");
                        break;
                }

                Console.WriteLine("Seleccione alguna de las opciones del menu si desea realizar otra operación.");

            } while (!salir);

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
