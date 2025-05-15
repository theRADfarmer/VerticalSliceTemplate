using MediatR;
using VerticalSliceTemplate.Models;

namespace VerticalSliceTemplate.Pages.Products
{
    public class GetProductById : IRequest<Product?>
    {
        public int Id { get; set; }
    }
}
