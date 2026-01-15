using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.API.Controllers
{
    public class StocksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
