using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataExample;
using ODataExample.Context;
using ODataExample.Controllers;
using ODataExample.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(opt =>
        opt
        .Select()
        .Filter()
        .Count()
        .Expand()
        .OrderBy()
        .SetMaxTop(null)
        //.EnableQueryFeatures()
        .AddRouteComponents("odata", OdataController.GetEdmModel())
//
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ODataExample"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.AddProductApi();
app.UseAuthorization();
app.MapScalarApiReference();
app.MapControllers();
app.Run();
