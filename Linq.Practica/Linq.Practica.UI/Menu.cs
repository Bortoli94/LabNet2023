using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Practica.UI
{
    public class Menu
    {
        public int MostrarMenu()
        {
            Console.WriteLine("PRACTICA LINQ\n");
            Console.WriteLine("\t1 - Ejercicio 1");
            Console.WriteLine("\t2 - Ejercicio 2");
            Console.WriteLine("\t3 - Ejercicio 3");
            Console.WriteLine("\t4 - Ejercicio 4");
            Console.WriteLine("\t5 - Ejercicio 5");
            Console.WriteLine("\t6 - Ejercicio 6");
            Console.WriteLine("\t7 - Ejercicio 7");
            Console.WriteLine("\t8 - Ejercicio 8");
            Console.WriteLine("\t9 - Ejercicio 9");
            Console.WriteLine("\t10 - Ejercicio 10");
            Console.WriteLine("\t11 - Ejercicio 11");
            Console.WriteLine("\t12 - Ejercicio 12");
            Console.WriteLine("\t13 - Ejercicio 13");
            Console.WriteLine("\t14- SALIR");
            Console.Write("SELECCIONE UNA OPCION: ");
            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                if (opcion < 1 || opcion > 14)
                {
                    return 0;
                }
                else
                {
                    return opcion;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
