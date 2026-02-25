using Microsoft.EntityFrameworkCore;
using student.api.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("studentCon")));

builder.Services.AddCors(opt =>
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowCredentials().AllowAnyMethod()
              .WithOrigins("http://localhost:57396");
    }));

var app = builder.Build();

// Middleware
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();

// Test root endpoint
app.MapGet("/", () => "Student API is running!");

// Map controllers
app.MapControllers();

app.Run();
