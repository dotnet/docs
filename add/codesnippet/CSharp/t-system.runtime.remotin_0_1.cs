using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void TestParse(string testString)
    {
        try
        {
            // Parse the test string.
            SoapNormalizedString normalized = 
                SoapNormalizedString.Parse(testString);

            // Report that the parse succeeded if no exception was thrown.
            Console.WriteLine(
                "Parse succeeded on the string \"{0}\".", 
                testString);

            // Print the string representation of the object.
            Console.WriteLine(
                "The normalized value of this string is \"{0}\".",
                normalized.ToString());

            // Print the XSD type of the object.
            Console.WriteLine(
                "The XSD type of the SoapNormalizedString " + 
                "object is {0}.", normalized.GetXsdType());

            // Print the value of the SoapNormalizedString object.
            Console.WriteLine(
                "The value of the SoapNormalizedString " +
                "object is \"{0}\".", 
                normalized.Value);
        }
        catch(System.Runtime.Remoting.RemotingException e)
        {
            // Report the details of the exception that was thrown.
            Console.WriteLine(
                "Parse failed on the string \"{0}\".", 
                testString);
            Console.WriteLine(e.Message);
        }
    }

    public static void Main(string[] args)
    {
        // Create strings to test the Parse method.
        string stringWithSpaces = "one two";
        string stringWithSpacesAndTabs = "one two\t";
        string stringWithSpacesAndLineFeed = "one two\n";
        string stringWithSpacesAndCarriageReturn = "one two\r";

        // Test the Parse method with each string.
        TestParse(stringWithSpaces);
        TestParse(stringWithSpacesAndTabs);
        TestParse(stringWithSpacesAndLineFeed);
        TestParse(stringWithSpacesAndCarriageReturn);

        // Print the XSD type string of the SoapNormalizedString class.
        Console.WriteLine(
            "The XSD type of the SoapNormalizedString class " +
            "is {0}.", SoapNormalizedString.XsdType);
    }
}