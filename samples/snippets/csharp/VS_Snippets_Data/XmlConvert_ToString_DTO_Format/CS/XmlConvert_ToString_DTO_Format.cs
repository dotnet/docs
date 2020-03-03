//<snippet1>
using System;
using System.Xml;

class Example
{
    static void Main()
    {
        // Create the DateTimeOffset object and set the time to the current time.
        DateTimeOffset dto;
        dto = DateTimeOffset.Now;

        // Convert the DateTimeObject to a string in a specified format and display the result.
        // The specified format must be a subset of the W3C Recommendation for the XML dateTime type.
        String timeAsString = XmlConvert.ToString(dto, "yyyy-MM-ddTHH:mm:sszzzzzzz");
        Console.WriteLine(timeAsString);
    }
}
//</snippet1>