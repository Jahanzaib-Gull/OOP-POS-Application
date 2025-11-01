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
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int age { get; set; }
        public string address { get; set; }

        public CustomerModel(int id, string name, string phone, int age, string address)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.age = age;
            this.address = address;
        }

        public CustomerModel(string name, string phone, int age, string address)
        {
            this.name = name;
            this.phone = phone;
            this.age = age;
            this.address = address;
        }

        public override string ToString()
        {
            return $"Id: {id}, Name: {name}, Phone: {phone}, Age: {age}, Address: {address}";
        }
    }
}
