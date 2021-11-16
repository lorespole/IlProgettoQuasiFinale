using IlProgettoQuasiFinale.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlProgettoQuasiFinale.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> products(int ProductId, string ProductName);
        public IEnumerable<Category> categories(int CategoryId, string CategoryName);
        public Product Edit(Product product);
        public Product Insert(Product product);
        public bool Delete(Product product);
    }
}
