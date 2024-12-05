public class StockPriceResponse
{
     public decimal c { get; set; }  // Current price
    public decimal d { get; set; }  // Change in price
    public decimal dp { get; set; } // Percentage change in price
    public decimal h { get; set; }  // High price
    public decimal l { get; set; }  // Low price
    public decimal o { get; set; }  // Open price
    public decimal pc { get; set; } // Previous close price
    public long t { get; set; }    // Timestamp of the quote
}