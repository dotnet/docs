// <Snippet1>
using System;
using System.Globalization;
using System.IO;

class StrWriter
{
    static void Main()
    {
        StringWriter strWriter = 
            new StringWriter(new CultureInfo("ar-DZ"));

        strWriter.Write(DateTime.Now);

        // <Snippet2>
        Console.WriteLine(
            "Current date and time using the invariant culture: {0}\n" +
            "Current date and time using the Algerian culture: {1}", 
            DateTime.Now.ToString(), strWriter.ToString());
        // </Snippet2>
    }
}
// </Snippet1>