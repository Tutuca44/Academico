using Academico.Models;
using Academico.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AcademicoContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("AcademicDatabase")
    )
);
builder.Services.AddScoped<IDepartamentoRepositorio, DepartamentoRepositorio>();
builder.Services.AddScoped<IEmpregadoRepositorio, EmpregadoRepositorio>();
//builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
//builder.Services.AddScoped<IMatriculaRepositorio, MatriculaRepositorio>();
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
