namespace CatShelterManager.Models
{
    // Мінімальний контракт для всіх сутностей що зберігаються у репозиторії.
    // Cat і Location реалізують цей інтерфейс — репозиторій може порівнювати по Id
    // не знаючи конкретного типу.
    public interface IEntity
    {
        int Id { get; }
    }
}