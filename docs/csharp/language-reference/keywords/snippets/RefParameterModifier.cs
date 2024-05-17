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

            // call By Ref examples:

            var options = new OptionStruct();

            // <ByReadonlyRefExampleCall>
            ForceByRef(in options);
            ForceByRef(ref options);
            ForceByRef(options); // Warning! variable should be passed with `ref` or `in`
            ForceByRef(new OptionStruct()); // Warning, but an expression, so no variable to reference
            // </ByReadonlyRefExampleCall>
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
            itemRef = new Product("Stapler", 12345);
        }

        private static void ModifyProductsByReference()
        {
            // Declare an instance of Product and display its initial values.
            Product item = new Product("Fasteners", 54321);
            System.Console.WriteLine("Original values in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);

            // Pass the product instance to ChangeByReference.
            ChangeByReference(ref item);
            System.Console.WriteLine("Calling method.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);
        }

        // This method displays the following output:
        // Original values in Main.  Name: Fasteners, ID: 54321
        // Calling method.  Name: Stapler, ID: 12345

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

        private static void FirstOutExample()
        {
            // <OutVariableExample>
            int initializeInMethod;
            OutArgExample(out initializeInMethod);
            Console.WriteLine(initializeInMethod);     // value is now 44

            void OutArgExample(out int number)
            {
                number = 44;
            }
            // </OutVariableExample>
        }

        private static void OutVariableDeclaration()
        {
            // <OutVarDeclaration>
            string numberAsString = "1640";

            if (Int32.TryParse(numberAsString, out int number))
                Console.WriteLine($"Converted '{numberAsString}' to {number}");
            else
                Console.WriteLine($"Unable to convert '{numberAsString}'");
            // The example displays the following output:
            //       Converted '1640' to 1640
            // </OutVarDeclaration>
        }

        private static void FirstInExample()
        {
            // <InParameterModifier>
            int readonlyArgument = 44;
            InArgExample(readonlyArgument);
            Console.WriteLine(readonlyArgument);     // value is still 44

            void InArgExample(in int number)
            {
                // Uncomment the following line to see error CS8331
                //number = 19;
            }
            // </InParameterModifier>
        }

        // <ByReadonlyRefExample>
        public static void ForceByRef(ref readonly OptionStruct thing)
        {
            // elided
        }
        // </ByReadonlyRefExample>

    }

    public struct OptionStruct
    {
        // taking the place of lots of fields
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
