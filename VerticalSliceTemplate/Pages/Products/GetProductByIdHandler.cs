using MediatR;
using VerticalSliceTemplate.Data;
using VerticalSliceTemplate.Models;

namespace VerticalSliceTemplate.Pages.Products
{
    public class GetProductByIdHandler(ApplicationDbContext db) : IRequestHandler<GetProductById, Product?>
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<Product?> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            return await _db.Products.FindAsync([request.Id], cancellationToken);
        }
    }
}
