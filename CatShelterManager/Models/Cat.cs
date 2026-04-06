using System;
using System.Text.Json.Serialization;

namespace CatShelterManager.Models
{
    public class Cat : IEntity
    {
        public int Id { get; set; }
        public string Nickname { get; private set; }
        public int Age { get; private set; }
        public HealthStatus HealthStatus { get; private set; }
        public int LocationId { get; private set; }

        [JsonConstructor]
        public Cat(int id, string nickname, int age, HealthStatus healthStatus, int locationId)
        {
            Id = id;
            Nickname = nickname;
            Age = age;
            HealthStatus = healthStatus;
            LocationId = locationId;
        }

        public Cat(int id, string nickname, int age, HealthStatus status, Location location)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                throw new ArgumentException("Кличка не може бути порожньою.", nameof(nickname));
            if (age < 0)
                throw new ArgumentOutOfRangeException(nameof(age), "Вік не може бути від'ємним.");
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            Id = id;
            Nickname = nickname;
            Age = age;
            HealthStatus = status;
            LocationId = location.Id;
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

        public void UpdateLocation(int locationId)
        {
            LocationId = locationId;
        }
    }
}