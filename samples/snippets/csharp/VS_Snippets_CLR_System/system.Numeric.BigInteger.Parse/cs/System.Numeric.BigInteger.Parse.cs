using System;
using System.Globalization;
using System.Numerics;

public class ParseModule
{
    public static void Main()
    {
       ParseModule pm = new ParseModule();
       pm.ParseString();
       Console.WriteLine();
       pm.ParseStringWithIFormatProvider();
       Console.WriteLine();
       pm.ParseWithCustomIFormatProvider();
       Console.WriteLine();
       pm.ParseWithStyle();
       pm.ParseOverload4();
    }
   
   private void ParseString()
   {
      // <Snippet1>
      try
      {
         // <Snippet7>
         BigInteger number1 = BigInteger.Parse("12347534159895123");
         BigInteger number2 = BigInteger.Parse("987654321357159852");
         // </Snippet7>
         number1 *= 3;
         number2 *= 2;
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
         Console.WriteLine("Unable to initialize integer because of invalid format in string.");
      }
      // </Snippet1>     
   }   

   private void ParseStringWithIFormatProvider()
   {
       // <Snippet4>
      NumberFormatInfo fmt = new NumberFormatInfo();
      fmt.NegativeSign = "~";
      
      BigInteger number = BigInteger.Parse("~6354129876", fmt);
      // Display value using same formatting information
      Console.WriteLine(number.ToString(fmt));
      // Display value using formatting of current culture
      Console.WriteLine(number);
      // </Snippet4>
   }
   
   private void ParseWithCustomIFormatProvider()
   {
      // <Snippet3>
      BigInteger number = BigInteger.Parse("~6354129876", new BigIntegerFormatProvider());
      // Display value using same formatting information
      Console.WriteLine(number.ToString(new BigIntegerFormatProvider()));
      // Display value using formatting of current culture
      Console.WriteLine(number);
      // </Snippet3>
   }

   private void ParseWithStyle()
   {
      // <Snippet5>
      BigInteger number; 
      // Method should succeed (white space and sign allowed)
      number = BigInteger.Parse("   -68054   ", NumberStyles.Integer);
      Console.WriteLine(number);
      // Method should succeed (string interpreted as hexadecimal)
      number = BigInteger.Parse("68054", NumberStyles.AllowHexSpecifier);
      Console.WriteLine(number);
      // Method call should fail: sign not allowed
      try
      {
         number = BigInteger.Parse("   -68054  ", NumberStyles.AllowLeadingWhite 
                                                  | NumberStyles.AllowTrailingWhite);
         Console.WriteLine(number);
      }   
      catch (FormatException e)
      {
         Console.WriteLine(e.Message);
      }                                                     
      // Method call should fail: white space not allowed
      try
      {
         number = BigInteger.Parse("   68054  ", NumberStyles.AllowLeadingSign);
         Console.WriteLine(number);
      }
      catch (FormatException e)
      {
         Console.WriteLine(e.Message);
      }    
      //
      // The method produces the following output:
      //
      //     -68054
      //     426068
      //     Input string was not in a correct format.
      //     Input string was not in a correct format.                                                 
      // </Snippet5>
   }

   private void ParseOverload4()
   {
      // <Snippet6>
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
      // <</Snippet6>                           
   }
}

// <Snippet2>
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
// </Snippet2>
