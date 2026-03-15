using System;
using System.Collections.Generic;
using System.Linq;
using CatShelterManager.Models;

namespace CatShelterManager.Repositories
{
    public class CatRepository : IRepository<Cat>
    {
        private readonly List<Cat> _cats = new();

        public void Add(Cat cat)
        {
            if (cat == null)
                throw new ArgumentNullException(nameof(cat));

            if (_cats.Any(c => c.Id == cat.Id))
                throw new ArgumentException($"Кіт з Id={cat.Id} вже існує.", nameof(cat));

            _cats.Add(cat);
        }

        public void Remove(int id)
        {
            var cat = GetById(id)
                ?? throw new ArgumentException($"Кота з Id={id} не знайдено.", nameof(id));

            _cats.Remove(cat);
        }

        public Cat? GetById(int id) =>
            _cats.FirstOrDefault(c => c.Id == id);

        public IReadOnlyList<Cat> GetAll() =>
            _cats.AsReadOnly();

        public IReadOnlyList<Cat> GetByHealthStatus(HealthStatus status) =>
            _cats.Where(c => c.HealthStatus == status).ToList().AsReadOnly();

        public IReadOnlyList<Cat> GetByLocation(int locationId) =>
            _cats.Where(c => c.CurrentLocation.Id == locationId).ToList().AsReadOnly();
    }
}