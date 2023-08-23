using System;

namespace ExtensionMethods.Exceptions.Unit_Test
{
    public class ExceptionsPractica
    {
        public static void DividirPorCero(int i)
        {
            try
            {
                Console.WriteLine($"{i} / 0 = ");
                int dividir = i / 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Ha finalizado el primer ejercicio");
            }
        }

        public static void Dividir(int dividendo, int divisor)
        {
            try
            {
                float resultado = dividendo / divisor;
                Console.WriteLine($"{dividendo} / {divisor} = {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("¡Solo Chuck Norris divide por cero!");
            }
        }
    }
}
