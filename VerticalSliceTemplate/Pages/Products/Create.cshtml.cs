using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VerticalSliceTemplate.Pages.Products
{
    public class CreateModel(IMediator mediator) : PageModel
    {
        private readonly IMediator _mediator = mediator;

        [BindProperty]
        public required CreateProduct Form { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _mediator.Send(Form);
            return RedirectToPage("Index");
        }
    }
}
