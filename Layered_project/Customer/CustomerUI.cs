using Layered_project.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Customer
{
    internal class CustomerUI
    {

        CustomerService service = new CustomerService();


        public void CustomerDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = CustomerMenu();
                if (option == "1")
                {
                    CustomerModel customer = TakeInput();
                    service.SaveCustomer(customer);
                }
                else if (option == "2")
                {
                    UpdateCustomer();
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
                string option = advancedSearchMenu();
                if (option == "1")
                {
                    SearchByName();
                }
                else if (option == "2")
                {
                    SearchByPhone();
                }
                else if (option == "3")
                {
                    SearchByFirstCharacterInName();
                }
                else if (option == "4")
                {
                    SearchByAddress();
                }
                else if (option == "5")
                {
                    SearchByAge();
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

        public string advancedSearchMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("      Advanced Search Menu     ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Search by Name");
            Console.WriteLine("2. Search by Phone");
            Console.WriteLine("3. Search by First Character in Name");
            Console.WriteLine("4. Search by Address");
            Console.WriteLine("5. Search by age");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Back");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            return option;
        }

        public void SearchByName()
        {
            Console.WriteLine("Enter customer name");
            string name = Console.ReadLine();
            CustomerModel customer = service.SearchByName(name);
            if (customer != null)
            {
                Console.WriteLine(customer.ToString());
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
            Console.ReadKey();
        }

        public void SearchByPhone()
        {
            Console.WriteLine("Enter customer phone");
            string phone = Console.ReadLine();
            CustomerModel customer = service.SearchByPhone(phone);
            if (customer != null)
            {
                Console.WriteLine(customer.ToString());
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
            Console.ReadKey();
        }

        public void SearchByFirstCharacterInName()
        {
            Console.WriteLine("Enter first characters of customer name");
            string ch = Console.ReadLine();
            List<CustomerModel> customers = service.SearchByFirstChar(ch);
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found");
            }
            Console.ReadKey();
        }

        public void SearchByAddress()
        {
            Console.WriteLine("Enter customer address");
            string address = Console.ReadLine();
            List<CustomerModel> customers = service.SearchByAddress(address);
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found");
            }
            Console.ReadKey();
        }
        public void SearchByAge()
        {
            Console.WriteLine("Enter customer age");
            int age = int.Parse(Console.ReadLine());
            List<CustomerModel> customers = service.SearchByAge(age);
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found");
            }
            Console.ReadKey();
        }
        public void UpdateCustomer()
        {
            Console.WriteLine("Enter product name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product price");
            string phone = Console.ReadLine();

            bool result = service.UpdateCustomerPhone(name, phone);
            if (result)
            {
                Console.WriteLine("Customer updated successfully");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Enter product name");
            string name = Console.ReadLine();

            bool result = service.DelteCustomerByName(name);
            if (result)
            {
                Console.WriteLine("Customer deleted successfully");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
            Console.ReadKey();
        }

        public void DisplayAll()
        {
            foreach (var customer in service.GetAllData())
            {
                Console.WriteLine(customer.ToString());
            }
            Console.ReadKey();
        }

        public CustomerModel TakeInput()
        {
            Console.WriteLine("Enter customer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter customer age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter customer phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter customer address");
            string address = Console.ReadLine();

            CustomerModel customer = new CustomerModel(name, phone, age, address);
            return customer;
        }

        public string CustomerMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("      Customer Management      ");
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
