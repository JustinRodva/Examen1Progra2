using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Progra2
{ 

class Empleado

    {
        // Atributos de la clase Empleado
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public double Salario { get; set; }

        public Empleado(string cedula, string nombre, string direccion, string telefono, double salario)
        {
            Cedula = cedula;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Salario = salario;
        }
    }

    class Menu
    {
        private Empleado[] empleados; 
        private int empleadoCount = 0; 

        
        public Menu(int maxEmpleados)
        {
            empleados = new Empleado[maxEmpleados];
        }

   
        public void MostrarMenu()
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
        }

        public void AgregarEmpleado()
        {
            if (empleadoCount < empleados.Length)
            {
                Console.Write("Cédula: ");
                string cedula = Console.ReadLine();
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Dirección: ");
                string direccion = Console.ReadLine();
                Console.Write("Teléfono: ");
                string telefono = Console.ReadLine();
                Console.Write("Salario: ");
                double salario = double.Parse(Console.ReadLine());

                Empleado nuevoEmpleado = new Empleado(cedula, nombre, direccion, telefono, salario);
                empleados[empleadoCount] = nuevoEmpleado;
                empleadoCount++;
                Console.WriteLine("Empleado agregado con éxito.");
            }
            else
            {
                Console.WriteLine("No se pueden agregar más empleados. El límite se ha alcanzado.");
            }
        }

        public void ConsultarEmpleados()
        {
            Console.WriteLine("Lista de Empleados:");
            foreach (var empleado in empleados.Where(e => e != null))
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}");
            }
        }

        public void ModificarEmpleado(string cedula)
        {
            var empleadoAModificar = empleados.FirstOrDefault(e => e?.Cedula == cedula);
            if (empleadoAModificar != null)
            {
                Console.Write("Nuevo Nombre: ");
                empleadoAModificar.Nombre = Console.ReadLine();
                Console.Write("Nueva Dirección: ");
                empleadoAModificar.Direccion = Console.ReadLine();
                Console.Write("Nuevo Teléfono: ");
                empleadoAModificar.Telefono = Console.ReadLine();
                Console.Write("Nuevo Salario: ");
                empleadoAModificar.Salario = double.Parse(Console.ReadLine());
                Console.WriteLine("Empleado modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void BorrarEmpleado(string cedula)
        {
            for (int i = 0; i < empleadoCount; i++)
            {
                if (empleados[i]?.Cedula == cedula)
                {
                    empleados[i] = null;
                    Console.WriteLine("Empleado eliminado con éxito.");
                    return;
                }
            }
            Console.WriteLine("Empleado no encontrado.");
        }

        public void InicializarArreglos()
        {
            empleados = new Empleado[empleados.Length];
            empleadoCount = 0;
            Console.WriteLine("Arreglos inicializados.");
        }

        public void MostrarSubMenuReportes()
        {
            Console.WriteLine("Submenú de Reportes:");
            Console.WriteLine("1. Consultar empleados con número de cédula");
            Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
            Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
            Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo de todos los empleados");
            Console.WriteLine("5. Volver al Menú Principal");
        }

        public void ConsultarEmpleadoPorCedula(string cedula)
        {
            var empleado = empleados.FirstOrDefault(e => e?.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void ListarEmpleadosOrdenadosPorNombre()
        {
            var empleadosOrdenados = empleados.Where(e => e != null).OrderBy(e => e.Nombre);
            foreach (var empleado in empleadosOrdenados)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre}, Cédula: {empleado.Cedula}");
            }
        }

      
        public void CalcularPromedioSalarios()
        {
            var salarios = empleados.Where(e => e != null).Select(e => e.Salario);
            double promedio = salarios.Any() ? salarios.Average() : 0;
            Console.WriteLine($"Promedio de salarios: {promedio}");
        }

        public void CalcularSalariosMinMax()
        {
            var salarios = empleados.Where(e => e != null).Select(e => e.Salario);
            double salarioMax = salarios.Any() ? salarios.Max() : 0;
            double salarioMin = salarios.Any() ? salarios.Min() : 0;
            Console.WriteLine($"Salario más alto: {salarioMax}");
            Console.WriteLine($"Salario más bajo: {salarioMin}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(100); 
            while (true)
            {
                menu.MostrarMenu();
                Console.Write("Selecciona una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        menu.AgregarEmpleado();
                        break;
                    case 2:
                        menu.ConsultarEmpleados();
                        break;
                    case 3:
                        Console.Write("Ingresa la cédula del empleado a modificar: ");
                        string cedulaModificar = Console.ReadLine();
                        menu.ModificarEmpleado(cedulaModificar);
                        break;
                    case 4:
                        Console.Write("Ingresa la cédula del empleado a borrar: ");
                        string cedulaBorrar = Console.ReadLine();
                        menu.BorrarEmpleado(cedulaBorrar);
                        break;
                    case 5:
                        menu.InicializarArreglos();
                        break;
                    case 6:
                        SubmenuReportes(menu);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error.Opcion no existente, Intentelo de nuevo");
                        break;
                }
            }
        }

        
        static void SubmenuReportes(Menu menu)
        {
            while (true)
            {
                menu.MostrarSubMenuReportes();
                Console.Write("Selecciona una opción: ");
                int opcionReportes = int.Parse(Console.ReadLine());

                switch (opcionReportes)
                {
                    case 1:
                        Console.Write("Ingresa la cédula del empleado a consultar: ");
                        string cedulaConsulta = Console.ReadLine();
                        menu.ConsultarEmpleadoPorCedula(cedulaConsulta);
                        break;
                    case 2:
                        menu.ListarEmpleadosOrdenadosPorNombre();
                        break;
                    case 3:
                        menu.CalcularPromedioSalarios();
                        break;
                    case 4:
                        menu.CalcularSalariosMinMax();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Error.Opcion no existente, Intentelo de nuevo..");
                        break;
                }
            }
        }
    }

    
    }

