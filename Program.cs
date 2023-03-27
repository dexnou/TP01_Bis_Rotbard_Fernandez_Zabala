using System;
using System.Collections.Generic;
namespace TP_1_BIS_programacion_4to_año
{
    internal class Program
    {
        private static void Main(string[] args) //NUNCA TERMINA EL INGRESO DE DATOS. SI TERMINAS DE INGRESAR DATOS SI O SI TE TIENE QUE DIRIGIR A ESTADISTICAS. cuando termina de ingresar numeros de alumnos y curso se tiene que volver al menu. 
        {
            int numMenu = 0;
            SortedDictionary<string, double> dicAlumnos = new SortedDictionary<string, double>();
            do
            {
                numMenu = IngresarEntero("Ingrese 1 para comenzar con el ingreso de importes del curso. 2 para conocer las estadísticas. 3 para salir");
                ComprobarNum(numMenu);
                switch (numMenu)
                {
                    case 1:
                        Console.WriteLine("INGRESO DE DATOS: ");
                        int numEstudiantes = 0;
                        string curso = "";
                        double dineroRecaudado;
                        IngresarCursoYEstudiantes(ref numEstudiantes, ref curso);
                        dineroRecaudado = PagoEstudiantes(numEstudiantes);
                        dicAlumnos.Add(curso, dineroRecaudado); 
                        break;

                    case 2:
                        Console.WriteLine("ESTADÍSTICAS: ");
                        CalcularMayorPago(dicAlumnos);
                        break;

                    case 3:
                        break;
                }
            } while (numMenu != 3);
        }

        static double PagoEstudiantes(int numEstudiantes)
        {
            double[] pagos = new double[numEstudiantes];
            double importe = 0;
            for (int i = 0; i < numEstudiantes; i++)
            {
                pagos[i] = IngresarDouble("Ingrese el pago del estudiante " + (i + 1));
                importe += pagos[i];
            }
            return importe;
        }
        static int IngresarEntero(string mensaje)
        {
            int num = 0;
            Console.WriteLine(mensaje);
            num = int.Parse(Console.ReadLine());
            return num;
        }

        static void ComprobarNum(int numMenu)
        {
            while (numMenu < 1 || numMenu > 3)
            {
                numMenu = IngresarEntero("Error. Los únicos números válidos son 1, 2 o 3.");
            }
        }

        static string IngresarString(string mensaje)
        {
            string palabra;
            Console.WriteLine(mensaje);
            palabra = Console.ReadLine();
            return palabra;
        }

        static double IngresarDouble(string mensaje)
        {
            double num = 0;
            Console.WriteLine(mensaje);
            num = double.Parse(Console.ReadLine());
            return num;
        }
        static void IngresarCursoYEstudiantes(ref int numEstudiantes, ref string curso)
        {
            curso = IngresarString("Ingrese el curso: ");
            numEstudiantes = IngresarEntero("Ingrese el numero de estudiantes: ");
            while (numEstudiantes <= 0)
            {
                numEstudiantes = IngresarEntero("Error. Ingrese el numero de estudiantes: ");
            }
        }
        static void CalcularMayorPago(SortedDictionary<string, double> dicAlumnos)
        {
            double numMayor = 0;
            string cursoMayor = "";
            double recaudacion = 0;
            int cantidadCursos = 0;
            foreach (string palabra in dicAlumnos.Keys)
            {
                if (numMayor < dicAlumnos[palabra])
                {
                    numMayor = dicAlumnos[palabra];
                    recaudacion += numMayor;
                    cursoMayor = palabra;
                }
                else
                {
                    recaudacion = recaudacion + dicAlumnos[palabra];
                }
                cantidadCursos++;
            }
            Console.WriteLine("CURSO QUE MÁS PAGÓ: " + cursoMayor + ", PAGANDO " + numMayor);
            Console.WriteLine($"PROMEDIO DE PLATA POR CADA CURSO: {recaudacion / cantidadCursos}");
            Console.WriteLine("TOTAL RECAUDADO ENTRE TODOS LOS CURSOS: " + recaudacion);
            Console.WriteLine($"CANTIDAD DE CURSOS QUE PARTICIPAN EN EL REGALO: {cantidadCursos}");
        }
    }
}