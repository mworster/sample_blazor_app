using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using StockReader.Models;

public class StockInfoService
{
    private readonly HttpClient _httpClient;
    // This should normally be stored in "Secerts" or "Keys"
    private const string API_KEY = "ct8ado9r01qtkv5rupp0ct8ado9r01qtkv5ruppg";
    private const string API_URL = "";

    public StockInfoService(HttpClient httpClient) => _httpClient = httpClient;


    //Wanted to be fancy and get the company name
    public async Task<string> GetCompanyNameAsync(string symbol)
    {
        var companyUrl = $"https://finnhub.io/api/v1/stock/profile2?symbol={symbol}&token={API_KEY}";
        try
        {
            var response = await _httpClient.GetStringAsync(companyUrl);
            var companyData = JsonSerializer.Deserialize<CompanyProfileResponse>(response);

            return companyData.name;
        }
        catch (Exception ex)
        {
            // Log any error that occurs during the HTTP request
            Console.WriteLine("Error fetching stock name: " + ex.Message);
            return null;
        }        
    }

// Again.. extra fancy. Let's pull more info than required.
    public async Task<StockInfo> GetStockInfo(string symbol)
    {
        var url = $"https://finnhub.io/api/v1/quote?symbol={symbol}&token={API_KEY}";

        try
        {
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<StockPriceResponse>(response);

            // Return the stock data
            return new StockInfo
            {
                OpenPrice = data.o,
                HighPrice = data.h,
                LowPrice = data.l
            };  
        }
        catch (Exception ex)
        {
            // Log any error that occurs during the HTTP request
            Console.WriteLine("Error fetching stock price: " + ex.Message);
            return null;
        }
    }
}