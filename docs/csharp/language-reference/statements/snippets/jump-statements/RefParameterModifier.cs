using System;
using System.Collections.Generic;
using System.Text;

namespace InRefOutModifier
{
    public class RefParameterModifier
    {
        // <SnippetFindReturningRef>
        public static ref int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
            throw new InvalidOperationException("Not found");
        }
        // </SnippetFindReturningRef>


        private static void BookCollectionExample()
        {
            // <Snippet5>
            var bc = new BookCollection();
            bc.ListBooks();

            ref var book = ref bc.GetBookByTitle("Call of the Wild, The");
            if (book != null)
                book = new Book { Title = "Republic, The", Author = "Plato" };
            bc.ListBooks();
            // The example displays the following output:
            //       Call of the Wild, The, by Jack London
            //       Tale of Two Cities, A, by Charles Dickens
            //
            //       Republic, The, by Plato
            //       Tale of Two Cities, A, by Charles Dickens
            // </Snippet5>
        }
    }
    
    // <Snippet4>

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
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}, by {book.Author}");
            }
            Console.WriteLine();
        }
    }
    // </Snippet4>
}
