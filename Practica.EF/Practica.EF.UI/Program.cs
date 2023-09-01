using Practica.EF.Entities;
using Practica.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShipperLogic shipperLogic = new ShipperLogic();
            Console.WriteLine("Shipper");
            foreach (var shipper in shipperLogic.GetAll())
            {
                Console.WriteLine($"{shipper.ShipperID} - {shipper.CompanyName} - {shipper.Phone}");
            }
            
            CategoryLogic categoryLogic = new CategoryLogic();
            Console.WriteLine("\n\nCategories");
            foreach (var category in categoryLogic.GetAll())
            {
                Console.WriteLine($"{category.CategoryID} - {category.CategoryName} - {category.Description}");
            }

            categoryLogic.Add(new Categories
            {
                CategoryName = "Verduleria",
                Description = "Papa, Manzana, Pimiento"
            });

            Console.WriteLine("\n\nCategories");
            foreach (var category in categoryLogic.GetAll())
            {
                Console.WriteLine($"{category.CategoryID} - {category.CategoryName} - {category.Description}");
            }



            Console.ReadKey();



        }
    }
}
