using System.Net;
using LearningLogging.Helpers.Entities;
using LearningLogging.Helpers.Entities.Product;
using Serilog;

namespace LearningLogging.Helpers.Endpoints;

internal static class CreateProductHelper
{
    public static Task<ResponseProduct> CreatePosition(this HttpClient client, Product product)
    {
        var response = client.PostAndAssertStatusCode(Constants.ProductUrl, product, HttpStatusCode.Created).Result;
        return EndpointHelper.DeserializeJsonResponse<ResponseProduct>(response);
    }

    public static async void CreatePosition(this HttpClient client, Product product, HttpStatusCode statusCode)
    {
        await client.PostAndAssertStatusCode(Constants.ProductUrl, product, statusCode);
    }
}
