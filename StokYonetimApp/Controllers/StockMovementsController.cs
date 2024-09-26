using Microsoft.AspNetCore.Mvc;
using StokYonetimApp.Models;
using StokYonetimApp.Repository;

namespace StokYonetimApp.Controllers
{
    public class StockMovementsController : Controller
    {
        private readonly StockMovementsRepository _stockMovementRepository;
        private readonly ProductsRepository _productsRepository;

        public StockMovementsController(StockMovementsRepository stockMovementRepository, ProductsRepository productsRepository)
        {
            _stockMovementRepository = stockMovementRepository;
            _productsRepository = productsRepository;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            IEnumerable<StockMovements> stockMovements;

            if (startDate.HasValue && endDate.HasValue)
            {
                stockMovements = _stockMovementRepository.GetAllByDateRange(startDate.Value, endDate.Value);
            }
            else
            {
                stockMovements = _stockMovementRepository.GetAll();
            }

            return View(stockMovements);
        }


        public IActionResult Create()
        {
            var products = _productsRepository.GetAll();
            ViewBag.Products = products; 
            return View();
        }

        [HttpPost]
        public IActionResult Create(StockMovements stockMovement)
        {

            _stockMovementRepository.Add(stockMovement);
            return RedirectToAction(nameof(Index));
        }
    }
}
