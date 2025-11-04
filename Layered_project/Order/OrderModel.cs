using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Order
{
    internal class OrderModel
    {
        public string customername { get; set; }
        public int orderid { get; set; }
        public string contact {  get; set; }
        public string address { get; set; }


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
