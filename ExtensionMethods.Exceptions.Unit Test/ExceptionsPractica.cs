using System;

namespace ExtensionMethods.Exceptions.Unit_Test
{
    public class ExceptionsPractica
    {
        public static int DividirPorCero(int i)
        {
            Console.WriteLine($"{i} / 0 = ");
            return  i / 0;
        }

        public static float Dividir(int dividendo, int divisor)
        {
            float resultado = dividendo / divisor;
            Console.WriteLine($"{dividendo} / {divisor} = {resultado}");
            return resultado;
        }
    }
}
