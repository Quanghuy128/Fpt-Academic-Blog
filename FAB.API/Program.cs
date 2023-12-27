using FAB.API.Configurations;
using FAB.Domain.Common;
using FAB.Infrastructure.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.SettingsBinding();
builder.Services.AddDbContext();
builder.ConfigureAutofacContainer();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(AppConfig.ConnectionStrings.DefaultConnection));

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
