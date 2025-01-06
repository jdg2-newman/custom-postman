using System.Net;

using System.Text;
using System.Text.Json;
using CustomPostman;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;


namespace CustomPostmanTests
{
    public class ApiAccessTests
    {
        private readonly Mock<ILogger<ApiAccess>> loggerMock;
        private readonly Mock<HttpMessageHandler> httpMessageHandlerMock;
        private readonly HttpClient httpClient;
        private readonly ApiAccess apiAccess;

        public ApiAccessTests()
        {
            loggerMock = new Mock<ILogger<ApiAccess>>();
            httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            httpClient = new HttpClient(httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("http://localhost")
            };

            apiAccess = new ApiAccess(loggerMock.Object)
            {
                
            };
        }

        [Fact]
        public async Task CallApiAsync_GetRequest_Success()
        {
            // Arrange
            string url = "/test";
            string expectedResponse = "{\"message\":\"success\"}";

            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri.ToString() == httpClient.BaseAddress + url),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse, Encoding.UTF8, "application/json")
                });

            // Act
            string result = await apiAccess.CallApiAsync(url);

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task CallApiAsync_PostRequest_Success()
        {
            // Arrange
            string url = "/test";
            string requestBody = "{\"key\":\"value\"}";
            string expectedResponse = "{\"message\":\"created\"}";

            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri.ToString() == httpClient.BaseAddress + url && req.Content.ReadAsStringAsync().Result == requestBody),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    Content = new StringContent(expectedResponse, Encoding.UTF8, "application/json")
                });

            // Act
            string result = await apiAccess.CallApiAsync(url, requestBody, HttpAction.POST);

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task CallApiAsync_Failure_ReturnsErrorMessage()
        {
            // Arrange
            string url = "/test";

            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri.ToString() == httpClient.BaseAddress + url),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                });

            // Act
            string result = await apiAccess.CallApiAsync(url);

            // Assert
            Assert.Equal("Error: InternalServerError", result);
        }

        [Fact]
        public async Task CallApiAsync_FormatsOutput_Success()
        {
            // Arrange
            string url = "/test";
            string unformattedResponse = "{\"message\":\"success\"}";
            string expectedFormattedResponse = JsonSerializer.Serialize(
                JsonSerializer.Deserialize<JsonElement>(unformattedResponse),
                new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = false }
            );

            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri.ToString() == httpClient.BaseAddress + url),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(unformattedResponse, Encoding.UTF8, "application/json")
                });

            // Act
            string result = await apiAccess.CallApiAsync(url, formatOutput: true);

            // Assert
            Assert.Equal(expectedFormattedResponse, result);
        }
    }
}