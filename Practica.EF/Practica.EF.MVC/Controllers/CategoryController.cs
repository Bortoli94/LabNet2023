using Practica.EF.Entities.DTO;
using Practica.EF.Logic.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Practica.EF.MVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryLogic logic = new CategoryLogic();

        public ActionResult List()
        {
            List<CategoryDto> categories = logic.GetAll();
            return View(categories);
        }

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(CategoryDto dto)
        {
            try
            {
                logic.Add(dto);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ViewError", "Error", new { ex.Message });
            }
        }

        public ActionResult Delete(int id)
        {
            logic.Delete(id);
            return RedirectToAction("List");
        }

        public ActionResult Update(int id)
        {
            return View(logic.Search(id));
        }
        [HttpPost]
        public ActionResult Update(CategoryDto dto)
        {
            try
            {
                logic.Update(dto);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ViewError", "Error", new { ex.Message });
            }
        }


    }
}