

using System.Text.Json;

namespace CustomPostman
{
    public class ApiAccess : IApiAccess
    {
        private readonly HttpClient client = new();

        public async Task<string> CallApiAsync(
            string url,
            bool formatOutput = true,
            HttpAction action = HttpAction.GET
            )
        {
            var response = await client.GetAsync(url);

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
                return $"Error: {response.StatusCode}";
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
