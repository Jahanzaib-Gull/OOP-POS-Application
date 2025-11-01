using Layered_project.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Customer
{
    internal class CustomerRepo
    {
        private readonly string file = "customer.txt";

        public CustomerRepo()
        {

        }

        public void SaveInFile(CustomerModel customer)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(customer.ToString());
            }
        }

        public void SaveAllInFile(List<CustomerModel> customers)
        {
            File.WriteAllText(file, string.Empty);
            foreach (var customer in customers)
            {
                SaveInFile(customer);
            }
        }

        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customersList = new List<CustomerModel>();
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string phone = parts[2];
                    string address = parts[3];

                    CustomerModel customer = new CustomerModel(name, phone, age, address);
                    customersList.Add(customer);
                }
            }
            return customersList;
        }
    }
}
