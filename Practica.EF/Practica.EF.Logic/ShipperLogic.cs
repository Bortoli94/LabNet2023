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
            try
            {
                _context.Shippers.Add(regedit);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Parametros Invalidos");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Shippers.Remove(_context.Shippers.First(x => x.ShipperID == id));
                _context.SaveChanges();
            }
            catch 
            {
                throw new Exception("Transportista no Encontrado");
            }
        }

        public List<Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }
        
        public void Update(Shippers regedit)
        {
            throw new NotImplementedException();
        }
    }
}
