using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();
        void Add(T dto);
        void Delete(int dto);
        void Update(T id);
    }
}
