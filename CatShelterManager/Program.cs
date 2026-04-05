namespace CatShelterManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // Запускаємо FormMain — головну форму навігації
            Application.Run(new FormMain());
        }
    }
}