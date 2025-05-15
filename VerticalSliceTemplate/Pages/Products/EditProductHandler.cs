using MediatR;
using VerticalSliceTemplate.Data;

namespace VerticalSliceTemplate.Pages.Products
{
    public class EditProductHandler(ApplicationDbContext db) : IRequestHandler<EditProduct>
    {
        private readonly ApplicationDbContext _db = db;
        public async Task Handle(EditProduct request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync([request.Id], cancellationToken);
            if (product != null)
            {
                product.Name = request.Name;
                product.Price = request.Price;
                await _db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
