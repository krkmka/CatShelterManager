using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CatShelterManager.Models
{
    public class Cat : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Кличка не може бути порожньою.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Кличка: від 1 до 50 символів.")]
        public string Nickname { get; private set; }
        [Range(0, 30, ErrorMessage = "Вік кота: від 0 до 30 років.")]
        public int Age { get; private set; }
        public HealthStatus HealthStatus { get; private set; }
        [Required(ErrorMessage = "Кіт має десь перебувати.")]
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