
namespace CustomPostman
{
    public interface IApiAccess
    {
        /// <summary>
        /// Calls api
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formatOutput"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<string> CallApiAsync(string url, bool formatOutput = true, HttpAction action = HttpAction.GET);
        /// <summary>
        /// Validates the url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        bool ValidateUrl(string url);
    }
}