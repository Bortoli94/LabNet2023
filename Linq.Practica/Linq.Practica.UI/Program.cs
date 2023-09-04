﻿using Linq.Practica.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Practica.UI
{
    internal class Program
    {
        static void Main()
        {
            int opcion;
            Menu program = new Menu();
            do
            {
                Console.Clear();
                opcion = program.MostrarMenu();
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ejercicio 1");
                        Console.WriteLine("Query para devolver objeto customer\n");
                        CustomerLogic customer = new CustomerLogic();
                        try
                        {
                            var ej1= customer.GetCustomer();
                            Console.WriteLine($"ID= {ej1.CustomerID}"); 
                            Console.WriteLine($"COMPANY NAME= {ej1.CompanyName}");
                            Console.WriteLine($"CONTACT NAME= {ej1.ContactName}");
                            Console.WriteLine($"CONTACT TITLE= {ej1.ContactTitle}");
                            Console.WriteLine($"ADDRESS= {ej1.Address}");
                            Console.WriteLine($"CITY= {ej1.City}");
                            Console.WriteLine($"REGION= {ej1.Region}");
                            Console.WriteLine($"POSTAL CODE= {ej1.PostalCode}");
                            Console.WriteLine($"COUNTRY= {ej1.Country}");
                            Console.WriteLine($"PHONE= {ej1.Phone}");
                            Console.WriteLine($"FAX= {ej1.Fax}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        } 
                        break;
                    case 2:
                        Console.WriteLine("Ejercicio 2");
                        Console.WriteLine("Query para devolver todos los productos sin stock\n");
                        Console.WriteLine("ProductID - ProductName");
                        ProductLogic ej2 = new ProductLogic();
                        foreach (var item in ej2.OutOfStock())
                        {
                            Console.WriteLine($"{item.ProductID} - {item.ProductName}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ejercicio 3");
                        Console.WriteLine("Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad\n");
                        Console.WriteLine("ProductID - ProductName");
                        ProductLogic ej3 = new ProductLogic();
                        foreach (var item in ej3.InStockWhithValueOver3())
                        {
                            Console.WriteLine($"{item.ProductID} - {item.ProductName}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ejercicio 4");
                        Console.WriteLine("Query para devolver todos los customers de la Región WA\n");
                        Console.WriteLine("CustomerID - ContactName");
                        CustomerLogic ej4 = new CustomerLogic();
                        foreach (var item in ej4.CustomerRegionWA())
                        {
                            Console.WriteLine($"{item.CustomerID} - {item.ContactName}");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Ejercicio 5");
                        Console.WriteLine("Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789\n");
                        int id = 789;
                        ProductLogic ej5 = new ProductLogic();
                        var result = ej5.FirstElementOrNull(id);
                        if (result == null)
                        {
                            Console.WriteLine($"Devolvio null, lo cual no existe elemento con ID {id}");
                        }
                        else
                        {
                            Console.WriteLine($"ID = {result.ProductID}");
                            Console.WriteLine($"NAME = {result.ProductName}");
                        }
                        ;
                        break;
                    case 6:
                        Console.WriteLine("Ejercicio 6");
                        Console.WriteLine("Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula\n");
                        CustomerLogic ej6 = new CustomerLogic();
                        Console.WriteLine("MINUSCULAS\tMAYUSCULAS");
                        Console.WriteLine("-----------------------------");
                        foreach(var item in ej6.NameCustomerList())
                        {
                            Console.WriteLine($"{item.ToLower()}   -   {item.ToUpper()}");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Ejercicio 7");
                        Console.WriteLine("Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.");
                        CustomerLogic customerLogic = new CustomerLogic();
                        OrdersLogic ordersLogic = new OrdersLogic();
                        var listCustomer = customerLogic.GetAll();
                        var listOrders = ordersLogic.GetAll();

                        var queryEj7 = from Customer in listCustomer
                                     join Orders in listOrders on Customer.CustomerID equals Orders.CustomerID
                                     where Customer.Region == "WA" && Orders.OrderDate > new DateTime(1997, 1, 1)
                                     select new
                                     {
                                         Customer.CustomerID,
                                         Customer.ContactName,
                                         Customer.Region,
                                         Orders.OrderDate
                                     };

                        foreach (var item in queryEj7)
                        {
                            Console.WriteLine($"{item.CustomerID} - {item.ContactName} - {item.Region} - {item.OrderDate}"); 
                        }
                        break;
                    case 8:
                        Console.WriteLine("Ejercicio 8");
                        break;
                    case 9:
                        Console.WriteLine("Ejercicio 9");
                        break;
                    case 10:
                        Console.WriteLine("Ejercicio 10");
                        break;
                    case 11:
                        Console.WriteLine("Ejercicio 11");
                        break;
                    case 12:
                        Console.WriteLine("Ejercicio 12");
                        break;
                    case 13:
                        Console.WriteLine("Ejercicio 13");
                        break;
                    case 14:
                        Console.WriteLine("El programa ha finalizado");
                        break;
                    default:
                        Console.WriteLine("Opción Incorrecta!");
                        break;
                }
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 14);
        }
    }
}
