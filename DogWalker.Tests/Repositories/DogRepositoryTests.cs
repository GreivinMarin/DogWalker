using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Dapper;
using System.Data.SQLite;
using DogWalker.Core.Entities;
using DogWalker.Infrastructure.Data;
using DogWalker.Infrastructure.Repositories;

namespace DogWalker.Tests.Repositories
{
    public class DogRepositoryTests : IDisposable
    {
        private readonly SQLiteConnection _connection;
        private readonly DatabaseContext _context;
        private readonly DogRepository _repository;

        /********************************************************************************************************************************
         
        This Test validate the functionality of the SQL Scripts taking an instance of the DogRepository, creates a database in memory
        with few test records and finally executing each of the methods of the DogRepository to validate it is working as expected

        *********************************************************************************************************************************/


        public DogRepositoryTests()
        {
            // Create a connection on Memory
            _connection = new SQLiteConnection("Data Source=:memory:");
            _connection.Open();

            // Crear estructura de tabla
            _connection.Execute(@"
                CREATE TABLE breed (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT);
                CREATE TABLE dog (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT,
                    birthDate TEXT,
                    idBreed INTEGER
                );
            ");

            // Insertar una raza para FK
            _connection.Execute("INSERT INTO breed (name) VALUES ('Labrador');");

            _context = new DatabaseContext(_connection);
            _repository = new DogRepository(_context);
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        [Fact]
        public async Task AddDog_ShouldInsertDog()
        {
            var dog = new Dog
            {
                Name = "Firulais",
                BirthDate = new DateTime(2020, 5, 1).ToString("yyyy-MM-dd"),
                IdBreed = 1
            };

            var id = await _repository.AddAsync(dog);
            var inserted = await _repository.GetByIdAsync(id);

            Assert.NotNull(inserted);
            Assert.Equal("Firulais", inserted.Name);
        }

        [Fact]
        public async Task UpdateDog_ShouldModifyDog()
        {
            var id = await _repository.AddAsync(new Dog
            {
                Name = "Rocky",
                BirthDate = new DateTime(2019, 3, 10).ToString("yyyy-MM-dd"),
                IdBreed = 1
            });

            var dog = await _repository.GetByIdAsync(id);
            dog.Name = "Max";

            var updated = await _repository.UpdateAsync(dog);
            var modified = await _repository.GetByIdAsync(id);

            Assert.True(updated);
            Assert.Equal("Max", modified.Name);
        }

        [Fact]
        public async Task DeleteDog_ShouldRemoveDog()
        {
            var id = await _repository.AddAsync(new Dog
            {
                Name = "Toby",
                BirthDate = new DateTime(2018, 7, 15).ToString("yyyy-MM-dd"),
                IdBreed = 1
            });

            var deleted = await _repository.DeleteAsync(id);
            var result = await _repository.GetByIdAsync(id);

            Assert.True(deleted);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAll_ShouldReturnDogs()
        {
            await _repository.AddAsync(new Dog
            {
                Name = "Simba",
                BirthDate = new DateTime(2021, 1, 1).ToString("yyyy-MM-dd"),
                IdBreed = 1
            });

            await _repository.AddAsync(new Dog
            {
                Name = "Nala",
                BirthDate = new DateTime(2021, 1, 2).ToString("yyyy-MM-dd"),
                IdBreed = 1
            });

            var all = await _repository.GetAllAsync();
            Assert.Equal(2, all.Count());
        }
    }
}
