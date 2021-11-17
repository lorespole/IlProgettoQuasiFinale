using IlProgettoQuasiFinale.Entity;
using IlProgettoQuasiFinale.Data;
using IlProgettoQuasiFinale.Domain;
using IlProgettoQuasiFinale.Models;
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
        private NORTHWINDContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, NORTHWINDContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ProductListViewModel model = new ProductListViewModel();
            var products = _context.Products.Where(x => true).ToList();
            
            foreach (var product in products) {
                ProductViewModel p = new ProductViewModel();
                var category = _context.Categories.Where(x => x.CategoryId == product.CategoryId).FirstOrDefault();
                p.CategoryId = product.CategoryId;
                p.CategoryName = category.CategoryName;
                p.ProductId = product.ProductId;
                p.ProductName = product.ProductName;
                p.QuantityPerUnit = product.QuantityPerUnit;
                p.UnitPrice = product.UnitPrice;
                p.UnitsInStock = product.UnitsInStock;
                p.UnitsOnOrder = product.UnitsOnOrder;
                p.ReorderLevel = product.ReorderLevel;
                p.Discontinued = product.Discontinued;

                model.ProductList.Add(p);
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Save(int productId)
        {
            IActionResult result;
            try 
            {
                var productTemp = _context.Products.FirstOrDefault(x => x.ProductId == productId);
                _context.Products.Add(productTemp);

            } catch (Exception ex) 
            {
                result = RedirectToAction("Error", "Home");
                ex = (Exception)result;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Save(ProductViewModel model)
        {
            var categories = _context.Categories.Where(x => x.CategoryId == model.CategoryId);
            model.CategoryName = categories.FirstOrDefault(x => x.CategoryId == model.CategoryId)?.CategoryName;
            if(string.IsNullOrWhiteSpace(model.CategoryName)) 
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Categoria non valida");
            }
            if (ModelState.IsValid) 
            {
               _context.Add(model.CategoryName);
            }
            return View();
        }

        public IActionResult Update(ProductViewModel model)
        {
            
            var product = _context.Products.FirstOrDefault(x => x.ProductId == model.ProductId);

            product.CategoryId = product.CategoryId;
            product.ProductId = product.ProductId;
            product.ProductName = product.ProductName;
            product.QuantityPerUnit = product.QuantityPerUnit;
            product.UnitPrice = product.UnitPrice;
            //  product.UnitsInStock = product.UnitsInStock;

            _context.Products.Update(product);
             _context.SaveChanges();
            return View();
        }
        public IActionResult Delete(int productId)
        {
            var productTemp = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            _context.Products.Remove(productTemp);
            _context.SaveChanges();

            return View();
        }
    }
    
} 

