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

        public ProductController(ILogger<ProductController> logger, NORTHWINDContext context)
        {
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
        public IActionResult Add()
        {
           // _context.Products.Add();
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productInserito)
        {
            // _context.Products.Add(productInserito);
            return View();
        }
        public IActionResult Read(int productId)
        {
            var products = _context.Products.Where(x => true).ToList();
            var product = _context.Attach(productId);
            ProductViewModel model = new ProductViewModel();

          //  model.ProductId = product.


            return View();
        }
        public IActionResult Update(int productId)
        {
            var productTemp = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            _context.Products.Update(productTemp);
            _context.SaveChanges();
            return View();
         }
        public IActionResult Delete(int productId)
        {
            var productTemp = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            if (productTemp != null) {
                _context.Products.Remove(productTemp);
                _context.SaveChanges();
            }
            else 
            {
                Console.WriteLine("il valore del prodotto non esiste");
            }
            return View();
        }
    }
    
} 

