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

        public bool UpdateProduct(ProductModel product)
        {
            return _repo.Update(product);
        }

        public ProductModel GetProduct(int id)
        {
            return _repo.GetById(id);
        }

        public List<ProductModel> SearchByName(string name) 
        { 
            List<ProductModel> products = _repo.GetAll();
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (ProductModel product in products) 
            {
                if (product.name.ToLower() == name.ToLower())
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }

        public List<ProductModel> SearchByPrice(float price)
        {
            List<ProductModel> products = _repo.GetAll();
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (ProductModel product in products)
            {
                if (product.salePrice== price)
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }

        public List<ProductModel> SearchByPriceRange(float min, float max)
        {
            List<ProductModel> products = _repo.GetAll();
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (ProductModel product in products)
            {
                if (product.salePrice >= min && product.salePrice<=max )
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }

        public List<ProductModel> SearchByPriceDiff(float price)
        {
            List<ProductModel> products = _repo.GetAll();
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (ProductModel product in products)
            {
                if ((product.salePrice - product.purchasePrice) == price)
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }

        public List<ProductModel> SearchByNameChar(string chars)
        {
            List<ProductModel> products = _repo.GetAll();
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (ProductModel product in products)
            {
                if (product.name.ToLower().Contains(chars.ToLower()))
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }
    }
}
