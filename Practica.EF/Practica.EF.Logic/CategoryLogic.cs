using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public class CategoryLogic : BaseLogic, IABMLogic<Categories>
    {
        public void Add(Categories regedit)
        {
            _context.Categories.Add(regedit);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Categories regedit)
        {
            throw new NotImplementedException();
        }
    }
}
