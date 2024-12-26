using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StockApp.Models;
using StockApp.Services;

namespace StockApp.Controllers
{
    public class HomeController : Controller
    {
        private MyInterface _myInterface;
        private readonly IOptions<TradingOptions> _options;
        public HomeController(MyInterface myInterface, IOptions<TradingOptions> options)
        {
            _myInterface = myInterface;
            _options = options;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if(_options.Value.DefaultStockSymbol == null)
            {
                _options.Value.DefaultStockSymbol = "AAPL";
            }
            Dictionary<string, object> responseDictionary 
                = await _myInterface.GetStockPriceQuote(_options.Value.DefaultStockSymbol);

            StockInfo stockInfo = new StockInfo()
            {
                StockSymbol = _options.Value.DefaultStockSymbol,
                c = Convert.ToDouble(responseDictionary["c"].ToString()),
                d = Convert.ToDouble(responseDictionary["d"].ToString()),
                dp = Convert.ToDouble(responseDictionary["dp"].ToString()),
                h = Convert.ToDouble(responseDictionary["h"].ToString()),
                l = Convert.ToDouble(responseDictionary["l"].ToString()),
                o = Convert.ToDouble(responseDictionary["o"].ToString()),
                pc = Convert.ToDouble(responseDictionary["pc"].ToString()),
                t = Convert.ToDouble(responseDictionary["t"].ToString())
            };
            return View(stockInfo);
        }
    }
}
