# Sistema de Gestión de Vuelos

## Descripción
Este proyecto es una aplicación de consola en C# que permite gestionar vuelos y sus ocupaciones. A través de un menú de opciones, el usuario puede agregar vuelos, registrar pasajeros, calcular la ocupación de la flota y buscar vuelos por código. Además, la aplicación permite guardar y recuperar los datos de vuelos en un archivo XML para mantener persistencia de la información.

## Funcionalidades
1. **Agregar un vuelo**: Permite al usuario agregar un vuelo especificando código, fechas y horas de salida y llegada, nombres de piloto y copiloto, y capacidad máxima.
2. **Registrar pasajeros**: Permite al usuario registrar la cantidad de pasajeros en un vuelo específico por código.
3. **Calcular ocupación media**: Calcula el promedio de ocupación de todos los vuelos registrados.
4. **Identificar vuelo con mayor ocupación**: Muestra el vuelo con el mayor porcentaje de ocupación.
5. **Buscar vuelo por código**: Permite encontrar y mostrar los detalles de un vuelo específico.
6. **Listar vuelos por ocupación**: Ordena y muestra los vuelos según su ocupación de mayor a menor.
7. **Guardar y recuperar datos**: Guarda los datos en un archivo XML, cargándolos automáticamente al inicio del programa.

## Instalación y Ejecución
1. Clona este repositorio:
   ```bash
   git clone https://github.com/Grup-Five/TSDS-TP4-ComisionA-ReinosoOctavio-PeraltaSofia-MartinezCandela-CornejoLucas.git
2.Abre el proyecto en tu entorno de desarrollo (como Visual Studio).
3.Compila y ejecuta el proyecto.
Uso
1.Al iniciar la aplicación, se mostrará un menú de opciones.
2.Ingresa el número de la opción que deseas ejecutar y sigue las instrucciones en pantalla.
3.Los datos de vuelos se guardarán automáticamente en un archivo XML al cerrar el programa y se cargarán al iniciar.
Tecnologías Utilizadas
C#
.NET
XML para almacenamiento de datos
Estructura del Código
Program.cs: Define el flujo principal de la aplicación y el menú interactivo.
Vuelo.cs: Clase que representa un vuelo, incluyendo propiedades como código, fecha, tripulación y capacidad.
Aerolinea.cs: Clase que define la aerolínea, con propiedades como razón social, teléfono y domicilio.
GestionVuelo.cs: Clase donde se podrían implementar métodos de gestión de vuelos (actualmente en desarrollo).

