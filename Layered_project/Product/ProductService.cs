using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Product
{
    internal class ProductService
    {
        private ProductRepo _repo;

        public ProductService()
        {
            _repo = new ProductRepo();
        }

        public void SaveProduct(ProductModel product)
        {
            _repo.SaveInFile(product);
        }

        public List<ProductModel> GetAllData()
        {
            return _repo.GetAllProducts();
        }

        public ProductModel SearchByName(string name)
        {
            foreach(var product in _repo.GetAllProducts())
            {
                if(product.GetName() == name)
                {
                    return product;
                }
            }
            return null;
        }

        public List<ProductModel> SearchByPrice(float price)
        {
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (var product in _repo.GetAllProducts())
            {
                if (product.GetSalePrice() == price)
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }


        public List<ProductModel> SearchByPriceRange(float start_price, float end_price)
        {
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (var product in _repo.GetAllProducts())
            {
                if (product.GetSalePrice() >= start_price && product.GetSalePrice() <= end_price)
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }


        public List<ProductModel> SearchByPriceDiff(float Diff)
        {
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (var product in _repo.GetAllProducts())
            {
                if ((product.GetSalePrice() - product.GetPurchasePrice()) == Diff)
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }

        public List<ProductModel> SearchByNameChar(string chars)
        {
            List<ProductModel> matchedProducts = new List<ProductModel>();
            foreach (var product in _repo.GetAllProducts())
            {
                if (product.GetName().ToLower().Contains(chars.ToLower()))
                {
                    matchedProducts.Add(product);
                }
            }
            return matchedProducts;
        }

        public bool UpdateProductPrice(string name, float salePrice)
        {
            List<ProductModel> products = _repo.GetAllProducts();
            foreach (var product in products)
            {
                if(product.GetName()== name)
                {
                    product.SetSalePrice(salePrice);
                    _repo.SaveAllInFile(products);
                    return true;

                }
            }
            return false;
        }

        public bool DelteProductByName(string name)
        {
            List<ProductModel> products = _repo.GetAllProducts();
            int count = 0;
            foreach (var product in products)
            {
                if (product.GetName() == name)
                {
                    products.RemoveAt(count);
                    _repo.SaveAllInFile(products);
                    return true;
                }
                count++;
            }
            return false;
        }
    }
}
