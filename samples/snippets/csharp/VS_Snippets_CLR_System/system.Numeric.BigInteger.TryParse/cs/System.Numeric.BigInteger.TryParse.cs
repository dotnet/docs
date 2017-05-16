using System;
using System.Globalization;
using System.Numerics;

public class TryParse
{
   public static void Main()
   {
      TryParse tp = new TryParse();
      tp.TryParse1();
      Console.WriteLine();
      tp.TryParse2();
   }

   private void TryParse1()
   {
      // <Snippet1>
      BigInteger number1, number2;
      bool succeeded1 = BigInteger.TryParse("-12347534159895123", out number1);
      bool succeeded2 = BigInteger.TryParse("987654321357159852", out number2);
      if (succeeded1 && succeeded2)
      {
         number1 *= 3;
         number2 *= 2;
         switch (BigInteger.Compare(number1, number2))
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
      else
      {
         if (! succeeded1) 
            Console.WriteLine("Unable to initialize the first BigInteger value.");

         if (! succeeded2)
            Console.WriteLine("Unable to initialize the second BigInteger value.");
      }
      // The example displays the following output:
      //      1975308642714319704 is greater than -37042602479685369.
      // </Snippet1>     
   }

   private void TryParse2()
   {
      // <Snippet2>
      string numericString;
      BigInteger number;

      // Call parse with default values of style and provider
      numericString = "  -300   ";
      if (BigInteger.TryParse(numericString, NumberStyles.Integer, 
                             CultureInfo.CurrentCulture, out number))
         Console.WriteLine("The string '{0}' parses to {1}", 
                           numericString, number);                             
      else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", 
                           numericString);

      // Call parse with default values of style and provider supporting tilde as negative sign
      numericString = "  -300   ";
      if (BigInteger.TryParse(numericString, NumberStyles.Integer, 
                             new BigIntegerFormatProvider(), out number)) 
         Console.WriteLine("The string '{0}' parses to {1}", 
                           numericString, number);                             
      else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", 
                           numericString);
                             
      // Call parse with only AllowLeadingWhite and AllowTrailingWhite
      // Method returns false because of presence of negative sign
      numericString = "  -500   ";
      if (BigInteger.TryParse(numericString, 
                          NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, 
                          new BigIntegerFormatProvider(), out number))
         Console.WriteLine("The string '{0}' parses to {1}", 
                           numericString, number);                             
      else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", 
                           numericString);
                           
      // Call parse with AllowHexSpecifier and a hex value
      numericString = "FFAAC086455192";
      if (BigInteger.TryParse(numericString, NumberStyles.AllowHexSpecifier, 
                             null, out number))
         Console.WriteLine("The string '{0}' parses to {1}, or 0x{1:x}.", 
                           numericString, number);                             
      else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", 
                           numericString);
                          
      // Call parse with AllowHexSpecifier and a negative hex value
      // Conversion fails because of presence of negative sign
      numericString = "-3af";
      if (BigInteger.TryParse(numericString, NumberStyles.AllowHexSpecifier, 
                             new BigIntegerFormatProvider(), out number))
         Console.WriteLine("The string '{0}' parses to {1}.", 
                           numericString, number);                             
      else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", 
                           numericString);

      // Call parse with only NumberStyles.None
      // Exception thrown because of presence of white space and sign
      numericString = " -300 ";
      if (BigInteger.TryParse(numericString, NumberStyles.None, 
                             new BigIntegerFormatProvider(), out number))
         Console.WriteLine("The string '{0}' parses to {1}", 
                           numericString, number);                             
      else
         Console.WriteLine("Conversion of {0} to a BigInteger failed.", 
                           numericString);
      // <</Snippet2>                           
   }
}

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
