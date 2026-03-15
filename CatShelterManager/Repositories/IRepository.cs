using System.Collections.Generic;

namespace CatShelterManager.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(int id);
        T? GetById(int id);
        IReadOnlyList<T> GetAll();
    }
}
