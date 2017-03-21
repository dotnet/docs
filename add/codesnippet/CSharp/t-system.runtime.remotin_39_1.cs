using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD duration to create a TimeSpan object.
        // This is a duration of 2 years, 3 months, 9 days, 12 hours, 
        // 35 minutes, 20 seconds, and 10 milliseconds.
        string xsdDuration = "P2Y3M9DT12H35M20.0100000S";
        TimeSpan timeSpan = SoapDuration.Parse(xsdDuration);
        Console.WriteLine("The time span contains {0} days.", 
            timeSpan.Days);
        Console.WriteLine("The time span contains {0} hours.", 
            timeSpan.Hours);
        Console.WriteLine("The time span contains {0} minutes.", 
            timeSpan.Minutes);
        Console.WriteLine("The time span contains {0} seconds.", 
            timeSpan.Seconds);

        // Serialize a TimeSpan object as an XSD duration string.
        // This object represents a time span of 399 days, 12 hours,
        // 35 minutes, 20 seconds, and 10 milliseconds.
        TimeSpan duration = new TimeSpan(399, 12, 35, 20, 10);
        Console.WriteLine("The duration in XSD format is {0}.",
            SoapDuration.ToString(duration));

        // Print the XSD type string of the SoapDuration class.
        Console.WriteLine("The XSD type of SoapDuration is {0}.",
            SoapDuration.XsdType);
    }
}