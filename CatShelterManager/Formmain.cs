using System.Windows.Forms;
using CatShelterManager.Models;
using CatShelterManager.Repositories;

namespace CatShelterManager
{
    public partial class FormMain : Form
    {
        // Один репозиторій на тип — створюються тут один раз,
        // передаються у дочірні форми щоб всі працювали з тими самими даними.
        // Коли з'явиться JsonRepository<T> — просто замінити new Repository<T>()
        // на new JsonRepository<T>("path") — інтерфейс не зміниться.
        private readonly IRepository<Cat> _catRepo = new Repository<Cat>();
        private readonly IRepository<Location> _locationRepo = new Repository<Location>();

        public FormMain()
        {
            InitializeComponent();
            SeedData();
        }

        private void SeedData()
        {
            var loc1 = new Location(1, "A-01", "Приймальня");
            var loc2 = new Location(2, "B-02", "Ізолятор");
            var loc3 = new Location(3, "C-03", "Загальний зал");
            _locationRepo.Add(loc1);
            _locationRepo.Add(loc2);
            _locationRepo.Add(loc3);

            _catRepo.Add(new Cat(1, "Барсик", 3, HealthStatus.Healthy, loc1));
            _catRepo.Add(new Cat(2, "Мурка", 1, HealthStatus.NeedsCheckup, loc2));
            _catRepo.Add(new Cat(3, "Тигр", 5, HealthStatus.InTreatment, loc1));
        }

        private void btnCats_Click(object sender, EventArgs e)
        {
            new FormCats(_catRepo, _locationRepo).ShowDialog();
        }

        private void btnLocations_Click(object sender, EventArgs e)
        {
            new FormLocations(_locationRepo, _catRepo).ShowDialog();
        }
    }
}