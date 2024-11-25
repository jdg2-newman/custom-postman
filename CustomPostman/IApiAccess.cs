

namespace CustomPostman
{
    public interface IApiAccess
    {
       
        Task<string> CallApiAsync(string url, string content, HttpAction action = HttpAction.GET, bool formatOutput = true);
        Task<string> CallApiAsync(string url, HttpContent? content = null, HttpAction action = HttpAction.GET, bool formatOutput = true);

        /// <summary>
        /// Validates the url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        bool ValidateUrl(string url);
    }
}