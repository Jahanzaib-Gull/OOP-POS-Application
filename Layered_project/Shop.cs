using Layered_project.Product;
using Layered_project.Customer;
using Layered_project.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project
{
    internal class Shop
    {
        public void start()
        {
            while (true)
            {
                Console.Clear();
                string option = MainMenu();
                if (option == "1")
                {
                    ProductUI productUI = new ProductUI();
                    productUI.PoductDriver();
                }
                else if (option == "2")
                {
                    CustomerUI customerUI = new CustomerUI();
                    customerUI.CustomerDriver();
                }
                else if(option == "3")
                {
                    OrderUI orderUI = new OrderUI();
                    orderUI.CreateNewOrder();
                }
                else if(option == "4")
                {
                    HistoryUI historyUI = new HistoryUI();
                    historyUI.HistoryDriver();
                }
                else if (option == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option selected");
                }

            }
        }

        public string MainMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("         Shop Management       ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Product Management");
            Console.WriteLine("2. Customer Management");
            Console.WriteLine("3. Create a new order");
            Console.WriteLine("4. View order history");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Back");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            return option;
        }
     
    }
}
