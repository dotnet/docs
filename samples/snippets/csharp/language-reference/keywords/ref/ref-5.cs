// <Snippet1>
using System;

public class Book
{
   public string Author;
   public string Title;
}

public class BookCollection
{
   private Book[] books = { new Book { Title = "Call of the Wild, The", Author = "Jack London" },
                            new Book { Title = "Tale of Two Cities, A", Author = "Charles Dickens" }  
                           };
   private Book nobook = null;

   public ref Book GetBookByTitle(string title)
   {
      for (int ctr = 0; ctr < books.Length; ctr++)
      {
         if (title == books[ctr].Title)
            return ref books[ctr];
      }
      return ref nobook;
   }

   public void ListBooks()
   {
      foreach (var book in books) {
         Console.WriteLine($"{book.Title}, by {book.Author}");
      }
      Console.WriteLine();   
   } 
}
// </Snippet1>

namespace Caller
{
// <Snippet2>
using System;

class Example
{
   static void Main()
   {
      var bc = new BookCollection();
      bc.ListBooks();
      
      ref var book = ref bc.GetBookByTitle("Call of the Wild, The");
      if (book != null)
         book = new Book { Title = "Republic, The", Author = "Plato" };
      bc.ListBooks();
   }
}
// The example displays the following output:
//       Call of the Wild, The, by Jack London
//       Tale of Two Cities, A, by Charles Dickens
//       
//       Republic, The, by Plato
//       Tale of Two Cities, A, by Charles Dickens
// </Snippet2>
}

