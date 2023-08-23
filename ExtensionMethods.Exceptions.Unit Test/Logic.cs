using System;

namespace ExtensionMethods.Exceptions.Unit_Test
{
    public class Logic
    {
        public static void TirarExcepcion()
        {
            throw new Exception();
        }

        public static void TirarExcepcionPersonalizada()
        {
            throw new ExcepcionPersonalizada("Gaston Bortoli");
        }
    }
}
