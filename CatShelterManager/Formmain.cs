using CatShelterManager.Models;
using CatShelterManager.Repositories;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace CatShelterManager
{
    public partial class FormMain : Form
    {
        // -------------------------------------------------------
        // Репозиторії створюються ТІЛЬКИ тут — один раз для всього
        // застосунку. Дочірні форми отримують їх через конструктор.
        // -------------------------------------------------------
        private readonly CatRepository _catRepo = new();
        private readonly LocationRepository _locationRepo = new();

        public FormMain()
        {
            InitializeComponent();
            SeedData();
        }

        // Тестові дані щоб форма не була порожньою при запуску
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

        // Відкрити форму керування котами
        private void btnCats_Click(object sender, EventArgs e)
        {
            // Передаємо обидва репозиторії — коти залежать від локацій
            var form = new FormCats(_catRepo, _locationRepo);
            form.ShowDialog(); // ShowDialog = блокує FormMain поки відкрита дочірня
        }

        // Відкрити форму керування локаціями
        private void btnLocations_Click(object sender, EventArgs e)
        {
            var form = new FormLocations(_locationRepo, _catRepo);
            form.ShowDialog();
        }
    }
}