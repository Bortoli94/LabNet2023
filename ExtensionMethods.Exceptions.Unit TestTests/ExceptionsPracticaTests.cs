using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionMethods.Exceptions.Unit_Test;
using System;


namespace ExtensionMethods.Exceptions.Unit_Test.Tests
{
    [TestClass()]
    public class ExceptionsPracticaTests
    {
        [TestMethod()]
        public void DividirTest()
        {
            //arrange
            int num1 = 15;
            int num2 = 3;
            float resultadoEsperado = 5;
            //act
            float resultado = ExceptionsPractica.Dividir(num1, num2);
            //assert
            Assert.AreEqual(resultadoEsperado,resultado);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirTest2()
        {
            //arrange
            int num1 = 5;
            int num2 = 0;
            //act
            ExceptionsPractica.Dividir(num1, num2);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirPorCeroTest()
        {
            //arrange
            int num1 = 5;
            //act
            ExceptionsPractica.DividirPorCero(num1);
        }
    }
}