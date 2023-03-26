using Microsoft.EntityFrameworkCore;
using ProgrammingPalliAPIDemo.Data;
using ProgrammingPalliAPIDemo.Interfaces.Manager;
using ProgrammingPalliAPIDemo.Manager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddTransient<IPostManager, PostManager>();
//builder.Services.AddScoped<IPostManager, PostManager>();
//builder.Services.AddSingleton<IPostManager, PostManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

