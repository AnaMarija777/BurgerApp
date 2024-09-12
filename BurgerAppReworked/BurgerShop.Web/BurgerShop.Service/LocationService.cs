using BurgerShop.DataBase.Interfaces;
using BurgerShop.Domain;
using BurgerShop.Service.Interfaces;

namespace BurgerShop.Service
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _LocationRepo;

        public List<Location> ShowAllLocations()
        {
            return _LocationRepo.GetAll().ToList();
        }

        public void AddLocation(Location location)
        {
            var addedLocation = new Location()
            {
                Address = location.Address,
                Name = location.Name,
                Id = location.Id,
                ClosesAt = location.ClosesAt,
                OpensAt = location.OpensAt
            };

            _LocationRepo.Add(addedLocation);
        }

        public void EditLocation(Location location)
        {
            var edditedLocation = _LocationRepo.GetAll().FirstOrDefault(x => x.Id == location.Id);

            if (edditedLocation == null)
            {
                throw new Exception("No such location");
            }

            edditedLocation.Name = location.Name;
            edditedLocation.Address = location.Address;
            edditedLocation.OpensAt = location.OpensAt;
            edditedLocation.ClosesAt = location.ClosesAt;


            _LocationRepo.Update(edditedLocation);
        }

        public void DeleteLocation(Location location)
        {
            if (location == null || location.Id < 0)
            {
                throw new Exception("Invalid Location");
            }

            _LocationRepo.Delete(location.Id);
        }
    }
}
