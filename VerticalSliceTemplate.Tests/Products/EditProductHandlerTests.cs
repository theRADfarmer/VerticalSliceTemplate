using Microsoft.EntityFrameworkCore;
using VerticalSliceTemplate.Data;
using VerticalSliceTemplate.Models;
using VerticalSliceTemplate.Pages.Products;

namespace VerticalSliceTemplate.Tests.Products
{
    public class EditProductHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_UpdatesProduct()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options; // Unique database name for each test

            using var db = new ApplicationDbContext(options);

            var product = new Product { Id = 1, Name = "Widget 1", Price = 10 };

            db.Products.Add(product);
            await db.SaveChangesAsync();

            var handler = new EditProductHandler(db);
            var command = new EditProduct { Id = 1, Name = "Updated Widget", Price = 20 };

            // Act
            await handler.Handle(command, default);

            // Assert
            var updatedProduct = await db.Products.FindAsync(1);
            Assert.NotNull(updatedProduct);
            Assert.Equal("Updated Widget", updatedProduct.Name);
            Assert.Equal(20, updatedProduct.Price);
        }
    }
}
