using Linq.Practica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Practica.Logic
{
    public class OrdersLogic : BaseLogic
    {
        public List<Orders> GetAll()
        {
            return _context.Orders.ToList();
        }
    }
}
