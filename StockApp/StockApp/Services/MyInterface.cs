namespace StockApp.Services
{
    public interface MyInterface
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
    }
}
