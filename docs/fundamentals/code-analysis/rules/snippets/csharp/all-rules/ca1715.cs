namespace ca1715
{
    //<snippet1>
    // Violation.
    public interface Book
    {
        string Title
        {
            get;
        }

        void Read();
    }
    //</snippet1>

    //<snippet2>
    // Fixes the violation by prefixing the interface with 'I'.
    public interface IBook
    {
        string Title
        {
            get;
        }

        void Read();
    }
    //</snippet2>

    //<snippet3>
    // Violation.
    public class Collection<Item>
    {
    }
    //</snippet3>
}

namespace ca1715_2
{
    //<snippet4>
    // Fixes the violation by prefixing the generic type parameter with 'T'.
    public class Collection<TItem>
    {
    }
    //</snippet4>
}
