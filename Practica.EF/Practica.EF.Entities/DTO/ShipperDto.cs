using System.ComponentModel.DataAnnotations;

namespace Practica.EF.Entities.DTO
{
    public class ShipperDto
    {
        public int ShipperID { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
