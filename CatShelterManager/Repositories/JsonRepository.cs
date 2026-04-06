using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using CatShelterManager.Models;

namespace CatShelterManager.Repositories
{
    public class JsonRepository<T> : IRepository<T> where T : IEntity
    {
        private List<T> _items;
        private readonly string _filePath;
        private int _nextId = 1;

        private static readonly JsonSerializerOptions _opts = new() { WriteIndented = true };

        public JsonRepository(string filePath)
        {
            _filePath = filePath;
            _items = LoadData();
            if (_items.Any())
                _nextId = _items.Max(x => x.Id) + 1;
        }

        private List<T> LoadData()
        {
            if (!File.Exists(_filePath)) return new();
            string json = File.ReadAllText(_filePath);
            return string.IsNullOrWhiteSpace(json)
                ? new()
                : JsonSerializer.Deserialize<List<T>>(json, _opts) ?? new();
        }

        private void SaveData() =>
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_items, _opts));

        public void Add(T item)
        {
            if (item.Id == 0) item.Id = _nextId++;
            _items.Add(item);
            SaveData();
        }

        public void Remove(int id)
        {
            var item = GetById(id);
            if (item == null) return;
            _items.Remove(item);
            SaveData();
        }

        public void Update(T item)
        {
            var existing = GetById(item.Id);
            if (existing == null) return;
            _items[_items.IndexOf(existing)] = item;
            SaveData();
        }

        public T? GetById(int id) =>
            _items.FirstOrDefault(x => x.Id == id);

        public IReadOnlyList<T> GetAll() =>
            _items.AsReadOnly();

        public List<T> Find(Func<T, bool> predicate) =>
            _items.Where(predicate).ToList();
    }
}