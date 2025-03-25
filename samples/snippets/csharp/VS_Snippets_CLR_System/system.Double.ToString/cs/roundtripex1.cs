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
      Console.WriteLine($"{initialValue:R} = {roundTripped:R}: {initialValue.Equals(roundTripped)}\n");

      Console.WriteLine("Attempting to round-trip a Double with 'G17':");
      string valueString17 = initialValue.ToString("G17",
                                                   CultureInfo.InvariantCulture);
      double roundTripped17 = double.Parse(valueString17,
                                           CultureInfo.InvariantCulture);
      Console.WriteLine($"{initialValue:R} = {roundTripped17:R}: {initialValue.Equals(roundTripped17)}\n");
      // If compiled to an application that targets anycpu or x64 and run on an x64 system,
      // the example displays the following output:
      //       Attempting to round-trip a Double with 'R':
      //       .NET Framework:
      //       0.6822871999174 = 0.68228719991740006: False
      //       .NET:
      //       0.6822871999174 = 0.6822871999174: True
      //
      //       Attempting to round-trip a Double with 'G17':
      //       0.6822871999174 = 0.6822871999174: True
      // </SnippetRoundTrip>
   }
}
// </Snippet5>
