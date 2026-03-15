using System;
using System.Collections.Generic;
using System.Linq;
using CatShelterManager.Models;

namespace CatShelterManager.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly List<Location> _locations = new();

        public void Add(Location location)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            if (_locations.Any(l => l.Id == location.Id))
                throw new ArgumentException($"Локація з Id={location.Id} вже існує.", nameof(location));

            _locations.Add(location);
        }

        public void Remove(int id)
        {
            var location = GetById(id)
                ?? throw new ArgumentException($"Локацію з Id={id} не знайдено.", nameof(id));

            _locations.Remove(location);
        }

        public Location? GetById(int id) =>
            _locations.FirstOrDefault(l => l.Id == id);

        public IReadOnlyList<Location> GetAll() =>
            _locations.AsReadOnly();
    }
}