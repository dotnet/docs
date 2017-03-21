using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD gTime to create a SoapTime object.
        // The time zone of this object is the current time zone.
        string xsdTime = "12:13:14.123Z";
        SoapTime time = SoapTime.Parse(xsdTime);

        // Display the time in XSD format. 
        Console.WriteLine("The time in XSD format is {0}.",
            time.ToString());

        // Display the XSD type string of this particular SoapTime object.
        Console.WriteLine("The XSD type of the SoapTime object is {0}.",
            time.GetXsdType());

        // Display the value of the SoapTime object.
        Console.WriteLine("The value of the SoapTime object is {0}.",
            time.Value);

        // Display the XSD type string of the SoapTime class.
        Console.WriteLine("The XSD type of the class SoapTime is {0}.",
            SoapTime.XsdType);
    }
}