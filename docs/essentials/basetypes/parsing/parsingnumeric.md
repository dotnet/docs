# Parsing Numeric Strings in .NET Core

All numeric types have two static parsing methods, `Parse` and `TryParse`, that you can use to convert the string representation of a number into a numeric type. These methods enable you to parse strings that were produced by using the format strings documented in [Standard Numeric Format Strings](../standardnumeric.md) and [Custom Numeric Format Strings](../customnumeric.md). By default, the `Parse` and `TryParse` methods can successfully convert strings that contain integral decimal digits only to integer values. They can successfully convert strings that contain integral and fractional decimal digits, group separators, and a decimal separator to floating-point values. The `Parse` method throws an exception if the operation fails, whereas the `TryParse` method returns `false`.

## Parsing and Format Providers

Typically, the string representations of numeric values differ by culture. Elements of numeric strings such as currency symbols, group (or thousands) separators, and decimal separators all vary by culture. Parsing methods either implicitly or explicitly use a format provider that recognizes these culture-specific variations. If no format provider is specified in a call to the `Parse` or `TryParse` method, the format provider associated with the current thread culture (the [NumberFormatInfo](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) object returned by the [NumberFormatInfo.CurrentInfo](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrentInfo) property) is used. 

A format provider is represented by an [IFormatProvider](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrentInfo) implementation. This interface has a single member, the [GetFormat](https://dotnet.github.io/api/System.IFormatProvider.html#System_IFormatProvider_GetFormat_System_Type_) method, whose single parameter is a [Type](https://dotnet.github.io/api/System.Type.html) object that represents the type to be formatted. This method returns the object that provides formatting information. .NET Core supports the following two [IFormatProvider](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrentInfo) implementations for parsing numeric strings:

* A [CultureInfo](https://dotnet.github.io/api/System.Globalization.CultureInfo.html) object whose [CultureInfo.GetFormat](https://dotnet.github.io/api/System.Globalization.CultureInfo.html#System_Globalization_CultureInfo_GetFormat_System_Type_) method returns a [NumberFormatInfo](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) object that provides culture-specific formatting information.

* A [NumberFormatInfo](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) object whose [NumberFormatInfo.GetFormat](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_GetFormat_System_Type_) method returns itself.

The following example tries to convert each string in an array to a [Double](https://dotnet.github.io/api/System.Double.html) value. It first tries to parse the string by using a format provider that reflects the conventions of the English (United States) culture. If this operation throws a [FormatException](https://dotnet.github.io/api/System.FormatException.html), it tries to parse the string by using a format provider that reflects the conventions of the French (France) culture.

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] values = { "1,304.16", "$1,456.78", "1,094", "152", 
                          "123,45 €", "1 304,16", "Ae9f" };
      double number;
      CultureInfo culture = null;

      foreach (string value in values) {
         try {
            culture = CultureInfo.CreateSpecificCulture("en-US");
            number = Double.Parse(value, culture);
            Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
         }   
         catch (FormatException) {
            Console.WriteLine("{0}: Unable to parse '{1}'.", 
                              culture.Name, value);
            culture = CultureInfo.CreateSpecificCulture("fr-FR");
            try {
               number = Double.Parse(value, culture);
               Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
            }
            catch (FormatException) {
               Console.WriteLine("{0}: Unable to parse '{1}'.", 
                                 culture.Name, value);
            }
         }
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//    en-US: 1,304.16 --> 1304.16
//    
//    en-US: Unable to parse '$1,456.78'.
//    fr-FR: Unable to parse '$1,456.78'.
//    
//    en-US: 1,094 --> 1094
//    
//    en-US: 152 --> 152
//    
//    en-US: Unable to parse '123,45 €'.
//    fr-FR: Unable to parse '123,45 €'.
//    
//    en-US: Unable to parse '1 304,16'.
//    fr-FR: 1 304,16 --> 1304.16
//    
//    en-US: Unable to parse 'Ae9f'.
//    fr-FR: Unable to parse 'Ae9f'.
```

## Parsing and NumberStyles Values

The style elements (such as white space, group separators, and decimal separator) that the parse operation can handle are defined by a [NumberStyles](https://dotnet.github.io/api/System.Globalization.NumberStyles.html) enumeration value. By default, strings that represent integer values are parsed by using the [NumberStyles.Integer](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_Integer) value, which permits only numeric digits, leading and trailing white space, and a leading sign. Strings that represent floating-point values are parsed using a combination of the [NumberStyles.Float](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_Float) and [NumberStyles.AllowThousands](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowThousands) values; this composite style permits decimal digits along with leading and trailing white space, a leading sign, a decimal separator, a group separator, and an exponent. By calling an overload of the `Parse` or `TryParse` method that includes a parameter of type [NumberStyles](https://dotnet.github.io/api/System.Globalization.NumberStyles.html) and setting one or more [NumberStyles](https://dotnet.github.io/api/System.Globalization.NumberStyles.html) flags, you can control the style elements that can be present in the string for the parse operation to succeed. 

For example, a string that contains a group separator cannot be converted to an [Int32](https://dotnet.github.io/api/System.Int32.html) value by using the [Int32.Parse(String)](https://dotnet.github.io/api/System.Int32.html#System_Int32_Parse_System_String_) method. However, the conversion succeeds if you use the [NumberStyles.AllowThousands](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowThousands) flag, as the following example illustrates.

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string value = "1,304";
      int number;
      IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
      if (Int32.TryParse(value, out number))
         Console.WriteLine("{0} --> {1}", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'", value);

      if (Int32.TryParse(value, NumberStyles.Integer | NumberStyles.AllowThousands, 
                        provider, out number))
         Console.WriteLine("{0} --> {1}", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'", value);
   }
}
// The example displays the following output:
//       Unable to convert '1,304'
//       1,304 --> 1304
```

> **Warning**
>
> The parse operation always uses the formatting conventions of a particular culture. If you do not specify a culture by passing a [CultureInfo](https://dotnet.github.io/api/System.Globalization.CultureInfo.html) or [NumberFormatInfo](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) object, the culture associated with the current thread is used.
 
The following table lists the members of the [NumberStyles](https://dotnet.github.io/api/System.Globalization.NumberStyles.html) enumeration and describes the effect that they have on the parsing operation.

NumberStyles value | Effect on the string to be parsed
------------------ | --------------------------------- 
[NumberStyles.None](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_None) | Only numeric digits are permitted.
[NumberStyles.AllowDecimalPoint](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowDecimalPoint) | The decimal separator and fractional digits are permitted. For integer values, only zero is permitted as a fractional digit. Valid decimal separators are determined by the [NumberFormatInfo.NumberDecimalSeparator](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberDecimalSeparator) or [NumberFormatInfo.CurrencyDecimalSeparator](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyDecimalSeparator) property.
[NumberStyles.AllowExponent](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowExponent) | The "e" or "E" character can be used to indicate exponential notation.
[NumberStyles.AllowLeadingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowLeadingWhite) | Leading white space is permitted.
[NumberStyles.AllowTrailingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowTrailingWhite) | Trailing white space is permitted.
[NumberStyles.AllowLeadingSign](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowLeadingSign) | A positive or negative sign can precede numeric digits.
[NumberStyles.AllowTrailingSign](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowTrailingSign) | A positive or negative sign can follow numeric digits.
[NumberStyles.AllowParentheses](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowParentheses) | Parentheses can be used to indicate negative values.
[NumberStyles.AllowThousands](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowThousands) | The group separator is permitted. The group separator character is determined by the [NumberFormatInfo.NumberGroupSeparator](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_NumberGroupSeparator) or [NumberFormatInfo.CurrencyGroupSeparator](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencyGroupSeparator) property.
[NumberStyles.AllowCurrencySymbol](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowCurrencySymbol) | The currency symbol is permitted. The currency symbol is defined by the [NumberFormatInfo.CurrencySymbol](https://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html#System_Globalization_NumberFormatInfo_CurrencySymbol) property.
[NumberStyles.AllowHexSpecifier](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowHexSpecifier) | The string to be parsed is interpreted as a hexadecimal number. It can include the hexadecimal digits 0-9, A-F, and a-f. This flag can be used only to parse integer values.
 
In addition, the [NumberStyles](https://dotnet.github.io/api/System.Globalization.NumberStyles.html) enumeration provides the following composite styles, which include multiple [NumberStyles](https://dotnet.github.io/api/System.Globalization.NumberStyles.html) flags. 

Composite NumberStyles value | Includes members
---------------------------- | ---------------- 
[NumberStyles.Integer](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_Integer) | Includes the [NumberStyles.AllowLeadingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowLeadingWhite), [NumberStyles.AllowTrailingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowTrailingWhite), and [NumberStyles.AllowLeadingSign](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowLeadingSign) styles. This is the default style used to parse integer values.
[NumberStyles.Number](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_Number) | Includes the [NumberStyles.AllowLeadingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowLeadingWhite), [NumberStyles.AllowTrailingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowTrailingWhite), [NumberStyles.AllowLeadingSign](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowLeadingSign), [NumberStyles.AllowTrailingSign](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowTrailingSign), [NumberStyles.AllowDecimalPoint](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowDecimalPoint), and [NumberStyles.AllowThousands](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowThousands) styles.
[NumberStyles.Float](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_Float) | Includes the [NumberStyles.AllowLeadingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowLeadingWhite), [NumberStyles.AllowTrailingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowTrailingWhite), [NumberStyles.AllowLeadingSign](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowLeadingSign), [NumberStyles.AllowDecimalPoint](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowDecimalPoint), and [NumberStyles.AllowExponent](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowExponent) styles.
[NumberStyles.Currency](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_Currency) | Includes all styles except [NumberStyles.AllowExponent](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowExponent) and [NumberStyles.AllowHexSpecifier](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowHexSpecifier).
[NumberStyles.Any](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_Any) | Includes all styles except [NumberStyles.AllowHexSpecifier](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowHexSpecifier).
[NumberStyles.HexNumber](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_HexNumber) | Includes the [NumberStyles.AllowLeadingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowLeadingWhite), [NumberStyles.AllowTrailingWhite](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowTrailingWhite), and [NumberStyles.AllowHexSpecifier](https://dotnet.github.io/api/System.Globalization.NumberStyles.html#System_Globalization_NumberStyles_AllowHexSpecifier) styles.
 
## Parsing and Unicode Digits

The Unicode standard defines code points for digits in various writing systems. For example, code points from U+0030 to U+0039 represent the basic Latin digits 0 through 9, code points from U+09E6 to U+09EF represent the Bangla digits 0 through 9, and code points from U+FF10 to U+FF19 represent the Fullwidth digits 0 through 9. However, the only numeric digits recognized by parsing methods are the basic Latin digits 0-9 with code points from U+0030 to U+0039. If a numeric parsing method is passed a string that contains any other digits, the method throws a [FormatException](https://dotnet.github.io/api/System.FormatException.html).

The following example uses the [Int32.Parse](https://dotnet.github.io/api/System.Int32.html#System_Int32_Parse_System_String_) method to parse strings that consist of digits in different writing systems. As the output from the example shows, the attempt to parse the basic Latin digits succeeds, but the attempt to parse the Fullwidth, Arabic-Indic, and Bangla digits fails.

```csharp
using System;

public class Example
{
   public static void Main()
   {
      string value;
      // Define a string of basic Latin digits 1-5.
      value = "\u0031\u0032\u0033\u0034\u0035";
      ParseDigits(value);

      // Define a string of Fullwidth digits 1-5.
      value = "\uFF11\uFF12\uFF13\uFF14\uFF15";
      ParseDigits(value);

      // Define a string of Arabic-Indic digits 1-5.
      value = "\u0661\u0662\u0663\u0664\u0665";
      ParseDigits(value);

      // Define a string of Bangla digits 1-5.
      value = "\u09e7\u09e8\u09e9\u09ea\u09eb";
      ParseDigits(value);
   }

   static void ParseDigits(string value)
   {
      try {
         int number = Int32.Parse(value);
         Console.WriteLine("'{0}' --> {1}", value, number);
      }   
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", value);      
      }     
   }
}
// The example displays the following output:
//       '12345' --> 12345
//       Unable to parse '１２３４５'.
//       Unable to parse '١٢٣٤٥'.
//       Unable to parse '১২৩৪৫'.
```

## See Also

[System.Globalization.NumberStyles](https://dotnet.github.io/api/System.Globalization.NumberStyles.html)

[Parsing Strings in .NET Core](../parsingstrings.md)

[Formatting Types in .NET Core](../formattingtypes.md)

