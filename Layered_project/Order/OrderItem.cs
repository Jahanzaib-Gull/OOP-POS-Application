using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Order
{
    internal class OrderItem
    {
        public string product;
        public int quantity;
        public float saleprice;

        public OrderItem(string product, int quantity,float saleprice)
        {
            this.product = product;
            this.quantity = quantity;
            this.saleprice = saleprice;
        }
    }
}
