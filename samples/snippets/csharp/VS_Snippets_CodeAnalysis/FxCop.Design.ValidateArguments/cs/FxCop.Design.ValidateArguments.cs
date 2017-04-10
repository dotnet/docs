//<Snippet1>
using System;

namespace DesignLibrary
{
    public class Test
    {
        // This method violates the rule.
        public void DoNotValidate(string input)
        {
            if (input.Length != 0)
            {
                Console.WriteLine(input);
            }
        }

        // This method satisfies the rule.
        public void Validate(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (input.Length != 0)
            {
                Console.WriteLine(input);
            }
        }
    }
}
//</Snippet1>

class someClass
{
    //<Snippet2>

    public string Method(string value)
    {
        EnsureNotNull(value);

        // Fires incorrectly    
        return value.ToString();
    }

    private void EnsureNotNull(string value)
    {
        if (value == null)
            throw new ArgumentNullException("value");
    }
    //</Snippet2>


    //<Snippet3>
    public string Method(string value1, string value2)
    {
        if (value1 == null || value2 == null)
            throw new ArgumentNullException(value1 == null ? "value1" : "value2");

        // Fires incorrectly    
        return value1.ToString() + value2.ToString();
    }
    //</Snippet3>
}