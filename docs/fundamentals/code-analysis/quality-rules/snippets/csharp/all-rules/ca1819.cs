using System.Collections.ObjectModel;

namespace ca1819
{
    //<snippet1>
    public class Book
    {
        public Book(string[] pages)
        {
            Pages = pages;
        }

        public string[] Pages { get; }
    }
    //</snippet1>
}

namespace ca1819_2
{
    //<snippet2>
    public class Book
    {
        private string[] _Pages;

        public Book(string[] pages)
        {
            _Pages = pages;
        }

        public string[] GetPages()
        {
            // Need to return a clone of the array so that consumers            
            // of this library cannot change its contents            
            return (string[])_Pages.Clone();
        }
    }
    //</snippet2>
}

namespace ca1819_3
{
    //<snippet3>
    public class Book
    {
        public Book(string[] pages)
        {
            Pages = new ReadOnlyCollection<string>(pages);
        }

        public ReadOnlyCollection<string> Pages { get; }
    }
    //</snippet3>
}

namespace ca1819_4
{
    //<snippet4>
    public class Book
    {
        public Book(string[] pages)
        {
            Pages = pages;
        }

        public string[] Pages { get; set; }
    }
    //</snippet4>
}

namespace ca1819_5
{
    //<snippet5>
    public class Book
    {
        public Book(string[] pages)
        {
            Pages = new Collection<string>(pages);
        }

        public Collection<string> Pages { get; }
    }
    //</snippet5>
}
