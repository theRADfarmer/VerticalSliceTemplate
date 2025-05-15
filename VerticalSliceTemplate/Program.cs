using VerticalSliceTemplate.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddRazorPages();
// Configure DbContext using in memory database  
// switch to desired database provider and install the corresponding EF Core NuGet package in production  
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseInMemoryDatabase("InMemoryDb"));
// Add MediatR for CQRS  
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
  .WithStaticAssets();

app.Run();
