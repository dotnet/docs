//<Snippet7>
//</Snippet7>

//<Snippet11>
using Alias = System.Console;
using Co = Company.Proj.Nested;  // define an alias to represent a namespace
//</Snippet11>

//<Snippet13>
using global = System.Collections;   // Warning
//</Snippet13>

//-----------------------------------------------------------------------------
public class Company
{
    public class Proj
    {
        public class Nested
        {
        }
    }
}

//-----------------------------------------------------------------------------
class WrapTestClass
{
    //<Snippet12>
    class TestClass
    {
        static void Main()
        {
            // Error
            //Alias::WriteLine("Hi");

            // OK
            Alias.WriteLine("Hi");
        }
    }
    //</Snippet12>
}
