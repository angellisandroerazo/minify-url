using Microsoft.EntityFrameworkCore;
using UrlShorteningService.Interfaces;
using UrlShorteningService.Services;
using UrlShorteningService.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<UrlContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUrlService, UrlService>();

builder.Services.AddCors(); builder.Services.AddCors(options =>
{
    options.AddPolicy("Site",
         policyBuilder =>
         {
             policyBuilder.WithOrigins("http://portafolio-angel.somee.com", "https://localhost:7101", "https://localhost:7270")
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials();
         });
});


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Site");

app.UseAuthorization();

app.MapControllers();

app.Run();
