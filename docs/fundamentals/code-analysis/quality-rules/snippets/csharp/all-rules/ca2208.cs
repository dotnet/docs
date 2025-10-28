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
    public class Product
    {
        public string? Description { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Example
    {
        // Violates CA2208: 'description' is not a parameter of this method.
        public void ProcessProduct(Product product)
        {
            string? description = product.Description;
            if (description is null)
            {
                throw new ArgumentNullException(nameof(description), $"Product named {product.Name} had no description!");
            }
            // Process description...
        }
    }
    //</snippet3>
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
}

namespace ca2208_4
{
    //<snippet4>
    public class Product
    {
        public string? Description { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Example
    {
        // Fixed: Use InvalidOperationException for invalid object state.
        public void ProcessProduct(Product product)
        {
            string? description = product.Description;
            if (description is null)
            {
                throw new InvalidOperationException($"Product named {product.Name} had no description!");
            }
            // Process description...
        }
    }
    //</snippet4>
}
