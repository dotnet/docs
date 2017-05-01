//<Snippet1>
using System;

namespace Samples
{
    public class Book
    {
        public Book()
        {
        }

        public static Book CreateBook()
        {
            // Violates this rule            
            new Book();
            return new Book();
        }
    }
}
//</Snippet1>