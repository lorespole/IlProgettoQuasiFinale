using GestioneMagazzinonew.Models;
using IlProgettoQuasiFinale.Data;
using IlProgettoQuasiFinale.Domain;
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
        private NORTHWINDContext _context;

        public ProductController(NORTHWINDContext context)
        {
             _context = context;
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
        public void Delete(Product elem)
        {
            throw new NotImplementedException();
        }
    }
}
