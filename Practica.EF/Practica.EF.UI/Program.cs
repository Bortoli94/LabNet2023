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

            foreach (var shipper in shipperLogic.GetAll())
            {
                Console.WriteLine($"{shipper.ShipperID} - {shipper.CompanyName} - {shipper.Phone}");
            }
                Console.ReadKey();

        }
    }
}
