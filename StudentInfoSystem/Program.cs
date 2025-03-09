using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Load configuration (from appsettings.json)
var configuration = builder.Configuration;

// 🔹 Add SQL Server connection
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// 🔹 Register Repositories, Services & Controllers
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<SubjectRepository>();

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<SubjectService>();

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 

app.Run();