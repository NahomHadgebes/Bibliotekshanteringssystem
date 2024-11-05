
namespace Bibliotekshanteringssystem.Library
{
    public class Arthur
    {
        public string Name { get; set; }

        public int Id { get; set; } 

        public string Country { get; set; }

        public Arthur(string name, int id, string country)
        {
            Name = name;
            Id = id;
            Country = country;


        }
    }
}
