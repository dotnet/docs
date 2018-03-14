// <Snippet2>
using System;
using System.Globalization;

class Example
{
    static void Main()
    {
        // Create a NumberFormatInfo object and set some of its properties.
        NumberFormatInfo provider = new NumberFormatInfo();
        provider.NumberDecimalSeparator = ",";
        provider.NumberGroupSeparator = ".";
        provider.NumberGroupSizes = new int[] { 3 };

        // Define an array of numeric strings to convert.
        String[] values = { "123456789", "12345.6789", "12345,6789", 
                            "123,456.789", "123.456,789", 
                            "123,456,789.0123", "123.456.789,0123" };

        Console.WriteLine("Default Culture: {0}\n", 
                          CultureInfo.CurrentCulture.Name);
        Console.WriteLine("{0,-22} {1,-20} {2,-20}\n", "String to Convert",
                          "Default/Exception", "Provider/Exception");

        // Convert each string to a Double with and without the provider.
        foreach (var value in values) {
           Console.Write("{0,-22} ", value);
           try {
              Console.Write("{0,-20} ", Convert.ToDouble(value));
           }   
           catch (FormatException e) {
              Console.Write("{0,-20} ", e.GetType().Name);
           }
           try {
              Console.WriteLine("{0,-20} ", Convert.ToDouble(value, provider));
           }
           catch (FormatException e) {
              Console.WriteLine("{0,-20} ", e.GetType().Name);
           }
        }
    }
}
// The example displays the following output:
//       Default Culture: en-US
//       
//       String to Convert      Default/Exception    Provider/Exception
//       
//       123456789              123456789            123456789
//       12345.6789             12345.6789           123456789
//       12345,6789             123456789            12345.6789
//       123,456.789            123456.789           FormatException
//       123.456,789            FormatException      123456.789
//       123,456,789.0123       123456789.0123       FormatException
//       123.456.789,0123       FormatException      123456789.0123
// </Snippet2>
