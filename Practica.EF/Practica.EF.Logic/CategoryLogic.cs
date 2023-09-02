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
            try
            {
                _context.Categories.Add(regedit);
                _context.SaveChanges();
            }
            catch 
            {
                throw new Exception("Parámetros Inválidos");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Categories.Remove(_context.Categories.First(x => x.CategoryID == id));
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("No existe Categoría con ese ID");
            }
        }

        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Categories regedit)
        {
            try
            {
                var categoryUpdate = _context.Categories.Find(regedit.CategoryID);
                categoryUpdate.CategoryName = regedit.CategoryName;
                categoryUpdate.Description = regedit.Description;
                _context.SaveChanges();
            }
            catch 
            {
                throw new Exception("Parámetros Inválidos");
            }
        }

        public Categories Search(int id)
        {
            var result =  _context.Categories.Find(id);
            
            return result;
        }
    }
}
