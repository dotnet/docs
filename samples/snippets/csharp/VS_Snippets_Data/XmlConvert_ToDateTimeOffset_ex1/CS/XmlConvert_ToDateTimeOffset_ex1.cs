//<snippet1>
using System;
using System.Xml;

class Example
{
    static void Main()
    {
        // Create an XmlReader, read to the "time" element, and read contents as type string
        XmlReader reader = XmlReader.Create("transactions.xml");
        reader.ReadToFollowing("time");
        string time = reader.ReadElementContentAsString();

        // Read the element contents as a string and covert to DateTimeOffset type
        // The format of time must be a subset of the W3C Recommendation for the XML dateTime type
        DateTimeOffset transaction_time = XmlConvert.ToDateTimeOffset(time);
        Console.WriteLine(transaction_time);
    }
}
//</snippet1>
