using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bibliotekshanteringssystem.Library
{
    public class LibraryMenu
    {
        public static void ShowMenu(List<Book> allBooks, List<Arthur> allArthurs, string dataJSONfilPath)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Välkommen till biblioteket!");
                Console.WriteLine("Tryck enter för att komma till huvudmeny");
                Console.ReadLine();

                Console.WriteLine("Vänligen välj ett alternativ här nedan...");
                Console.WriteLine("1. Lägg till bok");
                Console.WriteLine("2. Lägg till författare");
                Console.WriteLine("3. Uppdatera bokdetaljer");
                Console.WriteLine("4. Uppdatera författardetaljer");
                Console.WriteLine("5. Ta bort bok");
                Console.WriteLine("6. Ta bort författare");
                Console.WriteLine("7. Visa alla böcker");
                Console.WriteLine("8. Visa alla författare");
                Console.WriteLine("9. Avsluta");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice < 1 || choice > 9) 
                    {
                        Console.WriteLine("Ogiltigt val, vänligen ange ett nummer mellan 1 och 9.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            LibraryClass.AddNewBook(allBooks, allArthurs, dataJSONfilPath, DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath));
                            break;
                        case 2:
                            LibraryClass.AddNewArthur(allArthurs, allBooks, dataJSONfilPath);
                            break;
                        case 3:
                            LibraryClass.UppdateBokDetails(allBooks, allArthurs, dataJSONfilPath);
                            break;
                        case 4:
                            LibraryClass.UpdateArthurDetails(allArthurs, allBooks, dataJSONfilPath);
                            break;
                        case 5:
                            LibraryClass.RemoveBook(allBooks, allArthurs, dataJSONfilPath);
                            break;
                        case 6:
                            LibraryClass.RemoveAuthor(allArthurs,allBooks, dataJSONfilPath);
                            break;
                        case 7:
                            LibraryClass.ShowAllBooks(allBooks);
                            break;
                        case 8:
                            LibraryClass.ShowAllAuthors(allArthurs);
                            break;
                        case 9:
                            running = false;
                            break;
                           
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning, vänligen försök igen.");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Tack för att du använde biblioteket. Hejdå!");
        }
    }
    
}

