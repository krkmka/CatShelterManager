using System;
using System.Collections.Generic;

namespace CatShelterManager.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T? GetById(int id);
        IReadOnlyList<T> GetAll();
        List<T> Find(Func<T, bool> predicate);
    }
}