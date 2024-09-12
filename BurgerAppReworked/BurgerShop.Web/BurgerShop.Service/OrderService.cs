using BurgerShop.DataBase.Interfaces;
using BurgerShop.Domain;
using BurgerShop.Service.Interfaces;

namespace BurgerShop.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepo;

        public List<Order> ShowAllOrders(Order order)
        {
            return _orderRepo.GetAll().ToList();
        }

        public void AddOrder(Order order)
        {
            var addedOrder = new Order()
            {
                FullName = order.FullName,
                Address = order.Address,
                Location = order.Location,
                Burgers = order.Burgers,
                IsDelivered = order.IsDelivered
            };

            _orderRepo.Add(addedOrder);
        }

        public void EditOrder(Order order)
        {
            var edditedOrder = _orderRepo.GetAll().FirstOrDefault(x => x.Id == order.Id);

            if (edditedOrder == null)
            {
                throw new Exception("No such order");
            }

            edditedOrder.FullName = order.FullName;
            edditedOrder.Location = order.Location;
            edditedOrder.Address = order.Address;
            edditedOrder.Burgers = order.Burgers;
            edditedOrder.IsDelivered = order.IsDelivered;
        }

        public void DeleteOrder(Order order)
        {
            if (order == null || order.Id < 0)
            {
                throw new Exception("Invalid order");
            }

            _orderRepo.Delete(order.Id);
        }
    }
}
