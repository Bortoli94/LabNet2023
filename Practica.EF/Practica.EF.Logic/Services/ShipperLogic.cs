using Practica.EF.Entities;
using Practica.EF.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Practica.EF.Logic.Services
{
    public class ShipperLogic : BaseLogic<ShipperDto>, IABMLogic<ShipperDto>
    {
        public override void Add(ShipperDto dto)
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

        public override void Delete(int id)
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

        public override List<ShipperDto> GetAll()
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
        
        public override void Update(ShipperDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
