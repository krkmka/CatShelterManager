using System.Linq;
using System.Windows.Forms;
using CatShelterManager.Models;
using CatShelterManager.Repositories;

namespace CatShelterManager
{
    public partial class FormMain : Form
    {
        private readonly IRepository<Location> _locationRepo;
        private readonly IRepository<Cat> _catRepo;

        public FormMain()
        {
            InitializeComponent();

            _locationRepo = new JsonRepository<Location>("locations.json");
            _catRepo = new JsonRepository<Cat>("cats.json");

            if (!_locationRepo.GetAll().Any()) SeedData();
        }

        private void SeedData()
        {
            var loc1 = new Location(0, "A-01", "Приймальня");
            var loc2 = new Location(0, "B-02", "Ізолятор");
            var loc3 = new Location(0, "C-03", "Загальний зал");
            _locationRepo.Add(loc1);
            _locationRepo.Add(loc2);
            _locationRepo.Add(loc3);

            _catRepo.Add(new Cat(0, "Барсик", 3, HealthStatus.Healthy, loc1));
            _catRepo.Add(new Cat(0, "Мурка", 1, HealthStatus.NeedsCheckup, loc2));
            _catRepo.Add(new Cat(0, "Тигр", 5, HealthStatus.InTreatment, loc1));
        }

        private void btnCats_Click(object sender, EventArgs e) =>
            new FormCats(_catRepo, _locationRepo).ShowDialog();

        private void btnLocations_Click(object sender, EventArgs e) =>
            new FormLocations(_locationRepo, _catRepo).ShowDialog();
    }
}