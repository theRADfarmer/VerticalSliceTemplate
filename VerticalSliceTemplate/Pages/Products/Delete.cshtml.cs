using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerticalSliceTemplate.Models;

namespace VerticalSliceTemplate.Pages.Products
{
    public class DeleteModel(IMediator mediator) : PageModel
    {
        private readonly IMediator _mediator = mediator;

        [BindProperty]
        public required DeleteProduct Form { get; set; }

        public required Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _mediator.Send(new GetProductById { Id = id });

            if (product == null)
                return NotFound();

            Product = product;
            Form = new DeleteProduct { Id = id };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(Form);
            return RedirectToPage("Index");
        }
    }
}
