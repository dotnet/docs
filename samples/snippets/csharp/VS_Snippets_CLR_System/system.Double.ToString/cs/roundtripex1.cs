// <Snippet5>
using System;
using System.Globalization;

public class Example
{
   static void Main(string[] args)
   {
      // <SnippetRoundTrip>
      Console.WriteLine("Attempting to round-trip a Double with 'R':");
      double initialValue = 0.6822871999174;
      string valueString = initialValue.ToString("R",
                                                 CultureInfo.InvariantCulture);
      double roundTripped = double.Parse(valueString,
                                         CultureInfo.InvariantCulture);
      Console.WriteLine("{0:R} = {1:R}: {2}\n",
                        initialValue, roundTripped, initialValue.Equals(roundTripped));

      Console.WriteLine("Attempting to round-trip a Double with 'G17':");
      string valueString17 = initialValue.ToString("G17",
                                                   CultureInfo.InvariantCulture);
      double roundTripped17 = double.Parse(valueString17,
                                           CultureInfo.InvariantCulture);
      Console.WriteLine("{0:R} = {1:R}: {2}\n",
                        initialValue, roundTripped17, initialValue.Equals(roundTripped17));
      // If compiled to an application that targets anycpu or x64 and run on an x64 system,
      // the example displays the following output:
      //       Attempting to round-trip a Double with 'R':
      //       0.6822871999174 = 0.68228719991740006: False
      //
      //       Attempting to round-trip a Double with 'G17':
      //       0.6822871999174 = 0.6822871999174: True
      // </SnippetRoundTrip>
   }
}
// </Snippet5>
