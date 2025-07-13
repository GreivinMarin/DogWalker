namespace DogWalker.Core.Entities
{
    public class Walk
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdDog { get; set; }
        public string Date { get; set; }
        public double Duration { get; set; }

        // Auxiliar properties (Not in database)
        public string ClientName { get; set; }
        public string DogName { get; set; }
    }
}
