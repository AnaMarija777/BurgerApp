using BurgerShop.Domain;

namespace BurgerShop.Service.Interfaces
{
    public interface IOrderService
    {
        List<Order> ShowAllOrders(Order order);

        void AddOrder(Order order);

        void EditOrder(Order order);

        void DeleteOrder(Order order);
    }
}
