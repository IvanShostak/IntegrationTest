using System.Net;
using System.Net.Http.Json;
using LearningLogging.Helpers.Endpoints;
using LearningLogging.Helpers.Entities;
using LearningLogging.Helpers.Entities.Product;
using NUnit.Framework;

namespace LearningLogging.Scenarios.Products;

internal class ProductScenarios : BasicScenarios
{
    [Test]
    public static async Task CreateProductAndVerifyFields()
    {
        var product = new Product("title1", "description1", 190f);
        var responseProduct = await HttpClient.CreatePosition(product);
        var responseGetProduct = await HttpClient.GetProduct(responseProduct);
        responseGetProduct.AssertProduct(product);
    }

    [Test]
    public static async Task TryToCreateProductWithoutPrice()
    {
        var product = new Product("title2", "description2", null);
        HttpClient.CreatePosition(product, HttpStatusCode.BadRequest);
    }

    [Test]
    public static async Task EditProductAndGet()
    {
        var product = new Product("title1", "description1", 120f);
        var responseCreateProduct = await HttpClient.CreatePosition(product);
        product.Price = 100f;
        responseCreateProduct.Price = 100f;
        var responseEditProduct = await HttpClient.EditPosition(responseCreateProduct);
        var responseGetProduct = await HttpClient.GetProduct(responseEditProduct);
        responseGetProduct.AssertProduct(product);
    }
}
