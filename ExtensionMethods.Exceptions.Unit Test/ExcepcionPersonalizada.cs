using System;

namespace ExtensionMethods.Exceptions.Unit_Test
{
    public class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada(string message) : base("Esto es una Excepcion Personalizada de " + message)
        {

        }
    }
}
