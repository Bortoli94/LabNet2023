using Practica.EF.Entities.DTO;
using Practica.EF.Logic.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Practica.EF.API.Controllers
{
    public class CategoriesController : ApiController
    {

        CategoryLogic logic = new CategoryLogic();
        
        public IHttpActionResult Get()
        {
            try
            {
                List<CategoryDto> result = logic.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(logic.Search(id));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public IHttpActionResult Post([FromBody] CategoryDto dto)
        {
            try
            {
                logic.Add(dto);
                return Content(HttpStatusCode.Created, dto);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] CategoryDto dto)
        {
            try
            {
                logic.Update(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return Ok($"Se elimino correctamente el registro con id {id}");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
