
namespace Bibliotekshanteringssystem.Library
{
    public class Book
    {
        public string Titel { get; set; }

        public string Arthur { get; set; }

        public string Genre { get; set; }   

        public int PublishedYear { get; set; }

        public int Id { get; set; }

        public int ISBN { get; set; }

        public List <int> Recension {  get; set; }
      



        public Book (string titel, string arthur, string genre, int publishedYear, int id, int isbn)
        {
            Titel = titel;
            Arthur = arthur;
            Genre = genre;
            PublishedYear = publishedYear;
            Id = id;
            ISBN = isbn;    

            
        }
    }
}
