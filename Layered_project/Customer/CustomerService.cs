using Layered_project.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Customer
{
    internal class CustomerService
    {
        private CustomerRepo _repo;

        public CustomerService()
        {
            _repo = new CustomerRepo();
        }

        public void SaveCustomer(CustomerModel customer)
        {
            _repo.SaveInFile(customer);
        }

        public List<CustomerModel> GetAllData()
        {
            return _repo.GetAllCustomers();
        }

        public CustomerModel SearchByName(string name)
        {
            foreach (var customer in _repo.GetAllCustomers())
            {
                if (customer.name == name)
                {
                    return customer;
                }
            }
            return null;
        }


        public List<CustomerModel> SearchByFirstChar(string ch)
        {
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in _repo.GetAllCustomers())
            {
                if (customer.name.ToLower().StartsWith(ch.ToLower()))
                {
                    matchedCustomers.Add(customer);
                }
            }
            return matchedCustomers;
        }


        public CustomerModel SearchByPhone(string phone)
        {
            foreach (var customer in _repo.GetAllCustomers())
            {
                if (customer.phone == phone)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<CustomerModel> SearchByAddress(string address)
        {
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in _repo.GetAllCustomers())
            {
                if (customer.address.ToLower().StartsWith(address.ToLower()))
                {
                    matchedCustomers.Add(customer);
                }
            }
            return matchedCustomers;
        }


        public List<CustomerModel> SearchByAge(int age)
        {
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in _repo.GetAllCustomers())
            {
                if (customer.age == age)
                {
                    matchedCustomers.Add(customer);
                }
            }
            return matchedCustomers;
        }


        public bool UpdateCustomerPhone(string name, string phone)
        {
            List<CustomerModel> customers = _repo.GetAllCustomers();
            foreach (var customer in customers)
            {
                if (customer.name == name)
                {
                    customer.phone = phone;
                    _repo.SaveAllInFile(customers);
                    return true;

                }
            }
            return false;
        }

        public bool DelteCustomerByName(string name)
        {
            List<CustomerModel> customers = _repo.GetAllCustomers();
            int count = 0;
            foreach (var customer in customers)
            {
                if (customer.name == name)
                {
                    customers.RemoveAt(count);
                    _repo.SaveAllInFile(customers);
                    return true;
                }
                count++;
            }
            return false;
        }
    }
}
