using MediatR;
using VerticalSliceTemplate.Data;

namespace VerticalSliceTemplate.Pages.Products
{
    public class DeleteProductHandler(ApplicationDbContext db) : IRequestHandler<DeleteProduct>
    {
        private readonly ApplicationDbContext _db = db;
        public async Task Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync([request.Id], cancellationToken);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
