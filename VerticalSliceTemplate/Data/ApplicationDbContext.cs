using Microsoft.EntityFrameworkCore;
using VerticalSliceTemplate.Models;

namespace VerticalSliceTemplate.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = null!;
    }
}
