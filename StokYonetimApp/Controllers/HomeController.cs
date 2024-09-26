using Microsoft.AspNetCore.Mvc;
using StokYonetimApp.Models;
using StokYonetimApp.Repository;
using System.Diagnostics;

namespace StokYonetimApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsRepository _productsRepository;
        private readonly StockMovementsRepository _stockMovementRepository;
        private readonly PriceHistoryRepository _priceHistoryRepository;
        private readonly CategoryRepository _categoryRepository;

        public HomeController(ProductsRepository productsRepository, StockMovementsRepository stockMovementRepository, PriceHistoryRepository priceHistoryRepository, CategoryRepository categoryRepository)
        {
            _productsRepository = productsRepository;
            _stockMovementRepository = stockMovementRepository;
            _priceHistoryRepository = priceHistoryRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(int? categoryId)
        {
            IEnumerable<Products> products;

            //Eðer category seçilmiþse
            if (categoryId.HasValue)
            {
                products = _productsRepository.GetAllByCategoryId(categoryId.Value);
            }
            else
            {
                products = _productsRepository.GetAll();
            }

            var productStockViewModels = new List<ProductStockViewModel>();

            foreach (var product in products)
            {
                var priceHistory = _priceHistoryRepository.GetLatestPriceByProductId(product.ProductId);


                var totalStock = _stockMovementRepository.GetTotalStockByProductId(product.ProductId);

                productStockViewModels.Add(new ProductStockViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    CurrentPrice = priceHistory?.NewPrice ?? product.ProductPrice,
                    TotalStock = totalStock,
                    MinimumStockLevel = product.MinimumStockLevel
                });
            }

            ViewBag.Categories = _categoryRepository.GetAll();

            return View(productStockViewModels);
        }


    }
}
