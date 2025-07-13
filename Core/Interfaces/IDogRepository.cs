using DogWalker.Core.Entities;

namespace DogWalker.Core.Interfaces
{
    public interface IDogRepository : IRepository<Dog>
    {
        // Optional: methods like FindByBreedId or GetWithBreedName
    }
}
