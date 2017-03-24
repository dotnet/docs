using System.Collections;

// Declare the Tokens class. The class implements the IEnumerable interface.
public class Tokens : IEnumerable
{
    private string[] elements;

    Tokens(string source, char[] delimiters)
    {
        // The constructor parses the string argument into tokens.
        elements = source.Split(delimiters);
    }

    // The IEnumerable interface requires implementation of method GetEnumerator.
    public IEnumerator GetEnumerator()
    {
        return new TokenEnumerator(this);
    }


    // Declare an inner class that implements the IEnumerator interface.
    private class TokenEnumerator : IEnumerator
    {
        private int position = -1;
        private Tokens t;

        public TokenEnumerator(Tokens t)
        {
            this.t = t;
        }

        // The IEnumerator interface requires a MoveNext method.
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

        // The IEnumerator interface requires a Reset method.
        public void Reset()
        {
            position = -1;
        }

        // The IEnumerator interface requires a Current method.
        public object Current
        {
            get
            {
                return t.elements[position];
            }
        }
    }


    // Test the Tokens class.
    static void Main()
    {
        // Create a Tokens instance.
        Tokens f = new Tokens("This is a sample sentence.", new char[] {' ','-'});

        // Display the tokens.
        foreach (string item in f)
        {
            System.Console.WriteLine(item);
        }
    }
}
/* Output:
    This
    is
    a
    sample
    sentence.  
*/