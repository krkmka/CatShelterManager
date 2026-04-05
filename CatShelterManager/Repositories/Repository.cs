using System;
using System.Collections.Generic;
using System.Linq;
using CatShelterManager.Models;

namespace CatShelterManager.Repositories
{
    // Один універсальний репозиторій для будь-якого типу що має Id.
    // В майбутньому можна замінити на JsonRepository<T> — достатньо
    // реалізувати той самий IRepository<T>.
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _items = new();

        public void Add(T item)
        {
            if (_items.Any(i => i.Id == item.Id))
                throw new ArgumentException($"Елемент з Id={item.Id} вже існує.");
            _items.Add(item);
        }

        public void Remove(int id)
        {
            var item = GetById(id)
                ?? throw new ArgumentException($"Елемент з Id={id} не знайдено.");
            _items.Remove(item);
        }

        public void Update(T item)
        {
            var existing = GetById(item.Id);
            if (existing != null)
            {
                int index = _items.IndexOf(existing);
                _items[index] = item;
            }
        }

        public T? GetById(int id) =>
            _items.FirstOrDefault(i => i.Id == id);

        public IReadOnlyList<T> GetAll() =>
            _items.AsReadOnly();

        public List<T> Find(Func<T, bool> predicate) =>
            _items.Where(predicate).ToList();
    }
}