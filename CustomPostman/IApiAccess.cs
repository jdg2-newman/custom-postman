

namespace CustomPostman
{
    public interface IApiAccess
    {
       /// <summary>
       /// Calls api for GET
       /// </summary>
       /// <param name="url"></param>
       /// <param name="content"></param>
       /// <param name="action"></param>
       /// <param name="formatOutput"></param>
       /// <returns></returns>
        Task<string> CallApiAsync(string url, string content, HttpAction action = HttpAction.GET, bool formatOutput = true);
        /// <summary>
        /// Calls api for all other REST methods
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="action"></param>
        /// <param name="formatOutput"></param>
        /// <returns></returns>
        Task<string> CallApiAsync(string url, HttpContent? content = null, HttpAction action = HttpAction.GET, bool formatOutput = true);

        /// <summary>
        /// Validates the url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        bool ValidateUrl(string url);
    }
}