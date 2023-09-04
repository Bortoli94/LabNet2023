using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Practica.Entities;
using System.Text;
using System.Threading.Tasks;


namespace Linq.Practica.Logic
{
    public class CustomerLogic : BaseLogic
    {
        public Customers GetCustomer()
        {
            return _context.Customers.First();
        }

        public List<string> NameCustomerList()
        {
            return _context.Customers.Select(c => c.ContactName).ToList();
        }

        public List<Customers> CustomerRegionWA()
        {
            return _context.Customers.Where(c => c.Region == "WA").ToList();
        }

        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public List<Customers> First3RegionWA()
        {
            return _context.Customers.Where(c => c.Region == "WA").Take(3).ToList();
        }

    }
}
