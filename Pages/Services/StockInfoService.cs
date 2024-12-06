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

    /*public async Task<string> GetCompanyNameAsync(string symbol)
    {
        try
        {
            // Build the API request URL for stock profile (profile2 endpoint)
            string url = $"https://finnhub.io/api/v1/stock/profile2?symbol={symbol}&token={_apiKey}";

            // Make the GET request to the Finnhub API
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response content
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize the response into the model
                    var stockProfile = JsonConvert.DeserializeObject<StockProfileResponse>(jsonResponse);

                    // Return the company name
                    return stockProfile?.Name ?? "Company name not found";
                }
                else
                {
                    return "Error fetching stock data.";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }*/
}