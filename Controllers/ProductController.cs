using GestioneMagazzinonew.Models;
using IlProgettoQuasiFinale.Models;
using IlProgettoQuasiFinale.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlProgettoQuasiFinale.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ILogger<ProductController> _context;
        private IProductService _productService;
        public ProductController(Data.NORTHWINDContext context)
        {
            
        }
        public ProductController(ILogger<ProductController> logger , ILogger<ProductController> context, IProductService productService)
        {
            _logger = logger;
            _context = context;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {

            return View();
        }
        public IActionResult Read()
        {

            return View();
        }
        public IActionResult Update()
        {

            return View();
        }
        public IActionResult Delete()
        {
            
            return View();
        }
    }
}
