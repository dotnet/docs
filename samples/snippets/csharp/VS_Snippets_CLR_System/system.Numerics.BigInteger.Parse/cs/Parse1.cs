using System;
using System.Globalization;
using System.Numerics;

public class ParseModule
{
    public static void Main()
    {
      Console.WriteLine("BigInteger.Parse(String)-------------");
      ParseString();
      Console.WriteLine("----------");
      Console.WriteLine("BigInteger.Parse(String, NumberStyles, IFormatProvider)----------");
      ParseWithStyleAndProvider();
      Console.WriteLine();
   }
   
   private static void ParseString()
   {
      // <Snippet1>
      string stringToParse = String.Empty;
      try
      {
         // Parse two strings.
         string string1, string2;
         string1 = "12347534159895123";
         string2 = "987654321357159852";
         stringToParse = string1;
         BigInteger number1 = BigInteger.Parse(stringToParse);
         Console.WriteLine("Converted '{0}' to {1:N0}.", stringToParse, number1);        
         stringToParse = string2;
         BigInteger number2 = BigInteger.Parse(stringToParse);
         Console.WriteLine("Converted '{0}' to {1:N0}.", stringToParse, number2);
         // Perform arithmetic operations on the two numbers.
         number1 *= 3;
         number2 *= 2;
         // Compare the numbers.
         int result = BigInteger.Compare(number1, number2);
         switch (result)
         {
            case -1:
               Console.WriteLine("{0} is greater than {1}.", number2, number1);
               break;
            case 0:
               Console.WriteLine("{0} is equal to {1}.", number1, number2);
               break;
            case 1:
               Console.WriteLine("{0} is greater than {1}.", number1, number2);
               break;
         }      
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse {0}.", stringToParse);
      }
      // The example displays the following output:
      //    Converted '12347534159895123' to 12,347,534,159,895,123.
      //    Converted '987654321357159852' to 987,654,321,357,159,852.
      //    1975308642714319704 is greater than 37042602479685369.      
      // </Snippet1>     
   }   

   private static void ParseWithStyleAndProvider()
   {
      // <Snippet2>
      // Call parse with default values of style and provider
      Console.WriteLine(BigInteger.Parse("  -300   ", 
                        NumberStyles.Integer, CultureInfo.CurrentCulture));
      // Call parse with default values of style and provider supporting tilde as negative sign
      Console.WriteLine(BigInteger.Parse("   ~300  ", 
                                         NumberStyles.Integer, new BigIntegerFormatProvider()));
      // Call parse with only AllowLeadingWhite and AllowTrailingWhite
      // Exception thrown because of presence of negative sign
      try
      {
         Console.WriteLine(BigInteger.Parse("    ~300   ", 
                                      NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, 
                                      new BigIntegerFormatProvider()));
      }
      catch (FormatException e)
      {
         Console.WriteLine("{0}: \n   {1}", e.GetType().Name, e.Message);
      }                                   
      // Call parse with only AllowHexSpecifier
      // Exception thrown because of presence of negative sign
      try
      {
         Console.WriteLine(BigInteger.Parse("-3af", NumberStyles.AllowHexSpecifier, 
                                            new BigIntegerFormatProvider()));
      }
      catch (FormatException e)
      {
         Console.WriteLine("{0}: \n   {1}", e.GetType().Name, e.Message);
      }                                 
      // Call parse with only NumberStyles.None
      // Exception thrown because of presence of white space and sign
      try
      {
         Console.WriteLine(BigInteger.Parse(" -300 ", NumberStyles.None, 
                                            new BigIntegerFormatProvider()));
      }
      catch (FormatException e)
      {
         Console.WriteLine("{0}: \n   {1}", e.GetType().Name, e.Message);
      }
      // The example displays the followingoutput:
      //       -300
      //       -300
      //       FormatException:
      //          The value could not be parsed.
      //       FormatException:
      //          The value could not be parsed.
      //       FormatException:
      //          The value could not be parsed.      
      // </Snippet2>                           
   }
}

// <Snippet4>
public class BigIntegerFormatProvider : IFormatProvider
{
   public object GetFormat(Type formatType) 
   {
      if (formatType == typeof(NumberFormatInfo)) 
      {
         NumberFormatInfo numberFormat = new NumberFormatInfo();
         numberFormat.NegativeSign = "~";
         return numberFormat;
      }
      else
      {
         return null;
      }      
   }
}
// </Snippet4>