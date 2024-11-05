namespace Bibliotekshanteringssystem.Library
{
    public class LibraryClass
    {
        public static void AddNewBook(List<Book> allBooks, List<Arthur> allArthurs, string dataJSONfilPath)
        {
            string bokUserInput;
            while (true)
            {
                Console.WriteLine("Please write the title of the book you want to add");
                bokUserInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(bokUserInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            string authorUserInput;
            while (true)
            {
                Console.WriteLine("What's the name of the author?");
                authorUserInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(authorUserInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            string genreUserInput;
            while (true)
            {
                Console.WriteLine("Which genre is the book?");
                genreUserInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(genreUserInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            int isbnUserInput;
            while (true) 
            {
                Console.WriteLine("Please write the ISBN of the book:");
                if (int.TryParse(Console.ReadLine(), out isbnUserInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            int yearUserInput;
            while (true)
            {
                Console.WriteLine("Which year was the book published?");
                if (int.TryParse(Console.ReadLine(),out yearUserInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }

            }
            int idUserInput;
            while (true)
            {
                Console.WriteLine("Please write the ID of the book");
                if (int.TryParse(Console.ReadLine(),out idUserInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");

                }
            }
            Book newBook = new Book(bokUserInput, authorUserInput, genreUserInput, isbnUserInput, yearUserInput, idUserInput);
            allBooks.Add(newBook);
            Console.WriteLine($"{bokUserInput} by {authorUserInput} has now been added.");
            Console.WriteLine("Press any key to return to first page");
            Console.ReadLine();
        }

        public static void AddNewArthur(List<Arthur> allArthurs, List<Book> allBooks, string dataJSONfilPath)
        {
            Console.WriteLine("What's the name of the author you want to add?");
            string authorInput = Console.ReadLine();

            Console.WriteLine("Please write the author's ID:");
            int idUserInput = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What country is the author from?");
            string countryUserInput = Console.ReadLine();

            Arthur newArthur = new Arthur(authorInput, idUserInput, countryUserInput);
            allArthurs.Add(newArthur);

            DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);

            Console.WriteLine($"{authorInput} from {countryUserInput} has now been added.");
            Console.ReadLine();
        }

        public static void UppdateBokDetails(List<Book> allBooks, List<Arthur> allArthurs, string dataJSONfilPath)
        {
            Console.WriteLine("Enter the ID of the book you want to update:");
            int bookId = Convert.ToInt32(Console.ReadLine());


            Book bookToUpdate = allBooks.FirstOrDefault(b => b.Id == bookId);

            if (bookToUpdate != null)
            {
                Console.WriteLine($"Updating details for: {bookToUpdate.Titel}");

                Console.WriteLine("Choose the field you want to update: ...");
                Console.WriteLine("1. Title");
                Console.WriteLine("2. Author");
                Console.WriteLine("3. Genre");
                Console.WriteLine("4. ISBN");
                Console.WriteLine("5. Published Year");
                Console.WriteLine("Enter the number of the field to update:");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                if (choice == 1)
                {
                    Console.WriteLine("Enter the new title:");
                    bookToUpdate.Titel = Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the new author:");
                    bookToUpdate.Arthur = Console.ReadLine();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the new genre:");
                    bookToUpdate.Genre = Console.ReadLine();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter the new ISBN:");
                    bookToUpdate.ISBN = Convert.ToInt32(Console.ReadLine());
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Enter the new published year:");
                    bookToUpdate.PublishedYear = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    return;
                }

                DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);

                Console.WriteLine("Book details has now been updated.");
            }
            else
            {
                Console.WriteLine("Book with this specific ID was not found, try again");
            }


        }
        public static void UpdateArthurDetails(List<Arthur> allArthurs, List<Book> allBooks, string dataJSONfilPath)
        {
            Console.WriteLine("Enter the ID of the author you want to update:");
            int arthurId = Convert.ToInt32(Console.ReadLine());

          
            Arthur arthurToUpdate = allArthurs.FirstOrDefault(a => a.Id == arthurId);

            if (arthurToUpdate != null)
            {
                Console.WriteLine("Choose the field you want to update:");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Country");
                Console.WriteLine("Enter the number of the field to update:");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter the new name:");
                    arthurToUpdate.Name = Console.ReadLine();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the new country:");
                    arthurToUpdate.Country = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again");
                    return;
                }

                DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);

                Console.WriteLine("Author details has now been updated.");
            }
            else
            {
                Console.WriteLine("Author with this specific ID was not found, try again");
            }
        }
        public static void RemoveBook(List<Book> allBooks, List<Arthur> allArthurs, string dataJSONfilPath)
        {
            Console.WriteLine("Enter the ID of the book you want to remove:");
            int bookId = Convert.ToInt32(Console.ReadLine());

            Book bookToRemove = allBooks.FirstOrDefault(b => b.Id == bookId);

            if (bookToRemove != null)
            {
                allBooks.Remove(bookToRemove);
                Console.WriteLine($"Removed book: {bookToRemove.Titel}");

                DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);

                Console.WriteLine("Book details has now been removed.");
            }
            else
            {
                Console.WriteLine("Book with this specific ID was not found, try again");
            }
        }

        public static void RemoveAuthor(List<Arthur> allArthurs, List<Book> allBooks, string dataJSONfilPath)
        {
            Console.WriteLine("Enter the ID of the author you want to remove:");
            int authorId = Convert.ToInt32(Console.ReadLine());


            Arthur authorToRemove = allArthurs.FirstOrDefault(a => a.Id == authorId);

            if (authorToRemove != null)
            {
                allArthurs.Remove(authorToRemove);
                Console.WriteLine($"Removed author: {authorToRemove.Name}");

                DatabaseHelper.SaveDataToJson(allBooks, allArthurs, dataJSONfilPath);

                Console.WriteLine("Author details has now been removed.");
            }
            else
            {
                Console.WriteLine("Author with this specific ID was not found, try again");
            }
        }
        public static void ShowAllBooks(List<Book> allBooks)
        {
            Console.WriteLine("Here is youre book collection:");
            if (allBooks.Count == 0)
            {
                Console.WriteLine("There's no books to show.");
                return;
            }

            foreach (var book in allBooks)
            {
                Console.WriteLine($"ID: {book.Id}, Titel: {book.Titel}, Författare: {book.Arthur}, Genre: {book.Genre}, ISBN: {book.ISBN}, Publiceringsår: {book.PublishedYear}");
            }
        }
        public static void ShowAllAuthors(List<Arthur> allArthurs)
        {
            Console.WriteLine("here is youre arthur collection:");
            if (allArthurs.Count == 0)
            {
                Console.WriteLine("There's no arthur to show");
                return;
            }

            foreach (var author in allArthurs)
            {
                Console.WriteLine($"ID: {author.Id}, Namn: {author.Name}, Land: {author.Country}");
            }
        }



    }

}


