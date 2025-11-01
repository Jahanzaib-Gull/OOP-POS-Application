using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Customer
{
    internal class CustomerModel
    {
        private string name;
        private string phone;
        private int age;
        private string address;

        public CustomerModel(string name, string phone, int age, string address )
        {
            this.name = name;
            this.phone = phone;
            this.age = age;
            this.address = address;
        }

        public override string ToString()
        {
            return $"{name},{age},{phone},{address}";
        }

        public string SetName(string name)
        {
            return this.name = name;
        }

        public String GetName()
        {
            return name;
        }
        public int GetAge()
        {
            return age;
        }

        public int SetAge(int age)
        {
            return this.age = age;
        }

        public string GetAddress()
        {
            return address;
        }

        public string SetAddress(String address)
        {
            return this.address = address;
        }

        public string GetPhone()
        {
            return phone;
        }
        
        public string SetPhone(String phone)
        {
            return this.phone = phone;
        }
    }
}
