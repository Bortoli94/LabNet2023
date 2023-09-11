using System.Collections.Generic;

namespace Practica.EF.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();
        void Add(T dto);
        void Delete(int dto);
        void Update(T id);
        T Search (int id);
    }
}
