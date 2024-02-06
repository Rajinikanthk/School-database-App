using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School_database__App.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ClasseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClasseDbContext") ?? throw new InvalidOperationException("Connection string 'ClasseDbContext' not found.")));
builder.Services.AddDbContext<SubjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SubjectDbContext") ?? throw new InvalidOperationException("Connection string 'SubjectDbContext' not found.")));
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDbContext") ?? throw new InvalidOperationException("Connection string 'StudentDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
