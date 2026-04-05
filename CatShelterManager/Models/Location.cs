using System;
using System.Collections.Generic;
using CatShelterManager.Models;

namespace CatShelterManager.Models
{
    public class Location : IEntity
    {
        public int Id { get; private set; }
        public string Number { get; private set; }
        public string Description { get; private set; }

        private readonly List<Cat> _cats = new();
        public IReadOnlyList<Cat> Cats => _cats.AsReadOnly();

        public Location(int id, string number, string description)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Номер локації не може бути порожнім.", nameof(number));
            if (description == null)
                throw new ArgumentNullException(nameof(description));

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

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
        }

        internal void AddCat(Cat cat)
        {
            if (!_cats.Contains(cat)) _cats.Add(cat);
        }

        internal void RemoveCat(Cat cat) => _cats.Remove(cat);

        // Потрібно для коректного відображення у ComboBox і DataGridView
        public override string ToString() => Number;
    }
}