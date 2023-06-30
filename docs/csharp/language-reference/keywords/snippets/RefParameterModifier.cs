using System;
using System.Collections.Generic;
using System.Text;

namespace InRefOutModifier
{
    public class RefParameterModifier
    {
        public static void Examples()
        {
            FirstRefExample();
            ModifyProductsByReference();
        }

        private static void FirstRefExample()
        {
            // <Snippet1>
            void Method(ref int refArgument)
            {
                refArgument = refArgument + 44;
            }

            int number = 1;
            Method(ref number);
            Console.WriteLine(number);
            // Output: 45
            // </Snippet1>
        }

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


        //<Snippet3>
        class Product
        {
            public Product(string name, int newID)
            {
                ItemName = name;
                ItemID = newID;
            }

            public string ItemName { get; set; }
            public int ItemID { get; set; }
        }

        private static void ChangeByReference(ref Product itemRef)
        {
            // Change the address that is stored in the itemRef parameter.
            itemRef = new Product("Stapler", 99999);

            // You can change the value of one of the properties of
            // itemRef. The change happens to item in Main as well.
            itemRef.ItemID = 12345;
        }

        private static void ModifyProductsByReference()
        {
            // Declare an instance of Product and display its initial values.
            Product item = new Product("Fasteners", 54321);
            System.Console.WriteLine("Original values in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);

            // Pass the product instance to ChangeByReference.
            ChangeByReference(ref item);
            System.Console.WriteLine("Back in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);
        }

        // This method displays the following output:
        // Original values in Main.  Name: Fasteners, ID: 54321
        // Back in Main.  Name: Stapler, ID: 12345

        // </Snippet3>

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
    //<Snippet2>
    class RefOverloadExample
    {
        public void SampleMethod(int i) { }
        public void SampleMethod(ref int i) { }
    }
    // </Snippet2>

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
