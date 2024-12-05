using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class StockInfoService
{
    private readonly HttpClient _httpClient;
    private const string API_KEY = "ct8ado9r01qtkv5rupp0ct8ado9r01qtkv5ruppg";
    private const string API_URL = "";

    public StockInfoService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<decimal> GetStockPriceAsync(string symbol, string apiKey)
    {
        var url = $"https://finnhub.io/api/v1/quote?symbol={symbol}&token={apiKey}";

        Console.WriteLine(url);

        try
        {
            // Make the API request
            var response = await _httpClient.GetStringAsync(url);
            
            // Log the full response to see what's returned
            Console.WriteLine("Response from Finnhub: " + response);
            
            // Deserialize the response to get the stock price
            var stockPrice = JsonSerializer.Deserialize<StockPriceResponse>(response);

            if (stockPrice == null)
            {
                // If the response could not be deserialized, log and return 0
                Console.WriteLine("Failed to deserialize response.");
                return 0;
            }

            return stockPrice.c;
        }
        catch (Exception ex)
        {
            // Log any error that occurs during the HTTP request
            Console.WriteLine("Error fetching stock price: " + ex.Message);
            return 0;
        }
    }
}