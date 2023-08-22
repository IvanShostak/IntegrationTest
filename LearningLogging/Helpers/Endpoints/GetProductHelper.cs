using System.Net;
using LearningLogging.Helpers.Entities;
using LearningLogging.Helpers.Entities.Product;

namespace LearningLogging.Helpers.Endpoints;

public static class GetProductHelper
{
 public static Task<ResponseProduct> GetProduct(this HttpClient client, ResponseProduct position)
    {
        return client.GetProduct(position.Id);
    }

    public static Task<ResponseProduct> GetProduct(this HttpClient client, int id, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var response = client.GetAndAssertStatusCode($"{Constants.ProductUrl}/{id}", statusCode).Result;
        return EndpointHelper.DeserializeJsonResponse<ResponseProduct>(response);
    }
}
