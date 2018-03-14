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

        // Specify formats against which time will be validated before conversion to DateTimeOffset
        // If time does not match one of the specified formats, a FormatException will be thrown.
        // Each specified format must be a subset of the W3C Recommendation for the XML dateTime type
        string[] formats = {"yyyy-MM-ddTHH:mm:sszzzzzzz", "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-dd"};
        try
        {
            // Read the element contents as a string and covert to DateTimeOffset type
            DateTimeOffset transaction_time = XmlConvert.ToDateTimeOffset(time, formats);
            Console.WriteLine(transaction_time);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
//</snippet1>
