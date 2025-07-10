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
            var largeStruct = new LargeStruct { Value1 = 42, Value2 = 3.14, Value3 = "Hello" };
            
            // Using 'in' avoids copying the large struct and prevents modification
            ProcessLargeStruct(in largeStruct);
            Console.WriteLine($"Original value unchanged: {largeStruct.Value1}");
            
            // Without 'in', the struct would be copied (less efficient for large structs)
            ProcessLargeStructByValue(largeStruct);
            Console.WriteLine($"Original value still unchanged: {largeStruct.Value1}");

            void ProcessLargeStruct(in LargeStruct data)
            {
                // Can read the values
                Console.WriteLine($"Processing: {data.Value1}, {data.Value2}, {data.Value3}");
                
                // Uncomment the following line to see error CS8331
                // data.Value1 = 99; // Compilation error: cannot assign to 'in' parameter
            }
            
            void ProcessLargeStructByValue(LargeStruct data)
            {
                // This method receives a copy of the struct
                Console.WriteLine($"Processing copy: {data.Value1}, {data.Value2}, {data.Value3}");
                
                // Modifying the copy doesn't affect the original
                data.Value1 = 99;
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

    public struct LargeStruct
    {
        public int Value1;
        public double Value2;
        public string Value3;
        // In a real scenario, this struct might have many more fields
        // making copying expensive
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
