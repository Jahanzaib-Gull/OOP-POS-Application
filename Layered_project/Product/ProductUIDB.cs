using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Product
{
    internal class ProductUIDB
    {
        ProductServiceDB service = new ProductServiceDB();


        public void PoductDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = ProductMenu();
                if (option == "1")
                {
                    ProductModel product = TakeInput();
                    service.SaveProduct(product);
                }
                else if (option == "2")
                {
                    UpdateProduct();
                }
                else if (option == "3")
                {
                    DeleteProduct();
                }
                else if (option == "4")
                {
                    DisplayAll();
                }
                else if (option == "5")
                {
                    AdvancedSearchDriver();
                }
                else if (option == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option selected");
                }
            }
        }

        public void AdvancedSearchDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = AdvanceSearchMenu();
                if (option == "1")
                {
                    searchByName();
                }
                else if (option == "2")
                {
                    searchByPrice();
                }
                else if (option == "3")
                {
                    searchByPriceRange();
                }
                else if (option == "4")
                {
                    searchByPriceDifference();
                }
                else if (option == "5")
                {
                    searchByCharactersInName();
                }
                else if (option == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option selected");
                }
            }
        }



        public string AdvanceSearchMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("       Advanced Search        ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Search by Name");
            Console.WriteLine("2. Search by Price");
            Console.WriteLine("3. Search by Price Range");
            Console.WriteLine("4. Search by Price Differernce");
            Console.WriteLine("5. Search by Characters in name");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Back");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            return option;
        }

        public void searchByName()
        {
            Console.WriteLine("Enter product name");
            string name = Console.ReadLine();
            ProductModel product = service.SearchByName(name);
            if (product != null)
            {
                Console.WriteLine(product.ToString());
            }
            else
            {
                Console.WriteLine("Product not found");
            }
            Console.ReadKey();
        }

        public void searchByPrice()
        {
            Console.WriteLine("Enter product price");
            float price = float.Parse(Console.ReadLine());
            List<ProductModel> products = service.SearchByPrice(price);
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
            if (products.Count == 0)
            {
                Console.WriteLine("No products found");
            }
            Console.ReadKey();
        }

        public void searchByPriceRange()
        {
            Console.WriteLine("Enter minimum price");
            float minPrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter maximum price");
            float maxPrice = float.Parse(Console.ReadLine());
            List<ProductModel> products = service.SearchByPriceRange(minPrice, maxPrice);
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
            if (products.Count == 0)
            {
                Console.WriteLine("No products found");
            }
            Console.ReadKey();
        }


        public void searchByPriceDifference()
        {
            Console.WriteLine("Enter price difference");
            float difference = float.Parse(Console.ReadLine());
            List<ProductModel> products = service.SearchByPriceDiff(difference);
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
            if (products.Count == 0)
            {
                Console.WriteLine("No products found");
            }
            Console.ReadKey();
        }

        public void searchByCharactersInName()
        {
            Console.WriteLine("Enter characters to search in product names");
            string chars = Console.ReadLine();
            List<ProductModel> products = service.SearchByNameChar(chars);
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
            if (products.Count == 0)
            {
                Console.WriteLine("No products found");
            }
            Console.ReadKey();
        }


        public void UpdateProduct()
        {
            Console.WriteLine("Enter product ID");
            int id = int.Parse(Console.ReadLine());
            
            ProductModel existingProduct = service.GetProduct(id);
            if(existingProduct == null)
            {
                Console.WriteLine("Product not found");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Enter new product details");
            ProductModel updatedProduct = TakeInput();
            updatedProduct.id = id;
            bool result = service.UpdateProduct(updatedProduct);
            if (result)
            {
                Console.WriteLine("Product updated successfully");
            }
            else
            {
                Console.WriteLine("Product not updated");
            }
            Console.ReadKey();
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Enter product ID");
            int id = int.Parse(Console.ReadLine());
            bool result = service.DeleteProduct(id);
            if (result)
            {
                Console.WriteLine("Product deleted successfully");
            }
            else
            {
                Console.WriteLine("Product not found");
            }
            Console.ReadKey();
        }

        public void DisplayAll()
        {
            foreach (var product in service.GetAllProducts())
            {
                Console.WriteLine(product.ToString());
            }
            Console.ReadKey();
        }

        public ProductModel TakeInput()
        {
            Console.WriteLine("Enter product name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product description");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter product purchase price");
            float pprice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter product sale price");
            float sprice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter product discount");
            float discount = float.Parse(Console.ReadLine());

            ProductModel product = new ProductModel(name, desc, pprice, sprice, discount);
            return product;

        }
        public string ProductMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("       Product Management      ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. View All");
            Console.WriteLine("5. Advanced Search");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Back");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            return option;
        }
    }
}
