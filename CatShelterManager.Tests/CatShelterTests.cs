using System;
using Xunit;
using CatShelterManager.Models;

namespace CatShelterManager.Tests
{
    // =====================================================================
    // Тести для класу Cat
    // =====================================================================
    public class CatTests
    {
        private readonly Location _location;

        // В xUnit замість [TestInitialize] використовується конструктор класу.
        // Він автоматично викликається перед КОЖНИМ окремим тестом.
        public CatTests()
        {
            _location = new Location(1, "101", "Приймальня");
        }

        [Fact]
        public void Constructor_ValidData_CreatesCatWithCorrectProperties()
        {
            // Arrange
            string expectedNickname = "Барсик";
            int expectedAge = 3;
            var expectedStatus = HealthStatus.Healthy;
            int expectedLocationId = 1;

            // Act
            var cat = new Cat(1, expectedNickname, expectedAge, expectedStatus, _location);

            // Assert
            Assert.Equal(1, cat.Id);
            Assert.Equal(expectedNickname, cat.Nickname);
            Assert.Equal(expectedAge, cat.Age);
            Assert.Equal(expectedStatus, cat.HealthStatus);
            Assert.Equal(expectedLocationId, cat.LocationId);
        }

        [Fact]
        public void UpdateCatDetails_ValidData_UpdatesAllProperties()
        {
            // Arrange
            var cat = new Cat(1, "Барсик", 3, HealthStatus.Healthy, _location);

            // Act
            cat.UpdateCatDetails("Мурка", 5, HealthStatus.InTreatment);

            // Assert
            Assert.Equal("Мурка", cat.Nickname);
            Assert.Equal(5, cat.Age);
            Assert.Equal(HealthStatus.InTreatment, cat.HealthStatus);
        }

        [Fact]
        public void UpdateLocation_NewId_UpdatesLocationId()
        {
            // Arrange
            var cat = new Cat(1, "Барсик", 3, HealthStatus.Healthy, _location);

            // Act
            cat.UpdateLocation(42);

            // Assert
            Assert.Equal(42, cat.LocationId);
        }
    }

    // =====================================================================
    // Тести для класу Location
    // =====================================================================
    public class LocationTests
    {
        [Fact]
        public void Constructor_ValidData_CreatesLocationWithCorrectProperties()
        {
            // Arrange + Act
            var loc = new Location(1, "101", "Приймальня");

            // Assert
            Assert.Equal(1, loc.Id);
            Assert.Equal("101", loc.Number);
            Assert.Equal("Приймальня", loc.Description);
        }

        [Fact]
        public void Rename_ValidNumber_UpdatesNumber()
        {
            // Arrange
            var loc = new Location(1, "101", "Приймальня");

            // Act
            loc.Rename("202");

            // Assert
            Assert.Equal("202", loc.Number);
        }

        [Fact]
        public void UpdateDescription_ValidText_UpdatesDescription()
        {
            // Arrange
            var loc = new Location(1, "101", "Старий опис");

            // Act
            loc.UpdateDescription("Новий опис");

            // Assert
            Assert.Equal("Новий опис", loc.Description);
        }
    }

    // =====================================================================
    // Тести для ValidationHelper
    // =====================================================================
    public class ValidationHelperTests
    {
        private readonly Location _location;

        public ValidationHelperTests()
        {
            _location = new Location(1, "101", "Приймальня");
        }

        [Fact]
        public void TryValidate_ValidCat_ReturnsTrueAndEmptyError()
        {
            // Arrange
            var cat = new Cat(1, "Барсик", 3, HealthStatus.Healthy, _location);

            // Act
            bool result = ValidationHelper.TryValidate(cat, out string error);

            // Assert
            Assert.True(result);
            Assert.Equal(string.Empty, error);
        }

        [Fact]
        public void TryValidate_EmptyCatNickname_ReturnsFalse()
        {
            // Arrange
            var cat = new Cat(1, "", 3, HealthStatus.Healthy, _location);

            // Act
            bool result = ValidationHelper.TryValidate(cat, out string error);

            // Assert
            Assert.False(result);
            Assert.NotEqual(string.Empty, error); // Перевіряємо, що текст помилки не порожній
        }

        [Fact]
        public void TryValidate_NegativeCatAge_ReturnsFalse()
        {
            // Arrange
            var cat = new Cat(1, "Барсик", -5, HealthStatus.Healthy, _location);

            // Act
            bool result = ValidationHelper.TryValidate(cat, out string error);

            // Assert
            Assert.False(result);
            Assert.NotEqual(string.Empty, error);
        }

        [Fact]
        public void TryValidate_ValidLocation_ReturnsTrue()
        {
            // Arrange
            var loc = new Location(1, "101", "Приймальня");

            // Act
            bool result = ValidationHelper.TryValidate(loc, out string error);

            // Assert
            Assert.True(result);
            Assert.Equal(string.Empty, error);
        }

        [Fact]
        public void TryValidate_LocationEmptyNumber_ReturnsFalse()
        {
            // Arrange
            var loc = new Location(1, "", "Опис");

            // Act
            bool result = ValidationHelper.TryValidate(loc, out string error);

            // Assert
            Assert.False(result);
            Assert.NotEqual(string.Empty, error);
        }
    }
}