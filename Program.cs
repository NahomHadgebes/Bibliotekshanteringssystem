using Bibliotekshanteringssystem.Library;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Bibliotekshanteringssystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string dataJSONfilPath = "LibraryData.json";

                DataBase updatedJSON = DatabaseHelper.LoadDataFromJson(dataJSONfilPath);

                List<Book> allBooks = updatedJSON.BooksFromDataBase;
                List<Arthur> allArthurs = updatedJSON.ArthursFromDataBase;

                LibraryMenu.ShowMenu(allBooks, allArthurs, dataJSONfilPath);
            }
        }
    }
}
