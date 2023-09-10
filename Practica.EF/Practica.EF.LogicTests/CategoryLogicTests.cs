using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica.EF.Data;
using Practica.EF.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Practica.EF.Logic.Services;
using Practica.EF.Entities.DTO;

namespace Practica.EF.Logic.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
            //ARRANGE
            var mockSet = new Mock<DbSet<Categories>>();
            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            CategoryLogic categoryLogic = new CategoryLogic(mockContext.Object);

            //ACT
            categoryLogic.Add(new CategoryDto
            {
                CategoryID = 1,
                CategoryName = "name",
                Description = "description"
            });

            //ASSERT
            mockSet.Verify(m => m.Add(It.IsAny<Categories>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


        [TestMethod]
        public void GetAllTest()
        {
            var data = new List<Categories>
            {
            new Categories { CategoryName = "Perfumeria" },
            new Categories { CategoryName = "Indumentaria" },
            new Categories { CategoryName = "Limpieza" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Categories>>();
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var service = new CategoryLogic(mockContext.Object);
            var blogs = service.GetAll();

            Assert.AreEqual(3, blogs.Count);
            Assert.AreEqual("Perfumeria", blogs[0].CategoryName);
            Assert.AreEqual("Indumentaria", blogs[1].CategoryName);
            Assert.AreEqual("Limpieza", blogs[2].CategoryName);
        }
    }
}


