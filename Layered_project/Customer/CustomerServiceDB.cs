using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Layered_project.Customer
{
    internal class CustomerServiceDB
    {
        private CustomerRepoDB _repo;

        public CustomerServiceDB()
        {
            _repo = new CustomerRepoDB();
        }

        public bool SaveCustomer(CustomerModel customer)
        {
            return _repo.Create(customer);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _repo.GetAll();
        }

        public bool DelteCustomerByID(int id)
        {
            return _repo.Delete(id);
        }

        public bool UpdateCUstomer(CustomerModel customer)
        {
            return _repo.Update(customer);
        }

        public CustomerModel GetCustomer(int id)
        {
            return _repo.GetById(id);
        }

        public List<CustomerModel> SearchByName(string name)
        {
            List<CustomerModel> customers = _repo.GetAll();
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                if (customer.name.ToLower() == name.ToLower())
                {
                    matchedCustomers.Add(customer);
                }
            }
            return matchedCustomers;
        }

        public CustomerModel SearchByPhone(string phone)
        {
            List<CustomerModel> customers = _repo.GetAll();
            foreach (var customer in customers)
            {
                if (customer.phone == phone)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<CustomerModel> SearchByFirstChar(string ch)
        {
            List<CustomerModel> customers = _repo.GetAll();
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                if (customer.name.ToLower().StartsWith(ch.ToLower()))
                {
                    matchedCustomers.Add(customer);
                }
            }
            return matchedCustomers;
        }

        public List<CustomerModel> SearchByAddress(string address)
        {
            List<CustomerModel> customers = _repo.GetAll();
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                if(customer.address.ToLower() == address.ToLower())
                {
                    matchedCustomers.Add(customer);
                }
            }
            return matchedCustomers;
        }

        public List<CustomerModel> SearchByAge(int age)
        {
            List<CustomerModel> customers = _repo.GetAll();
            List<CustomerModel> matchedCustomers = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                if (customer.age == age)
                {
                    matchedCustomers.Add(customer);
                }
            }
            return matchedCustomers;
        }
    }
}
