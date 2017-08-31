//<Snippet1>
using System.Collections;

// Declare the Tokens class:
public class Tokens : IEnumerable
{
    private string[] elements;

    Tokens(string source, char[] delimiters)
    {
        // Parse the string into tokens:
        elements = source.Split(delimiters);
    }

    // non-IEnumerable implementation
    public TokenEnumerator GetEnumerator() 
    {
        return new TokenEnumerator(this);
    }

    // IEnumerable implementation
    IEnumerator IEnumerable.GetEnumerator() 
    {
        return (IEnumerator)new TokenEnumerator(this);
    }

    // Inner class implements IEnumerator interface:
    public class TokenEnumerator : IEnumerator
    {
        private int position = -1;
        private Tokens t;

        public TokenEnumerator(Tokens t)
        {
            this.t = t;
        }

        public bool MoveNext()
        {
            if (position < t.elements.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        // non-IEnumerator version: type-safe
        public string Current
        {
            get
            {
                return t.elements[position];
            }
        }
        
        // IEnumerator version: returns object
        object IEnumerator.Current 
        {
            get
            {
                return t.elements[position];
            }
        }
    }


    //<Snippet4>
    // Test Tokens, TokenEnumerator
    static void Main()
    {
        // Testing Tokens by breaking the string into tokens:
        Tokens f = new Tokens("This is a well-done program.", new char[] { ' ', '-' });

        // try changing string to int
        foreach (string item in f) 
        {
            System.Console.WriteLine(item);
        }
    }
    //</Snippet4>
}
//</Snippet1>


//-----------------------------------------------------------------------------
class Test
{
    static void Main()
    {
        //<Snippet6>
        ArrayList list = new ArrayList();
        list.Add(10);
        list.Add(20);
        //</Snippet6>
    }
}
