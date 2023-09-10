using Practica.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public abstract class BaseLogic<T> : IABMLogic<T>
    {
        protected NorthwindContext _context;

        public BaseLogic()
        {
            _context = new NorthwindContext();
        }
        public abstract List<T> GetAll();
        public abstract void Add(T dto);
        public abstract void Delete(int id);
        public abstract void Update(T dto);
    }
}
