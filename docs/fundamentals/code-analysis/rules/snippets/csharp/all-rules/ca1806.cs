namespace ca1806
{
    //<snippet1>
    public class Book
    {
        private readonly string _Title;

        public Book(string title)
        {
            if (title != null)
            {
                // Violates this rule
                title.Trim();
            }

            _Title = title;
        }

        public string Title
        {
            get { return _Title; }
        }
    }
    //</snippet1>
}

namespace ca1806_2
{
    //<snippet2>
    public class Book
    {
        private readonly string _Title;

        public Book(string title)
        {
            if (title != null)
            {
                title = title.Trim();
            }

            _Title = title;
        }

        public string Title
        {
            get { return _Title; }
        }
    }
    //</snippet2>
}

namespace ca1806_3
{
    //<snippet3>
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
    //</snippet3>
}

namespace ca1806_4
{
    //<snippet4>
    public class Book
    {
        public Book()
        {
        }

        public static Book CreateBook()
        {
            return new Book();
        }
    }
    //</snippet4>
}
