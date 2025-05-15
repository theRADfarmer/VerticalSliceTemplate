using Microsoft.EntityFrameworkCore;
using VerticalSliceTemplate.Data;
using VerticalSliceTemplate.Models;
using VerticalSliceTemplate.Pages.Products;

namespace VerticalSliceTemplate.Tests.Products
{
    public class GetProductByIdHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsProduct()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options; // Unique database name for each test

            using var db = new ApplicationDbContext(options);

            var product = new Product { Id = 1, Name = "Widget 1", Price = 10 };

            db.Products.Add(product);
            await db.SaveChangesAsync();

            var handler = new GetProductByIdHandler(db);
            var query = new GetProductById { Id = 1 };

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Widget 1", result.Name);
            Assert.Equal(10, result.Price);
        }
    }
}
