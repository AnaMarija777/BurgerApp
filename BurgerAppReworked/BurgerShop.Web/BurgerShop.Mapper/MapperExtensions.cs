using BurgerShop.Domain;
using BurgerShop.Dtos;

namespace BurgerShop.Mapper
{
    public static class MapperExtensions
    {
        public static OrderDto Map(this Order order)
        {
            return new OrderDto { Address = order.Address, Burgers = order.Burgers, FullName = order.FullName, IsDelivered = order.IsDelivered, Location = order.Location };
        }

        public static BurgerDto Map(this Burger burger)
        {
            return new BurgerDto { Name = burger.Name, OrderId = burger.OrderId, Price = burger.Price, IsVegetarian = burger.IsVegetarian, HasFries = burger.HasFries, IsVegan = burger.IsVegan };
        }
    }
}
