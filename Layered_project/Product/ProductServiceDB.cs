using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Product
{
    internal class ProductServiceDB
    {
        private ProductRepoDB _repo;
        public ProductServiceDB()
        {
            _repo = new ProductRepoDB();
        }
        public bool SaveProduct(ProductModel product)
        {
            return _repo.Create(product);
        }
        public List<ProductModel> GetAllProducts()
        {
            return _repo.GetAll();
        }

        public bool DeleteProduct(int id)
        {
            return _repo.Delete(id);
        }
    }
}
