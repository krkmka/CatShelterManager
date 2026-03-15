using System;
using System.Collections.Generic;

namespace CatShelterManager.Models
{
    public class Location
    {
        //Атрибути
        public int Id { get; private set; }
        public string Number { get; private set; }
        public string Description { get; private set; }

        private readonly List<Cat> _cats;

        //список лише для читання (запрівачено)
        public IReadOnlyList<Cat> Cats => _cats.AsReadOnly();

        //Конструктор
        public Location(int id, string number, string description)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Номер місця не може бути порожнім.", nameof(number));

            if (description == null)
                throw new ArgumentNullException(nameof(description), "Опис не може бути пустим.");

            Id = id;
            Number = number;
            Description = description;
            _cats = new List<Cat>();
        }

        //Методи (відповідно до UML)

        public void Rename(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Новий номер не може бути порожнім.", nameof(newTitle));

            Number = newTitle;
        }

        public void UpdateDescription(string newDescription)
        {
            if (newDescription == null)
                throw new ArgumentNullException(nameof(newDescription), "Опис не може бути порожнім.");

            Description = newDescription;
        }

        //Внутрішні методи для підтримки двонаправленого зв'язку
        internal void AddCat(Cat cat)
        {
            if (!_cats.Contains(cat))
                _cats.Add(cat);
        }

        internal void RemoveCat(Cat cat)
        {
            _cats.Remove(cat);
        }
    }
}
