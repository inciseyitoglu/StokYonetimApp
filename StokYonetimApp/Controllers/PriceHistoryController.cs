using Microsoft.AspNetCore.Mvc;
using StokYonetimApp.Models;
using StokYonetimApp.Repository;

namespace StokYonetimApp.Controllers
{
    public class PriceHistoryController : Controller
    {
        private readonly PriceHistoryRepository _priceHistoryRepository;
        private readonly ProductsRepository _productsRepository;

        public PriceHistoryController(PriceHistoryRepository priceHistoryRepository, ProductsRepository productsRepository)
        {
            _priceHistoryRepository = priceHistoryRepository;
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var priceHistories = _priceHistoryRepository.GetAll().ToList();

            var products = _productsRepository.GetAll().ToDictionary(p => p.ProductId);

            foreach (var priceHistory in priceHistories)
            {
                if (products.TryGetValue(priceHistory.ProductId, out var product))
                {
                    priceHistory.Products = product; 
                }
            }

            return View(priceHistories);

        }

        public IActionResult Create()
        {
            var products = _productsRepository.GetAll(); 
            ViewBag.Products = products; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PriceHistory priceHistory)
        {

            _priceHistoryRepository.Add(priceHistory);
            return RedirectToAction(nameof(Index));

        }
    }
}
