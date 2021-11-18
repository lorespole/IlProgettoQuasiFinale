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
                p.CategoryId = product.CategoryId.GetValueOrDefault();
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
        public IActionResult Insert(ProductViewModel model)
        {
            try 
            {
                if(ModelState.IsValid) 
                {
                    Products products = new Products();
                    products.ProductName = model.ProductName;
                    products.CategoryId = model.CategoryId;
                    products.QuantityPerUnit = model.QuantityPerUnit;
                    products.ReorderLevel = model.ReorderLevel;
                    products.UnitsInStock = model.UnitsInStock;
                    products.UnitPrice = model.UnitPrice;
                    products.UnitsOnOrder = model.UnitsOnOrder;
                    _context.Products.Add(products);
                    _context.SaveChanges();
                    
                }
                var t = ModelState.Values.SelectMany(v => v.Errors);
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("Error", "Shared");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Save(int productId)
        {
            IActionResult result;
            try 
            {
                var productTemp = _context.Products.FirstOrDefault(x => x.ProductId == productId);
                _context.Add(productTemp);
                _context.SaveChanges();
            } catch (Exception ex) 
            {
                result = RedirectToAction("Error", "Home");
                ex.ToString();
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int productId)
        {
            
            var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            ProductViewModel p = new ProductViewModel();
            var category = _context.Categories.Where(x => x.CategoryId == product.CategoryId).FirstOrDefault();
            p.CategoryId = product.CategoryId.GetValueOrDefault();
            p.ProductId = product.ProductId;
            p.ProductName = product.ProductName;
            p.QuantityPerUnit = product.QuantityPerUnit;
            p.UnitPrice = product.UnitPrice;
            p.UnitsInStock = product.UnitsInStock;
            p.UnitsOnOrder = product.UnitsOnOrder;
            p.ReorderLevel = product.ReorderLevel;
            p.Discontinued = product.Discontinued;

            return View(p);
        }
        [HttpPost]
        public IActionResult Update(ProductViewModel model)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    Product product = new Product();
                    var productUpdate = _context.Products.FirstOrDefault(x => x.ProductId == model.ProductId);
                    productUpdate.ProductName = model.ProductName;
                    productUpdate.QuantityPerUnit = model.QuantityPerUnit;
                    productUpdate.UnitPrice = model.UnitPrice;
                    productUpdate.UnitsInStock = model.UnitsInStock;
                    productUpdate.UnitsOnOrder = model.UnitsOnOrder;
                    _context.Update(productUpdate);
                    _context.SaveChanges();
                }
                
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("Error", "Shared");
            }

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

