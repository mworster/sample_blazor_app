namespace StockReader.Models
{
public class CompanyProfileResponse
{
    public string country { get; set; }  // Country
    public string currency { get; set; }  // Currency
    public string estimateCurrency { get; set; }  // Estimate Currency
    public string exchange { get; set; }  // Exchange
    public string finnhubIndustry { get; set; }  // Industry
    public string ipo { get; set; }  // IPO Date
    public string logo { get; set; }  // Company logo URL
    public double marketCapitalization { get; set; }  // Market Cap
    public double shareOutstanding { get; set; }  // Shares Outstanding
    public string ticker { get; set; }  // Ticker Symbol
    public string phone { get; set; }  // Phone number
    public string weburl { get; set; }  // Website URL
    public string name { get; set; }  // Company Name
}


}