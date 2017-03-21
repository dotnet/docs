using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD formatted string to create a SoapAnyUri object.
        string xsdAnyUri = "http://localhost:8080/WebService";
        SoapAnyUri anyUri = SoapAnyUri.Parse(xsdAnyUri);

        // Print the value of the SoapAnyUri object in XSD format. 
        Console.WriteLine(
            "The SoapAnyUri object in XSD format is {0}.",
            anyUri.ToString());

        // Print the XSD type string of the SoapAnyUri object.
        Console.WriteLine("The XSD type of the SoapAnyUri " + 
            "object is {0}.", anyUri.GetXsdType());

        // Print the value of the SoapAnyUri object.
        Console.WriteLine(
            "The value of the SoapAnyUri object is {0}.", 
            anyUri.Value);

        // Print the XSD type string of the SoapAnyUri class.
        Console.WriteLine(
            "The XSD type of the SoapAnyUri class " +
            "is {0}.", SoapAnyUri.XsdType);
    }
}