namespace ca1806
{
    //<snippet1>
    public class Book
    {
        public Book(string title)
        {
            // Violates this rule.
            title?.Trim();

            Title = title;
        }

        public string? Title { get; }
    }
    //</snippet1>
}

namespace ca1806_2
{
    //<snippet2>
    public class Book
    {
        public Book(string title)
        {
            if (title != null)
            {
                // Fixes the violation.
                title = title.Trim();
            }

            Title = title;
        }

        public string? Title { get; }
    }
    //</snippet2>
}

namespace ca1806_3
{
    //<snippet3>
    public class Book
    {
        public Book() { }

        public static Book CreateBook()
        {
            // Violates this rule.
            new Book();
            return new Book();
        }
    }
    //</snippet3>
}

namespace ca1806_4
{
    //<snippet4>
    public class Book
    {
        public Book() { }

        public static Book CreateBook()
        {
            // Fixes the violation.
            return new Book();
        }
    }
    //</snippet4>
}
