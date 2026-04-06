using System;
using System.Text.Json.Serialization;

namespace CatShelterManager.Models
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public string Number { get; private set; }
        public string Description { get; private set; }

        [JsonConstructor]
        public Location(int id, string number, string description)
        {
            Id = id;
            Number = number;
            Description = description;
        }

        public void Rename(string newNumber)
        {
            if (string.IsNullOrWhiteSpace(newNumber))
                throw new ArgumentException("Номер не може бути порожнім.", nameof(newNumber));
            Number = newNumber;
        }

        public void UpdateDescription(string newDescription) =>
            Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));

        public override string ToString() => Number;
    }
}