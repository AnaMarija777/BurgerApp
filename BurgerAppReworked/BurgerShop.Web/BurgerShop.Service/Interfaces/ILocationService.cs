using BurgerShop.Domain;

namespace BurgerShop.Service.Interfaces
{
    public interface ILocationService
    {
        List<Location> ShowAllLocations();

        void AddLocation(Location location);

        void EditLocation(Location location);

        void DeleteLocation(Location location);
    }
}
