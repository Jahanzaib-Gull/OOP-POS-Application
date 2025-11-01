using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Order
{
    internal class OrderService
    {
        private OrderRepo _repo;
        public OrderService()
        {
            _repo = new OrderRepo();
        }

        public void SaveOrder(OrderModel order)
        {
            _repo.Save(order);
        }

        public List<OrderModel> GetAllOrders()
        {
            return _repo.getAllOrders();
        }

    }
}
