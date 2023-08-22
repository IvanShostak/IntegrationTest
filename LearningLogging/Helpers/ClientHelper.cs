using System.Diagnostics.Tracing;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using NUnit.Framework;
using Serilog;

namespace LearningLogging.Helpers;

internal static class ClientHelper
{
    public static async Task<HttpResponseMessage> PostAndAssertStatusCode<T>(this HttpClient client, string endpoint, T requestModel, HttpStatusCode statusCode)
    {
        Log.Information($"REQUEST: [POST] to {client.BaseAddress}/{endpoint} with \n{JsonSerializer.Serialize(requestModel)}\n");
        HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, requestModel);
        Log.Information($"RESPONSE: {(int)response.StatusCode} with \n{response.Content.ReadAsStringAsync().Result}\n");
        AssertHelper.AssertEqual((int)statusCode, (int)response.StatusCode, "Status Code");
        return response;
    }

    public static async Task<HttpResponseMessage> PutAndAssertStatusCode<T>(this HttpClient client, string endpoint, T requestModel, HttpStatusCode statusCode)
    {
        Log.Information($"REQUEST: [Get] to {client.BaseAddress}/{endpoint} \n");
        HttpResponseMessage response = await client.PutAsJsonAsync(endpoint, requestModel);
        Log.Information($"RESPONSE: {(int)response.StatusCode} with \n{response.Content.ReadAsStringAsync().Result}\n");
        AssertHelper.AssertEqual((int)statusCode, (int)response.StatusCode, "Status Code");
        return response;
    }

    public static async Task<HttpResponseMessage> GetAndAssertStatusCode(this HttpClient client, string endpoint, HttpStatusCode statusCode)
    {
        Log.Information($"REQUEST: [Get] to {client.BaseAddress}/{endpoint} \n");
        HttpResponseMessage response = await client.GetAsync(endpoint);
        Log.Information($"RESPONSE: {(int)response.StatusCode} with \n{response.Content.ReadAsStringAsync().Result}\n");
        AssertHelper.AssertEqual((int)statusCode, (int)response.StatusCode, "Status Code");
        return response;
    }
}
