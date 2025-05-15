using MediatR;

namespace VerticalSliceTemplate.Pages.Products
{
    public class DeleteProduct : IRequest
    {
        public int Id { get; set; }
    }
}
