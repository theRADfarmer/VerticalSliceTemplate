using MediatR;
using VerticalSliceTemplate.Data;
using VerticalSliceTemplate.Models;

// CreateProductHandler.cs
// Handles the CreateProduct request. Maps the request data to a Product entity and saves it to the database.

namespace VerticalSliceTemplate.Pages.Products
{
    public class CreateProductHandler(ApplicationDbContext db) : IRequestHandler<CreateProduct>
    {
        private readonly ApplicationDbContext _db = db;

        public async Task Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            _db.Products.Add(new Product
            {
                Name = request.Name,
                Price = request.Price
            });

            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
