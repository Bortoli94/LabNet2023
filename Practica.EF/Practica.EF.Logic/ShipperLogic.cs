using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public class ShipperLogic : BaseLogic, IABMLogic<Shippers>
    {
        public void Add(Shippers regedit)
        {
            _context.Shippers.Add(regedit);
            _context.SaveChanges();
        }

        public List<Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }
    }
}
