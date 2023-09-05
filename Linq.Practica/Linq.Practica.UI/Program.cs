using Linq.Practica.Entities;
using Linq.Practica.Logic;
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
                        CustomerLogic customerEj1 = new CustomerLogic();
                        try
                        {
                            var ej1= customerEj1.GetCustomer();
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
                        Console.WriteLine("ID\tProductName");
                        ProductLogic productEj2 = new ProductLogic();
                        foreach (var item in productEj2.OutOfStock())
                        {
                            Console.WriteLine($"{item.ProductID}\t{item.ProductName}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ejercicio 3");
                        Console.WriteLine("Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad\n");
                        Console.WriteLine("ID\tProductName");
                        ProductLogic productEj3 = new ProductLogic();
                        foreach (var item in productEj3.InStockWhithValueOver3())
                        {
                            Console.WriteLine($"{item.ProductID}\t{item.ProductName}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ejercicio 4");
                        Console.WriteLine("Query para devolver todos los customers de la Región WA\n");
                        Console.WriteLine("CustomerID - ContactName");
                        CustomerLogic CustomerEj4 = new CustomerLogic();
                        foreach (var item in CustomerEj4.CustomerRegionWA())
                        {
                            Console.WriteLine($"{item.CustomerID} - {item.ContactName}");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Ejercicio 5");
                        Console.WriteLine("Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789\n");
                        int id = 789;
                        ProductLogic ProductEj5 = new ProductLogic();
                        var result = ProductEj5.FirstElementOrNull(id);
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
                        CustomerLogic CustomerEj6 = new CustomerLogic();
                        Console.WriteLine("MINUSCULAS\tMAYUSCULAS");
                        Console.WriteLine("-----------------------------");
                        foreach(var item in CustomerEj6.NameCustomerList())
                        {
                            Console.WriteLine($"{item.ToLower()}   -   {item.ToUpper()}");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Ejercicio 7");
                        Console.WriteLine("Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.\n");
                        CustomerLogic customerEj7 = new CustomerLogic();
                        OrdersLogic ordersEj7 = new OrdersLogic();
                        var listCustomerEj7 = customerEj7.GetAll();
                        var listOrdersEj7 = ordersEj7.GetAll();

                        var queryEj7 = from Customer in listCustomerEj7
                                     join Orders in listOrdersEj7 on Customer.CustomerID equals Orders.CustomerID
                                     where Customer.Region == "WA" && Orders.OrderDate > new DateTime(1997, 1, 1)
                                     select new
                                     {
                                         Customer.CustomerID,
                                         Customer.ContactName,
                                         Customer.Region,
                                         Orders.OrderDate
                                     };
                        Console.WriteLine("ID - CONTACT NAME - REGION - ORDERDATE");
                        Console.WriteLine("------------------------------------------");
                        foreach (var item in queryEj7)
                        {
                            Console.WriteLine($"{item.CustomerID} - {item.ContactName} - {item.Region} - {item.OrderDate}"); 
                        }
                        break;
                    case 8:
                        Console.WriteLine("Ejercicio 8");
                        Console.WriteLine("Query para devolver los primeros 3 Customers de la  Región WA\n");
                        CustomerLogic customerEj8 = new CustomerLogic();
                        Console.WriteLine("ID - CONTACT NAME - REGION");
                        Console.WriteLine("-----------------------------");
                        foreach (var item in customerEj8.First3RegionWA())
                        {
                            Console.WriteLine($"{item.CustomerID} - {item.ContactName} - {item.Region}");
                        }
                                       
                        break;
                    case 9:
                        Console.WriteLine("Ejercicio 9");
                        Console.WriteLine("Query para devolver lista de productos ordenados por nombre\n");
                        ProductLogic productEj9 = new ProductLogic();
                        Console.WriteLine("ID\tPRODUCT NAME");
                        Console.WriteLine("--------------------");
                        foreach (var item in productEj9.OrderByName())
                        {
                            Console.WriteLine($"{item.ProductID}\t{item.ProductName}");
                        }
                        break;
                    case 10:
                        Console.WriteLine("Ejercicio 10");
                        Console.WriteLine("Query para devolver lista de productos ordenados por unit in stock de mayor a menor.\n");
                        ProductLogic productEj10 = new ProductLogic();
                        Console.WriteLine("STOCK\tPRODUCT NAME");
                        Console.WriteLine("--------------------");
                        foreach (var item in productEj10.OrderByUnitInStock())
                        {
                            Console.WriteLine($"{item.UnitsInStock}\t{item.ProductName}");
                        }
                        break;
                    case 11:
                        Console.WriteLine("Ejercicio 11");
                        Console.WriteLine("Query para devolver las distintas categorías asociadas a los productos\n");
                        ProductLogic productEj11 = new ProductLogic();
                        CategoryLogic categoryEj11 = new CategoryLogic();
                        var listProductEj11 = productEj11.GetAll();
                        var listCategoryEj11 = categoryEj11.GetAll();

                        var queryEj11 = from Products in listProductEj11
                                        join Categories in listCategoryEj11 on Products.CategoryID equals Categories.CategoryID
                                        select new
                                        {
                                            Products.ProductName,
                                            Categories.CategoryName
                                        };
                        Console.WriteLine("PRODUCT NAME   -   CATEGORY NAME");
                        Console.WriteLine("---------------------------------");
                        foreach (var item in queryEj11)
                        {
                            Console.WriteLine($"{item.ProductName}  -  {item.CategoryName}");
                        }

                        break;
                    case 12:
                        Console.WriteLine("Ejercicio 12");
                        Console.WriteLine("Query para devolver el primer elemento de una lista de productos\n");
                        ProductLogic ProductEj12 = new ProductLogic();
                        var listProductEj12 = ProductEj12.GetAll();

                        var queryEj12 = listProductEj12.First();
                        Console.WriteLine("ID - PRODUCT NAME");
                        Console.WriteLine("--------------------");
                        Console.WriteLine($"{queryEj12.ProductID} - {queryEj12.ProductName}");

                        break;
                    case 13:
                        Console.WriteLine("Ejercicio 13");
                        Console.WriteLine("Query para devolver los customer con la cantidad de ordenes asociadas\n");
                        
                        CustomerLogic customerEj13 = new CustomerLogic();
                        var listCustomerEj13 = customerEj13.GetAll();
                        Console.WriteLine("CONTACT NAME - COUNT ORDERS");
                        Console.WriteLine("----------------------------");
                        foreach (Customers item in listCustomerEj13)
                        {
                            Console.WriteLine($"{item.ContactName} - {item.Orders.Count()}");
                        }

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
