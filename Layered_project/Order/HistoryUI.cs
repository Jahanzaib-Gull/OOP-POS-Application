using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Order
{
    internal class HistoryUI
    {
        OrderService order_service = new OrderService();

        public void HistoryDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = HistoryMenu();
                if (option == "1")
                {
                    DisplayAll();
                }
                else if (option == "2")
                {
                    HistoryByName();
                }
                else if (option == "3") 
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("Wrong option selected");
                }
            }
        }

        public void DisplayAll()
        {
            foreach(var order in order_service.GetAllOrders())
            {
                Console.WriteLine($"Customer: {order.customername},{order.contact},{order.address}");
                foreach(var item in order.ordersList)
                {
                    Console.WriteLine($"Item: {item.product},{item.quantity},{item.saleprice}");
                }
            }
            Console.ReadKey();
        }

        public void HistoryByName()
        {
            Console.WriteLine("Enter customer name");
            string name = Console.ReadLine();
            foreach (var n in order_service.GetAllOrders())
            {
                if(n.customername == name)
                {
                    foreach (var item in n.ordersList)
                    {
                        Console.WriteLine($"Item: {item.product},{item.quantity},{item.saleprice}");
                    }
                }
            }
            Console.ReadKey();
        }
        public string HistoryMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("       History Management      ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. View all orders");
            Console.WriteLine("2. View order by customer name");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Back");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            return option;
        }
    }
}
