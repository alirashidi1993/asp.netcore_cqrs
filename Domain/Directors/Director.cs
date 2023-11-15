using Framework.Domain;

namespace Domain.Directors
{
    public class Director : BaseEntity
    {
        public Director(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }
        private Director() { }
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
