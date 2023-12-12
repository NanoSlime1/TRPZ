using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DAL.Test
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputIngredientInstance_CallsAddMethodOfDbSetWithStreetInstance()
        {
        //Arrange
            DbContextOptions<CanteenContent> options = new DbContextOptionsBuilder<CanteenContent>().Options;
            var mockContext = new Mock<CanteenContent>(options);
            var mockDbSet = new Mock<DbSet<Ingredient>>();
            mockContext.Setup(
                    context => 
                        context.Set<Ingredient>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestIngredientRepository(mockContext.Object);
            Ingredient expected = new Mock<Ingredient>().Object;
            
        //Act
        repository.Create(expected);
        
        //Assert
        mockDbSet.Verify(dbSet => dbSet.Add(expected), Times.Once);
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            //Arrange
            DbContextOptions<CanteenContent> options = new DbContextOptionsBuilder<CanteenContent>().Options;
            var mockContext = new Mock<CanteenContent>(options);
            var mockDbSet = new Mock<DbSet<Ingredient>>();
            mockContext.Setup(
                context => 
                    context.Set<Ingredient>(
                        ))
                .Returns(mockDbSet.Object);
            Ingredient expected = new Ingredient() { IngredientId = 1};
            mockDbSet.Setup(mock => mock.Find(expected.IngredientId))
                .Returns(expected);
            var repository = new TestIngredientRepository(mockContext.Object);
            
            //Act
            var current = repository.Get(expected.IngredientId);
            
            //Assert
            mockDbSet.Verify(DbSet => DbSet.Find(expected.IngredientId),Times.Once);
            Assert.Equal(expected,current);
        }

        [Fact]
        public void  Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            //Arrange
            DbContextOptions<CanteenContent> options = new DbContextOptionsBuilder<CanteenContent>().Options;
            var mockContext = new Mock<CanteenContent>(options);
            var mockDbSet = new Mock<DbSet<Ingredient>>();
            mockContext.Setup(
                    context => 
                        context.Set<Ingredient>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestIngredientRepository(mockContext.Object);
            Ingredient expected = new Ingredient() { IngredientId = 1 };
            mockDbSet.Setup(mock => mock.Find(expected.IngredientId))
                .Returns(expected);

            //Act
            repository.Delete(expected.IngredientId);
            
            //Assert
            mockDbSet.Verify(DbSet => DbSet.Find(expected.IngredientId),Times.Once);
            mockDbSet.Verify(DbSet => DbSet.Remove(expected),Times.Once);
        }
    }
}