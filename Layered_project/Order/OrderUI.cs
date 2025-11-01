using System;
using Layered_project.Customer;
using Layered_project.Product;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Order
{
    internal class OrderUI
    {
        OrderService order_service = new OrderService();
        CustomerService cust_service = new CustomerService();
        CustomerUI CustomerUI = new CustomerUI();
        ProductService Prod_service = new ProductService();


        public void OrderDriver()
        {
            Console.Clear();
            CreateNewOrder();
        }
        public bool CreateNewOrder()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        Create New Order       ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter customer name");
            string name = Console.ReadLine();
            CustomerModel customer = cust_service.SearchByName(name);
            if (customer == null)
            {
                Console.WriteLine($"Customer '{name}' not found.");
                Console.Write("Do you want to create a new customer? (y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    customer = CustomerUI.TakeInput();
                    cust_service.SaveCustomer(customer);
                    if (customer == null)
                    {
                        Console.WriteLine("! Error: Could not create new customer.");
                        return false;
                    }
                    Console.WriteLine($"Customer '{customer.GetName()}' created successfully.");
                }
                else
                {
                    Console.WriteLine("Order creation cancelled.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"\nCustomer '{customer.GetName()}' found. Starting order...");
            }

            Console.Write("Customer Details:\n\n" +
                          "Name: " + customer.GetName() + ", Phone Number: " + customer.GetPhone() + ", Age: " + customer.GetAge() + ", Address: " + customer.GetAddress() + "\n\n");
            OrderModel order = new OrderModel(customer.GetName(), customer.GetPhone(), customer.GetAddress());


            while (true)
            {
                Console.WriteLine("Enter product name");
                string Pname = Console.ReadLine();
                ProductModel product = Prod_service.SearchByName(Pname);
                if (product == null)
                {
                    Console.WriteLine($"Product '{Pname}' not found.");
                    Console.WriteLine("Do you want to add more product(y/n)");
                    if (Console.ReadLine().ToLower() == "n")
                    {
                        break;
                    }
                    continue;
                }
                Console.WriteLine("Enter product quantity");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem item = new OrderItem(product.GetName(), quantity, product.GetSalePrice());
                order.AddOrder(item);
                Console.WriteLine("Do you want to add more product(y/n)");
                if (Console.ReadLine().ToLower() == "n")
                {
                    break;
                }
            }
            order_service.SaveOrder(order);
            Console.WriteLine("Order created successfully.");
            return false;
        }
    }
}
