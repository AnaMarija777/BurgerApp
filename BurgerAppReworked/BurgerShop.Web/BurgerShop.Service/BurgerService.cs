using BurgerShop.DataBase;
using BurgerShop.DataBase.Interfaces;
using BurgerShop.Domain;
using BurgerShop.Service.Interfaces;

namespace BurgerShop.Service
{
    public class BurgerService : IBurgerService
    {
        private readonly IRepository<Burger> _burgerRepo;

        public List<Burger> ShowAllBurgers(Burger burger)
        {
            return _burgerRepo.GetAll().ToList();
        }

        public void AddBurger(Burger burger)
        {
            var addedBurger = new Burger()
            {
                Id = burger.Id,
                Name = burger.Name,
                HasFries = burger.HasFries,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                OrderId = burger.OrderId,
                Price = burger.Price
            };

            _burgerRepo.Add(addedBurger);

        }

        public void EditBurger(Burger burger)
        {
            var editedBurger = _burgerRepo.GetAll().FirstOrDefault(x => x.Id == burger.Id);

            if (burger == null)
            {
                throw new Exception("No such burger");
            }

            editedBurger.Name = burger.Name;
            editedBurger.Price = burger.Price;
            editedBurger.HasFries = burger.HasFries;
            editedBurger.IsVegetarian = !burger.IsVegetarian;
            editedBurger.IsVegan = burger.IsVegan;

            _burgerRepo.Update(editedBurger);
        }

        public void DeleteBurger(Burger burger)
        {
            if (burger == null || burger.Id < 0)
            {
                throw new ArgumentException("Invalid burger object");
            }

            _burgerRepo.Delete(burger.Id);
        }
    }
}
