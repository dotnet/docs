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

        // Specify a format against which time will be validated before conversion to DateTimeOffset
        // If time does not match the format, a FormatException will be thrown.
        // The specified format must be a subset of the W3C Recommendation for the XML dateTime type
        string format = "yyyy-MM-ddTHH:mm:sszzzzzzz";
        try
        {
            // Read the element contents as a string and covert to DateTimeOffset type
            DateTimeOffset transaction_time = XmlConvert.ToDateTimeOffset(time, format);
            Console.WriteLine(transaction_time);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
//</snippet1>
