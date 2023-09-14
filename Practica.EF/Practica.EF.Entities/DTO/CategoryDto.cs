using System.ComponentModel.DataAnnotations;

namespace Practica.EF.Entities.DTO
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
