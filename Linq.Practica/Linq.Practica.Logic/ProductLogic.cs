using Linq.Practica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Practica.Logic
{
    public class ProductLogic : BaseLogic
    {
        public List<Products> OutOfStock()
        {
            return _context.Products.Where(p => p.UnitsInStock == 0).ToList();
        }

        public List<Products> InStockWhithValueOver3()
        {
            return _context.Products.Where(p => p.UnitsInStock > 0).Where(p => p.UnitPrice > 3).ToList();  
        }

        public Products FirstElementOrNull(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == id);
        }
    }
}
