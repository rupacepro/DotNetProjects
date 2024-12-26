using StockApp.Models;
using System.Text.Json;

namespace StockApp.Services
{
    public class MyService : MyInterface
    {
        private IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;
        public MyService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = 
                    new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["token"]}"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = 
                    await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);
                string content = streamReader.ReadToEnd();
                Dictionary<string, object> result = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
                //StockInfo stockInfo = new StockInfo();

                if(result == null )
                {
                    throw new InvalidOperationException("No response fron the server");
                }

                if (result.ContainsKey("error"))
                {
                    throw new InvalidOperationException(Convert.ToString(result["error"]));
                }

                return result;
            }
        }
    }
}
