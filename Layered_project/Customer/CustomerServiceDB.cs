using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
