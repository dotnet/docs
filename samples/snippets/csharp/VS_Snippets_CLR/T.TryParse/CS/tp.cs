//<snippet1>
// This example demonstrates overloads of the TryParse method for
// several base types, and the TryParseExact method for DateTime.

// In most cases, this example uses the most complex overload; that is, the overload 
// with the most parameters for a particular type. If a complex overload specifies 
// null (Nothing in Visual Basic) for the IFormatProvider parameter, formatting 
// information is obtained from the culture associated with the current thread. 
// If a complex overload specifies the style parameter, the parameter value is 
// the default value used by the equivalent simple overload.

using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
    bool     success;
    CultureInfo ci;
    string   nl = Environment.NewLine;
    string   msg1 = 
             "This example demonstrates overloads of the TryParse method for{0}" +
             "several base types, as well as the TryParseExact method for DateTime.{0}";
    string   msg2 = "Non-numeric types:{0}";
    string   msg3 = "{0}Numeric types:{0}";
    string   msg4 = "{0}The following types are not CLS-compliant:{0}";

// Non-numeric types.
    Boolean  booleanVal;
    Char     charVal;
    DateTime datetimeVal;

// Numeric types.
    Byte     byteVal;
    Int16    int16Val;
    Int32    int32Val;
    Int64    int64Val;
    Decimal  decimalVal;
    Single   singleVal;
    Double   doubleVal;

// The following types are not CLS-compliant.
    SByte    sbyteVal;
    UInt16   uint16Val;
    UInt32   uint32Val;
    UInt64   uint64Val;
//
    Console.WriteLine(msg1, nl);

// Non-numeric types:
    Console.WriteLine(msg2, nl);
// DateTime
  // TryParse:
    // Assume current culture is en-US, and dates of the form: MMDDYYYY.
    success = DateTime.TryParse("7/4/2004 12:34:56", out datetimeVal);
    Show(success, "DateTime #1", datetimeVal.ToString());

    // Use fr-FR culture, and dates of the form: DDMMYYYY.
    ci = new CultureInfo("fr-FR");
    success = DateTime.TryParse("4/7/2004 12:34:56", 
             ci, DateTimeStyles.None, out datetimeVal);
    Show(success, "DateTime #2", datetimeVal.ToString());

  // TryParseExact:
    // Use fr-FR culture. The format, "G", is short date and long time.
    success = DateTime.TryParseExact("04/07/2004 12:34:56", "G", 
             ci, DateTimeStyles.None, out datetimeVal);
    Show(success, "DateTime #3", datetimeVal.ToString());

    // Assume en-US culture.
    string[] dateFormats = {"f", "F", "g", "G"};
    success = DateTime.TryParseExact("7/4/2004 12:34:56 PM", 
             dateFormats, null, DateTimeStyles.None, 
             out datetimeVal);
    Show(success, "DateTime #4", datetimeVal.ToString());

    Console.WriteLine();
// Boolean
    success = Boolean.TryParse("true", out booleanVal);
    Show(success, "Boolean", booleanVal.ToString());
// Char
    success = Char.TryParse("A", out charVal);
    Show(success, "Char", charVal.ToString());

// Numeric types:
    Console.WriteLine(msg3, nl);
// Byte
    success = Byte.TryParse("1", NumberStyles.Integer, null, out byteVal);
    Show(success, "Byte", byteVal.ToString());
// Int16
    success = Int16.TryParse("-2", NumberStyles.Integer, null, out int16Val);
    Show(success, "Int16", int16Val.ToString());
// Int32
    success = Int32.TryParse("3", NumberStyles.Integer, null, out int32Val);
    Show(success, "Int32", int32Val.ToString());
// Int64
    success = Int64.TryParse("4", NumberStyles.Integer, null, out int64Val);
    Show(success, "Int64", int64Val.ToString());
// Decimal
    success = Decimal.TryParse("-5.5", NumberStyles.Number, null, out decimalVal);
    Show(success, "Decimal", decimalVal.ToString());
// Single
    success = Single.TryParse("6.6", 
             (NumberStyles.Float | NumberStyles.AllowThousands), 
             null, out singleVal);
    Show(success, "Single", singleVal.ToString());
// Double
    success = Double.TryParse("-7", 
             (NumberStyles.Float | NumberStyles.AllowThousands), 
             null, out doubleVal);
    Show(success, "Double", doubleVal.ToString());

// Use the simple Double.TryParse overload, but specify an invalid value.

    success = Double.TryParse("abc", out doubleVal);
    Show(success, "Double #2", doubleVal.ToString());
//
    Console.WriteLine(msg4, nl);
// SByte
    success = SByte.TryParse("-8", NumberStyles.Integer, null, out sbyteVal);
    Show(success, "SByte", sbyteVal.ToString());
// UInt16
    success = UInt16.TryParse("9", NumberStyles.Integer, null, out uint16Val);
    Show(success, "UInt16", uint16Val.ToString());
// UInt32
    success = UInt32.TryParse("10", NumberStyles.Integer, null, out uint32Val);
    Show(success, "UInt32", uint32Val.ToString());
// UInt64
    success = UInt64.TryParse("11", NumberStyles.Integer, null, out uint64Val);
    Show(success, "UInt64", uint64Val.ToString());
    }

    protected static void Show(bool parseSuccess, string typeName, 
                               string parseValue)
    {
    string msgSuccess = "Parse for {0} = {1}";
    string msgFailure = "** Parse for {0} failed. Invalid input.";
//
    if (parseSuccess == true)
        Console.WriteLine(msgSuccess, typeName, parseValue);
    else
        Console.WriteLine(msgFailure, typeName);
   }
}
/*
This example produces the following results:

This example demonstrates overloads of the TryParse method for
several base types, as well as the TryParseExact method for DateTime.

Non-numeric types:

Parse for DateTime #1 = 7/4/2004 12:34:56 PM
Parse for DateTime #2 = 7/4/2004 12:34:56 PM
Parse for DateTime #3 = 7/4/2004 12:34:56 PM
Parse for DateTime #4 = 7/4/2004 12:34:56 PM

Parse for Boolean = True
Parse for Char = A

Numeric types:

Parse for Byte = 1
Parse for Int16 = -2
Parse for Int32 = 3
Parse for Int64 = 4
Parse for Decimal = -5.5
Parse for Single = 6.6
Parse for Double = -7
** Parse for Double #2 failed. Invalid input.

The following types are not CLS-compliant:

Parse for SByte = -8
Parse for UInt16 = 9
Parse for UInt32 = 10
Parse for UInt64 = 11
*/
//</snippet1>
