using IlProgettoQuasiFinale.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlProgettoQuasiFinale.Services
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAll();
    }
}
