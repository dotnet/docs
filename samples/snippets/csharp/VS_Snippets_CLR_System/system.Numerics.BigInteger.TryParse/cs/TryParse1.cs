using System;
using System.Globalization;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      // <Snippet2>
      string numericString;
      BigInteger number = BigInteger.Zero;
      
      // Call TryParse with default values of style and provider.
      numericString = "  -300   ";
      if (BigInteger.TryParse(numericString, NumberStyles.Integer, 
                             null, out number))
         Console.WriteLine("'{0}' was converted to {1}.", 
                           numericString, number);                    
      else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.", 
                           numericString);
      
      // Call TryParse with the default value of style and 
      // a provider supporting the tilde as negative sign.
      numericString = "  -300   ";
      if (BigInteger.TryParse(numericString, NumberStyles.Integer,
                             new BigIntegerFormatProvider(), out number))
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number);                             
      else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString);
      
      // Call TryParse with only AllowLeadingWhite and AllowTrailingWhite.
      // Method returns false because of presence of negative sign.
      numericString = "  -500   ";
      if (BigInteger.TryParse(numericString,
                              NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                              new BigIntegerFormatProvider(), out number))
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number);                             
      else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString);
      
      // Call TryParse with AllowHexSpecifier and a hex value.
      numericString = "F14237FFAAC086455192";
      if (BigInteger.TryParse(numericString,
                              NumberStyles.AllowHexSpecifier,
                              null, out number))
         Console.WriteLine("'{0}' was converted to {1} (0x{1:x}).",
                           numericString, number);                             
      else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString);
      
      // Call TryParse with AllowHexSpecifier and a negative hex value.
      // Conversion fails because of presence of negative sign.
      numericString = "-3af";
      if (BigInteger.TryParse(numericString, NumberStyles.AllowHexSpecifier,
                             new BigIntegerFormatProvider(), out number))
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number);       
      else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString);
      
      // Call TryParse with only NumberStyles.None.
      // Conversion fails because of presence of white space and sign.
      numericString = " -300 ";
      if (BigInteger.TryParse(numericString, NumberStyles.None,
                             new BigIntegerFormatProvider(), out number))
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number);         
      else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString);
                                                  
      // Call TryParse with NumberStyles.Any and a provider for the fr-FR culture.
      // Conversion fails because the string is formatted for the en-US culture.
      numericString = "9,031,425,666,123,546.00";
      if (BigInteger.TryParse(numericString, NumberStyles.Any,
                             new CultureInfo("fr-FR"), out number))
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number);                     
      else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString);
      
      // Call TryParse with NumberStyles.Any and a provider for the fr-FR culture.
      // Conversion succeeds because the string is properly formatted 
      // For the fr-FR culture.
      numericString = "9 031 425 666 123 546,00";
      if (BigInteger.TryParse(numericString, NumberStyles.Any,
                             new CultureInfo("fr-FR"), out number))
         Console.WriteLine("'{0}' was converted to {1}.",
                           numericString, number);                 
      else
         Console.WriteLine("Conversion of '{0}' to a BigInteger failed.",
                           numericString);
      // The example displays the following output:
      //    '  -300   ' was converted to -300.
      //    Conversion of '  -300   ' to a BigInteger failed.
      //    Conversion of '  -500   ' to a BigInteger failed.
      //    'F14237FFAAC086455192' was converted to -69613977002644837412462 (0xf14237ffaac086455192).
      //    Conversion of '-3af' to a BigInteger failed.
      //    Conversion of ' -300 ' to a BigInteger failed.
      //    Conversion of '9,031,425,666,123,546.00' to a BigInteger failed.
      //    '9 031 425 666 123 546,00' was converted to 9031425666123546.      
      // </Snippet2>
   }
}

// <Snippet3>
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
// </Snippet3>
