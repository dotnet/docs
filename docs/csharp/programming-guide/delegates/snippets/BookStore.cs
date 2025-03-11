using System;
using System.Collections.Generic;

// A set of classes for handling a bookstore:
namespace Bookstore;

// Describes a book in the book list:
public record struct Book(string Title, string Author, decimal Price, bool Paperback);

// Declare a delegate type for processing a book:
public delegate void ProcessBookCallback(Book book);

// Maintains a book database.
public class BookDB
{
    // List of all books in the database:
    List<Book> list = new();

    // Add a book to the database:
    public void AddBook(string title, string author, decimal price, bool paperBack) =>
        list.Add(new Book(title, author, price, paperBack));

    // Call a passed-in delegate on each paperback book to process it:
    public void ProcessPaperbackBooks(ProcessBookCallback processBook)
    {
        foreach (Book b in list)
        {
            if (b.Paperback)
            {
                // Calling the delegate:
                processBook(b);
            }
        }
    }
}

// Using the Bookstore classes:

// Class to total and average prices of books:
class PriceTotaller
{
    private int countBooks = 0;
    private decimal priceBooks = 0.0m;

    internal void AddBookToTotal(Book book)
    {
        countBooks += 1;
        priceBooks += book.Price;
    }

    internal decimal AveragePrice() => priceBooks / countBooks;
}

// Class to test the book database:
class Test
{
    // Print the title of the book.
    static void PrintTitle(Book b) => Console.WriteLine($"   {b.Title}");

    // Execution starts here.
    static void Main()
    {
        BookDB bookDB = new BookDB();

        // Initialize the database with some books:
        AddBooks(bookDB);

        // Print all the titles of paperbacks:
        Console.WriteLine("Paperback Book Titles:");

        // Create a new delegate object associated with the static
        // method Test.PrintTitle:
        bookDB.ProcessPaperbackBooks(PrintTitle);

        // Get the average price of a paperback by using
        // a PriceTotaller object:
        PriceTotaller totaller = new PriceTotaller();

        // Create a new delegate object associated with the nonstatic
        // method AddBookToTotal on the object totaller:
        bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);

        Console.WriteLine($"Average Paperback Book Price: ${totaller.AveragePrice():#.##}");
    }

    // Initialize the book database with some test books:
    static void AddBooks(BookDB bookDB)
    {
        bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
        bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
        bookDB.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
        bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
    }
}
/* Output:
Paperback Book Titles:
   The C Programming Language
   The Unicode Standard 2.0
   Dogbert's Clues for the Clueless
Average Paperback Book Price: $23.97
*/
