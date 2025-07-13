namespace DogWalker.Core.Entities
{
    public class Dog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BirthDate { get; set; }  // Saved as text in SQLite

        public int IdBreed { get; set; }

        // Optional: not mapped in DB, used for display only
        public string BreedName { get; set; }

    }
}
