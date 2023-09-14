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
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw new Exception("Parametros Inválidos");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void Delete(int id)
        {
            try
            {
                _context.Shippers.Remove(_context.Shippers.First(x => x.ShipperID == id));
                _context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new Exception("No existe registro con ese ID");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
            try
            {
                Shippers shippersUpdate = _context.Shippers.First(s => s.ShipperID == dto.ShipperID);

                shippersUpdate.CompanyName = dto.CompanyName;
                shippersUpdate.Phone = dto.Phone;
                _context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new Exception("No existe registro con ese ID");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw new Exception("Parametros Inválidos");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override ShipperDto Search(int id)
        {
            try
            {
                var result = _context.Shippers.First(s => s.ShipperID == id);

                var shipperDto = new ShipperDto()
                {
                    ShipperID = result.ShipperID,
                    CompanyName = result.CompanyName,
                    Phone = result.Phone,
                };

                return shipperDto;
            }
            catch (InvalidOperationException)
            {
                throw new Exception("No existe registro con ese ID");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
