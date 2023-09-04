using Linq.Practica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Practica.Logic
{
    public class CategoryLogic : BaseLogic
    {
        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
