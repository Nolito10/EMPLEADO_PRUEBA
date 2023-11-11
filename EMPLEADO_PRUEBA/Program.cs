using System;
using System.Collections.Generic;

namespace EMPLEADO_PRUEBA
{
    internal class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Calcular salario");
                Console.WriteLine("3. Mostrar información");
                Console.WriteLine("4. Mostrar todos los empleados");
                Console.WriteLine("5. Salir");

                Console.Write("Ingrese una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
                    Console.ReadLine(); // Esperar a que el usuario presione Enter
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        CalcularSalario();
                        break;
                    case 3:
                        MostrarInformacion();
                        break;
                    case 4:
                        MostrarTodos();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine(); // Esperar a que el usuario presione Enter

            } while (opcion != 5);
        }

        static void AgregarEmpleado()
        {
            Console.WriteLine("Tipo de empleado:");
            Console.WriteLine("1. Asalariado");
            Console.WriteLine("2. Por hora");
            Console.WriteLine("3. Por comisión");

            int tipo;
            if (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 3)
            {
                Console.WriteLine("Tipo de empleado inválido");
                return;
            }

            Console.Write("Cédula: ");
            string cedula = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Activo (true/false): ");
            if (!bool.TryParse(Console.ReadLine(), out bool activo))
            {
                Console.WriteLine("Entrada no válida. Se establecerá como inactivo.");
                activo = false;
            }

            Empleado empleado;

            switch (tipo)
            {
                case 1:
                    Console.Write("Salario: ");
                    if (!double.TryParse(Console.ReadLine(), out double salario))
                    {
                        Console.WriteLine("Entrada no válida. Se establecerá como salario cero.");
                        salario = 0.0;
                    }
                    empleado = new Asalariado(cedula, nombre, activo, salario);
                    break;

                case 2:
                    Console.Write("Precio por hora: ");
                    if (!double.TryParse(Console.ReadLine(), out double precioHora))
                    {
                        Console.WriteLine("Entrada no válida. Se establecerá como precio por hora cero.");
                        precioHora = 0.0;
                    }
                    Console.Write("Horas trabajadas: ");
                    if (!int.TryParse(Console.ReadLine(), out int horas))
                    {
                        Console.WriteLine("Entrada no válida. Se establecerá como horas trabajadas cero.");
                        horas = 0;
                    }
                    empleado = new PorHora(cedula, nombre, activo, precioHora, horas);
                    break;

                case 3:
                    Console.Write("Ventas del mes: ");
                    if (!double.TryParse(Console.ReadLine(), out double ventas))
                    {
                        Console.WriteLine("Entrada no válida. Se establecerá como ventas cero.");
                        ventas = 0.0;
                    }
                    Console.Write("Porcentaje de comisión: ");
                    if (!double.TryParse(Console.ReadLine(), out double porcentaje))
                    {
                        Console.WriteLine("Entrada no válida. Se establecerá como porcentaje cero.");
                        porcentaje = 0.0;
                    }
                    empleado = new Comision(cedula, nombre, activo, ventas, porcentaje);
                    break;

                default:
                    Console.WriteLine("Tipo de empleado inválido");
                    return;
            }

            empleados.Add(empleado);
            Console.WriteLine("Empleado agregado exitosamente");
        }

        static void CalcularSalario()
        {
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();

            Empleado empleado = ObtenerEmpleado(cedula);

            if (empleado == null)
            {
                Console.WriteLine("No se encontró empleado con esa cédula");
                return;
            }

            Console.WriteLine("El salario es: " + empleado.CalcularSalario());
        }

        static void MostrarInformacion()
        {
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();

            Empleado empleado = ObtenerEmpleado(cedula);

            if (empleado == null)
            {
                Console.WriteLine("No se encontró empleado con esa cédula");
                return;
            }

            Console.WriteLine(empleado.ToString());
        }

        static void MostrarTodos()
        {
            Console.WriteLine("Empleados:");

            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine(empleado.ToString());
                Console.WriteLine();
            }
        }

        static Empleado ObtenerEmpleado(string cedula)
        {
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Cedula == cedula)
                {
                    return empleado;
                }
            }

            return null;
        }
    }
}
