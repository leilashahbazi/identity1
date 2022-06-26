using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(config =>
{
     config.UseInMemoryDatabase("Memory");
});
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
   .AddEntityFrameworkStores<AppDbContext>()
   .AddDefaultTokenProviders(); 
     
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

app.UseAuthorization();

app.MapControllers();

app.Run();
