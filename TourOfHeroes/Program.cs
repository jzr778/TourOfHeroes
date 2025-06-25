using Microsoft.EntityFrameworkCore;
using Repository.DBContext;
using Repository.Interface;
using Repository.Repository;
using Service;
using Service.Interface;
using System;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ��� DbContext
builder.Services.AddDbContext<HeroContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("STArCRMDB")));

// ע��Repository
builder.Services.AddScoped<IHeroRepository, HeroRepository>();
// Service
builder.Services.AddScoped<IHeroService, HeroService>();

// ���Controller
builder.Services.AddControllers();

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
