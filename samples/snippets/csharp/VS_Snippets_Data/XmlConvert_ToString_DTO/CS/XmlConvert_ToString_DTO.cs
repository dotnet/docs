//<snippet1>
using System;
using System.Xml;

class Example
{
    static void Main()
    {
        // Create the DateTimeOffset object and set the time to the current time
        DateTimeOffset dto;
        dto = DateTimeOffset.Now;

        // Convert the DateTimeOffset object to a string and display the result
        string timeAsString = XmlConvert.ToString(dto);
        Console.WriteLine(timeAsString);
    }
}
//</snippet1>