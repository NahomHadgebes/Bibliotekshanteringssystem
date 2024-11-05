
using Bibliotekshanteringssystem.Library;
using System.Text.Json.Serialization;

namespace Bibliotekshanteringssystem
{
    public class DataBase
    {
        [JsonPropertyName("Book")]
        public List<Book> BooksFromDataBase { get; set; }


        [JsonPropertyName("Arthur")]
        public List<Arthur> ArthursFromDataBase { get; set; }

    }
}
