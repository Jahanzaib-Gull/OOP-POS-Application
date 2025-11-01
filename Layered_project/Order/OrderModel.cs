using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Order
{
    internal class OrderModel
    {
        public string customername;
        public string contact;
        public string address;
        public List<OrderItem> ordersList = new List<OrderItem>();

        public OrderModel(string customername,string contact,string address)
        {
            this.customername = customername;
            this.contact = contact;
            this.address = address;
        }

        public void AddOrder(OrderItem item)
        {
            ordersList.Add(item);
        }
    }
}
