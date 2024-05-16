using System;

namespace ca2208
{
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
    //<snippet1>
    public class Book
    {
        public Book(string title)
        {
            Title = title ??
                throw new ArgumentNullException("All books must have a title.", nameof(title));
        }

        public string Title { get; }
    }
    //</snippet1>
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
}

namespace ca2208_2
{
    //<snippet2>
    public class Book
    {
        public Book(string title)
        {
            Title = title ??
                throw new ArgumentNullException(nameof(title), "All books must have a title.");
        }

        public string Title { get; }
    }
    //</snippet2>
}
