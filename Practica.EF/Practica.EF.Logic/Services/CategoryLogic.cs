using Practica.EF.Data;
using Practica.EF.Entities;
using Practica.EF.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Practica.EF.Logic.Services
{
    public class CategoryLogic : BaseLogic<CategoryDto>, IABMLogic<CategoryDto>
    {
        public CategoryLogic()
        {
        }

        public CategoryLogic(NorthwindContext context)
        {
            _context = context;
        }

        public override void Add(CategoryDto dto)
        {
            try
            {
                var newCategory = new Categories()
                {
                    CategoryName = dto.CategoryName,
                    Description = dto.Description,
                };
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }
            catch 
            {
                throw new Exception("Parámetros Inválidos");
            }
        }

        public override void Delete(int id)
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

        public override List<CategoryDto> GetAll()
        {
            IEnumerable<Categories> categories = _context.Categories.AsEnumerable();
            List<CategoryDto> list = categories.Select(c => new CategoryDto
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description,
            }).ToList();
            
            return list;
        }

        public override void Update(CategoryDto dto)
        {
            try
            {
                Categories categoryUpdate = _context.Categories.Find(dto.CategoryID);
                
                categoryUpdate.CategoryName = dto.CategoryName;
                categoryUpdate.Description = dto.Description;
                _context.SaveChanges();
            }
            catch 
            {
                throw new Exception("Parámetros Inválidos");
            }
        }

        public override CategoryDto Search(int id)
        {
            try
            {
                var result = _context.Categories.First( c => c.CategoryID == id);

                var categoriesDto = new CategoryDto()
                {
                    CategoryID = result.CategoryID,
                    CategoryName = result.CategoryName,
                    Description = result.Description,
                };
                
                return categoriesDto;
            }
            catch
            {
                throw new Exception("Categoria no encontrada");
            }
        }
        
    }
}
