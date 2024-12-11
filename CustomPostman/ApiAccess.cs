using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace CustomPostman
{
    public class ApiAccess : IApiAccess
    {
        private HttpClient HttpClient { get; }
        private ILogger<ApiAccess> Logger { get; }

        public ApiAccess(
            ILogger<ApiAccess> logger)
        {
            this.Logger = logger;
        }

        public async Task<string> CallApiAsync(
            string url,
            string content,
            HttpAction action = HttpAction.GET,
            bool formatOutput = true
            )
        {
            StringContent stringContent = new(content, Encoding.UTF8, "application/json");
            return await CallApiAsync(url, stringContent, action, formatOutput);
        }

        public async Task<string> CallApiAsync(
            string url,
            HttpContent? content = null,
            HttpAction action = HttpAction.GET,
            bool formatOutput = true          
            )
        {

            this.Logger.LogInformation("Calling API");
            HttpResponseMessage? response;

            switch (action)
            {
                case HttpAction.GET:
                    response = await HttpClient.GetAsync(url);
                    break;
                case HttpAction.POST:
                    response = await HttpClient.PostAsync(url, content);
                    break;
                case HttpAction.PUT:
                    response = await HttpClient.PutAsync(url, content);
                    break;
                case HttpAction.PATCH:
                    response = await HttpClient.PatchAsync(url, content);
                    break;
                case HttpAction.DELETE:
                    response = await HttpClient.DeleteAsync(url);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                if (formatOutput)
                {
                    var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);

                    json = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = false });
                }

                return json;
            }
            else
            {
                this.Logger.LogError("Could not call API");
                return $"Error: {response.StatusCode}";
            }

        }

        /// <summary>
        /// Change this banner
        /// </summary>
        /// <param name="hello"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task PostApi(string hello)
        {
            if (string.IsNullOrEmpty(hello))
            {
                throw new NotImplementedException();
            }
            
        
        }

        public bool ValidateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            bool output = Uri.TryCreate(url, UriKind.Absolute, out Uri result) && (result.Scheme == Uri.UriSchemeHttps);

            return output;
        }
    }
}
