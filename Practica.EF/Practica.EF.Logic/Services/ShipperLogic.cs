using Practica.EF.Entities;
using Practica.EF.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic.Services
{
    public class ShipperLogic : BaseLogic, IABMLogic<ShipperDto>
    {
        public void Add(ShipperDto dto)
        {
            try
            {
                var newShipper = new Shippers()
                {
                    CompanyName = dto.CompanyName,
                    Phone = dto.Phone,
                };
                _context.Shippers.Add(newShipper);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Parametros Invalidos");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Shippers.Remove(_context.Shippers.First(x => x.ShipperID == id));
                _context.SaveChanges();
            }
            catch 
            {
                throw new Exception("Transportista no Encontrado");
            }
        }

        public List<ShipperDto> GetAll()
        {
            IEnumerable<Shippers> shipper = _context.Shippers.AsEnumerable();
            List<ShipperDto> list = shipper.Select(s => new ShipperDto
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone,
            }).ToList();
            
            return list;
        }
        
        public void Update(ShipperDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
