class Test1
{
    //<Snippet2>
    static int Main(string[] args)
    //</Snippet2>
    {
        //<Snippet4>
        if (args.Length == 0)
        {
            System.Console.WriteLine("Please enter a numeric argument.");
            return 1;
        }
        //</Snippet4>

        return 0;
    }
}

class Test2
{
    //<Snippet3>
    static void Main(string[] args)
    //</Snippet3>
    {
    }
}

//-----------------------------------------------------------------------------
class Test3
{
    //<Snippet12>
    static void Main()
    {
        //...
    }
    //</Snippet12>
}

//-----------------------------------------------------------------------------
//<Snippet14>
// Save this program as MainReturnValTest.cs.
class MainReturnValTest
{
    //<Snippet13>
    static int Main()
    {
        //...
        return 0;
    }
    //</Snippet13>
}
//</Snippet14>

//-----------------------------------------------------------------------------
class Test4
{
    //<Snippet18>
    static int Main(string[] args)
    {
        //...
        return 0;
    }
    //</Snippet18>
}

//-----------------------------------------------------------------------------
class Test5
{
    //<Snippet19>
    static void Main(string[] args)
    {
        //...
    }
    //</Snippet19>
}
