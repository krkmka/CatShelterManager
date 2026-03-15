using System;

namespace CatShelterManager.Models
{
    public class Cat
    {
        public int Id { get; private set; }
        public string Nickname { get; private set; }
        public int Age { get; private set; }
        public HealthStatus HealthStatus { get; private set; }
        public Location CurrentLocation { get; private set; }

        //Конструктор
        public Cat(int id, string nickname, int age, HealthStatus status, Location location)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                throw new ArgumentException("Кличка не може бути порожньою.", nameof(nickname));

            if (age < 0)
                throw new ArgumentOutOfRangeException(nameof(age), "Вік не може бути від'ємним.");

            if (location == null)
                throw new ArgumentNullException(nameof(location), "Кіт повинен бути прив'язаний до місця утримання.");

            Id = id;
            Nickname = nickname;
            Age = age;
            HealthStatus = status;

            AssignLocation(location);
        }

        //Методи (відповідно до UML)

        public void UpdateCatDetails(string newNickname, int newAge, HealthStatus newStatus)
        {
            if (string.IsNullOrWhiteSpace(newNickname))
                throw new ArgumentException("Кличка не може бути порожньою.", nameof(newNickname));

            if (newAge < 0)
                throw new ArgumentOutOfRangeException(nameof(newAge), "Вік не може бути від'ємним.");

            Nickname = newNickname;
            Age = newAge;
            HealthStatus = newStatus;
        }

        public void UpdateAge(int newAge)
        {
            if (newAge < 0)
                throw new ArgumentOutOfRangeException(nameof(newAge), "Вік не може бути від'ємним.");

            Age = newAge;
        }

        public void UpdateHealthStatus(HealthStatus newStatus)
        {
            HealthStatus = newStatus;
        }

        public void AssignLocation(Location newLocation)
        {
            if (newLocation == null)
                throw new ArgumentNullException(nameof(newLocation), "Нове місце не може бути порожнім.");

            CurrentLocation?.RemoveCat(this);

            CurrentLocation = newLocation;
            CurrentLocation.AddCat(this);
        }
    }
}
