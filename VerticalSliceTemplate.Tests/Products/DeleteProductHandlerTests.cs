using Microsoft.EntityFrameworkCore;
using VerticalSliceTemplate.Data;
using VerticalSliceTemplate.Models;
using VerticalSliceTemplate.Pages.Products;

namespace VerticalSliceTemplate.Tests.Products
{
    public class DeleteProductHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_DeletesProduct()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options; // Unique database name for each test

            using var db = new ApplicationDbContext(options);

            var product = new Product { Id = 1, Name = "Widget 1", Price = 10 };

            db.Products.Add(product);
            await db.SaveChangesAsync();

            var handler = new DeleteProductHandler(db);
            var command = new DeleteProduct { Id = 1 };

            // Act
            await handler.Handle(command, default);

            // Assert
            var deletedProduct = await db.Products.FindAsync(1);
            Assert.Null(deletedProduct);
        }
    }
}
