using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RerdisDemo.Models;

namespace RerdisDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistributedCache _distributedCache;

        public HomeController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<ActionResult> SaveRedisCache()
        {
            var dashboard = new Dashboard
            {
                TotalCustomersCount = 100450,
                TotalRevenue = 12908092,
                TopSellingProduct = "United States",
                TopSellingCountryName = "Macbook"
            };

            var tomorrow = DateTime.Now.Date.AddDays(1);
            var totalSeconds = tomorrow.Subtract(DateTime.Now).TotalSeconds;

            var distributedCacheEntryOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(totalSeconds)
            };

            var jsonData = JsonConvert.SerializeObject(dashboard);
            await _distributedCache.SetStringAsync("Dashboard", jsonData, distributedCacheEntryOptions);
            Console.WriteLine(jsonData);
            //(""Dashboard") given above 36 line its a key Name.

            return View();
        }
    }
}
