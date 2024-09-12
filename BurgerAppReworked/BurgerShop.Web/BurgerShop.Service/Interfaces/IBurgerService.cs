using BurgerShop.Domain;

namespace BurgerShop.Service.Interfaces
{
    public interface IBurgerService
    {
        List<Burger> ShowAllBurgers(Burger burger);

        void EditBurger(Burger burger);

        void AddBurger(Burger burger);

        void DeleteBurger(Burger burger);
    }
}
