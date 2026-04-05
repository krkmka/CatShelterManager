using System;
using CatShelterManager.Models;

namespace CatShelterManager.Models
{
    public class Cat : IEntity
    {
        public int Id { get; private set; }
        public string Nickname { get; private set; }
        public int Age { get; private set; }
        public HealthStatus HealthStatus { get; private set; }
        public Location CurrentLocation { get; private set; }

        public Cat(int id, string nickname, int age, HealthStatus status, Location location)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                throw new ArgumentException("Кличка не може бути порожньою.", nameof(nickname));
            if (age < 0)
                throw new ArgumentOutOfRangeException(nameof(age), "Вік не може бути від'ємним.");
            if (location == null)
                throw new ArgumentNullException(nameof(location), "Кіт повинен мати локацію.");

            Id = id;
            Nickname = nickname;
            Age = age;
            HealthStatus = status;

            AssignLocation(location);
        }

        public void UpdateCatDetails(string nickname, int age, HealthStatus status)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                throw new ArgumentException("Кличка не може бути порожньою.", nameof(nickname));
            if (age < 0)
                throw new ArgumentOutOfRangeException(nameof(age), "Вік не може бути від'ємним.");

            Nickname = nickname;
            Age = age;
            HealthStatus = status;
        }

        public void AssignLocation(Location newLocation)
        {
            if (newLocation == null)
                throw new ArgumentNullException(nameof(newLocation));

            CurrentLocation?.RemoveCat(this);
            CurrentLocation = newLocation;
            CurrentLocation.AddCat(this);
        }
    }
}