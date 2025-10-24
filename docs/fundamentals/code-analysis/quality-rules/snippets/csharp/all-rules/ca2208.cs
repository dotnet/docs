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

namespace ca2208_3
{
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
    //<snippet3>
    public class Foo
    {
        public string? Bar { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Example
    {
        // Violates CA2208: 'bar' is not a parameter of this method.
        public void ProcessFoo(Foo foo)
        {
            string? bar = foo.Bar;
            if (bar is null)
            {
                throw new ArgumentNullException(nameof(bar), $"Foo named {foo.Name} had no Bar!");
            }
            // Process bar...
        }
    }
    //</snippet3>
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
}

namespace ca2208_4
{
    //<snippet4>
    public class Foo
    {
        public string? Bar { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Example
    {
        // Fixed: Use InvalidOperationException for invalid object state.
        public void ProcessFoo(Foo foo)
        {
            string? bar = foo.Bar;
            if (bar is null)
            {
                throw new InvalidOperationException($"Foo named {foo.Name} had no Bar!");
            }
            // Process bar...
        }
    }
    //</snippet4>
}
