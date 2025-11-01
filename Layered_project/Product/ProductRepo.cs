using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Product
{
    internal class ProductRepo
    {
        private readonly string file = "product.txt";

        public ProductRepo()
        {

        }

        public void SaveInFile(ProductModel product)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(product.ToString());
            }
        }

        public void SaveAllInFile(List<ProductModel> products)
        {
            File.WriteAllText(file, string.Empty);
            foreach(var product in products)
            {
                SaveInFile(product);
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> productsList = new List<ProductModel>();
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while((line= stream.ReadLine())!= null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    string desc = parts[1];
                    float purchasePrice = float.Parse(parts[2]);
                    float salePrice = float.Parse(parts[3]);
                    float discount = float.Parse(parts[4]);

                    ProductModel product = new ProductModel(name, desc, purchasePrice, salePrice, discount);
                    productsList.Add(product);
                }
            }
            return productsList;
        }
    }
}