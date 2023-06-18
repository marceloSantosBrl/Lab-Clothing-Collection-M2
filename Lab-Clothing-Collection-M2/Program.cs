using FluentValidation;
using Lab_Clothing_Collection_M2;
using Lab_Clothing_Collection_M2.Context;
using Lab_Clothing_Collection_M2.Repository.CollectionRepository;
using Lab_Clothing_Collection_M2.Repository.UserRepository;
using Lab_Clothing_Collection_M2.Validators;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClothingContext>();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICollectioRepository, CollectionRepository>();
builder.Services.AddTransient<UserValidator>();
builder.Services.AddTransient<CollectionValidator>();
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