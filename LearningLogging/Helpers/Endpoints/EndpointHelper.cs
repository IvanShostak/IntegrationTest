using Newtonsoft.Json;

namespace LearningLogging.Helpers.Endpoints;

internal static class EndpointHelper
{
    public static async Task<T> DeserializeJsonResponse<T>(HttpResponseMessage httpResponseMessage)
    {
        var content = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content);
    }
}