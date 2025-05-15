using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VerticalSliceTemplate.Data;
using VerticalSliceTemplate.Models;

namespace VerticalSliceTemplate.Pages.Products
{
    public class IndexModel(ApplicationDbContext db) : PageModel
    {
        private readonly ApplicationDbContext _db = db;

        public List<Product> Products { get; private set; } = [];

        public async Task OnGetAsync()
        {
            Products = await _db.Products.ToListAsync();
        }
    }
}
