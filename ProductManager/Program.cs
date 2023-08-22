using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var products = new List<Product>();
var idCounter = 1;

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/api/products/{id:int}", (int id) =>
{
    var product = products.Find(t => t.Id == id);
    if(product != null)
    {
        return Results.Ok(product);
    }
    return Results.NoContent();
}) ;

app.MapPost("/api/products", (Product product) =>
{
    if(product.Price != null && product.Title != null)
    {
        product.Id = idCounter++;
        products.Add(product);
        return Results.Created($"/api/products/{product.Id}", product);
    }
    return Results.BadRequest("Missing field title or price");
});

app.MapPut("/api/products/{id}", (int id, Product updatedProduct) =>
{
    var existingProduct = products.Find(t => t.Id == id);
    if (existingProduct != null)
    {
        existingProduct.Price = updatedProduct.Price;
        existingProduct.Description = updatedProduct.Description;
        existingProduct.Title = updatedProduct.Title;
        return Results.Ok(existingProduct);
    }
    return Results.NotFound();
});

app.Run();

public partial class Program { }

public class Product
{
    public int Id { get; set; }
    public float? Price { get; set; }
    public string Description { get; set; }
    public string? Title { get; set; }

    public Product(string title, string description, float? price)
    {
        Title = title;
        Description = description;
        Price = price;
    }
}
