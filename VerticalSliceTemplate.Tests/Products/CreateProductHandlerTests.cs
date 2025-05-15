using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VerticalSliceTemplate.Data;
using VerticalSliceTemplate.Pages.Products;

namespace VerticalSliceTemplate.Tests.Products
{
    public class CreateProductHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_CreatesProduct()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options; // Unique database name for each test

            using var db = new ApplicationDbContext(options);

            var handler = new CreateProductHandler(db);
            var command = new CreateProduct { Name = "Widget 1", Price = 10 };

            // Act
            await handler.Handle(command, default);

            // Assert
            var product = await db.Products.FirstOrDefaultAsync(p => p.Name == "Widget 1");
            Assert.NotNull(product);
            Assert.Equal("Widget 1", product.Name);
            Assert.Equal(10, product.Price);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options; // Unique database name for each test
            using var db = new ApplicationDbContext(options);
            var handler = new CreateProductHandler(db);
            var command = new CreateProduct { Name = new string('A', 31), Price = -1 }; // Invalid data
            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(command, default));
        }
    }
}
