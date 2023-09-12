using Practica.EF.Entities.DTO;
using Practica.EF.Logic.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Practica.EF.MVC.Controllers
{
    public class ShipperController : Controller
    {
        ShipperLogic logic = new ShipperLogic();

        public ActionResult List()
        {
            List<ShipperDto> shippers = logic.GetAll();
            return View(shippers);
        }

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(ShipperDto dto)
        {
            try
            {
                logic.Add(dto);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ViewError", "Error", new { ex.Message, value = "Shipper" });
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
        public ActionResult Update(ShipperDto dto)
        {
            try
            {
                logic.Update(dto);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ViewError", "Error", new { ex.Message , value = "Shipper"});
            }
        }
    }
}