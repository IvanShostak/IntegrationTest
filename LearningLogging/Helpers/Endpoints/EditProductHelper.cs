using System.Net;
using LearningLogging.Helpers.Entities;
using LearningLogging.Helpers.Entities.Product;
using Serilog;

namespace LearningLogging.Helpers.Endpoints;

internal static class EditProductHelper
{
    public static Task<ResponseProduct> EditPosition(this HttpClient client, Product product)
    {
        var response = client.PutAndAssertStatusCode($"{Constants.ProductUrl}/{product.Id}", product, HttpStatusCode.OK).Result;
        return EndpointHelper.DeserializeJsonResponse<ResponseProduct>(response);
    }
}
