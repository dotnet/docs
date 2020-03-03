// System.Web.HttpUtility.HtmlEncode(string)
// System.Web.HttpUtility.HtmlDecode(string,TextWriter)

/*
The following example demonstrates the  'HtmlEncode(string)'
and 'HtmlDecode(string,TextWriter)' methods of 'HttpUtility' class.
The input string is taken from user and encoded using 'HtmlEncode(string)'
method.The encoded string thus obtained is then decoded using 
'HtmlDecode(string,TextWriter)' method.
*/

// <Snippet1>
// <Snippet2>
using System;
using System.Web;
using System.IO;

class MyNewClass
{
    public static void Main()
    {
        Console.WriteLine("Enter a string having '&', '<', '>' or '\"' in it: ");
        string myString = Console.ReadLine();

        // Encode the string.
        string myEncodedString = HttpUtility.HtmlEncode(myString);

        Console.WriteLine($"HTML Encoded string is: {myEncodedString}");
        StringWriter myWriter = new StringWriter();

        // Decode the encoded string.
        HttpUtility.HtmlDecode(myEncodedString, myWriter);

        string myDecodedString = myWriter.ToString();
        Console.Write($"Decoded string of the above encoded string is: {myDecodedString}");
    }
}
// </Snippet2>
// </Snippet1>
