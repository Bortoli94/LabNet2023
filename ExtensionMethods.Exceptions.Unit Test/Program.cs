using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods.Exceptions.Unit_Test
{
    internal class Program
    {
        static void Main()
        {
            int numConvertido;
            string numIngresado;

            Console.WriteLine("Ejercicio 1");
            Console.Write("Ingrese un numero: ");
            numIngresado = Console.ReadLine();
            while (!int.TryParse(numIngresado, out numConvertido))
            {
                Console.Write("Ingrese un numero valido: ");
                numIngresado = Console.ReadLine();
            }
            ExceptionsPractica.DividirPorCero(numConvertido);


            Console.WriteLine("\nEjercicio 2");
            try
            {
                Console.Write("Ingrese numero dividendo: ");
                numIngresado = Console.ReadLine();
                numConvertido = Convert.ToInt32(numIngresado);
                
                Console.Write("Ingrese numero divisor: ");
                string numIngresado2 = Console.ReadLine();
                int numConvertido2 = Convert.ToInt32(numIngresado2);
                
                ExceptionsPractica.Dividir(numConvertido, numConvertido2);
            }
            catch (FormatException)
            {
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
            }
            finally
            {
                Console.WriteLine("Ha finalizado el segundo ejercicio");
            }


            Console.ReadKey();
        }
    }
}
