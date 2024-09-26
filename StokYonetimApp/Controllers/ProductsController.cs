using Microsoft.AspNetCore.Mvc;
using StokYonetimApp.Models;
using StokYonetimApp.Repository;

namespace StokYonetimApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;


        public ProductsController(ProductsRepository productRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            var categories = _categoryRepository.GetAll(); 
            ViewBag.Categories = categories; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products product)
        {

            _productRepository.Add(product);
            return RedirectToAction(nameof(Index));

        }
    }
}
