// <Snippet2>
using System;

public class IConvertibleEx
{
    public static void Main()
    {
        bool flag = true;
        try
        {
            IConvertible conv = flag;
            Char ch = conv.ToChar(null);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Cannot convert a Boolean to a Char.");
        }

        try
        {
            Char ch = Convert.ToChar(flag);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Cannot convert a Boolean to a Char.");
        }
    }
}
// The example displays the following output:
//       Cannot convert a Boolean to a Char.
//       Cannot convert a Boolean to a Char.
// </Snippet2>
