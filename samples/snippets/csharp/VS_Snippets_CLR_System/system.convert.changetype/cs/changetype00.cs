// <Snippet1>
using System;
using System.Globalization;

public class InterceptProvider : IFormatProvider
{
   public object GetFormat(Type formatType) 
   {
      if (formatType == typeof(NumberFormatInfo)) {
         Console.WriteLine("   Returning a fr-FR numeric format provider.");
         return new System.Globalization.CultureInfo("fr-FR").NumberFormat;
      }   
      else if (formatType == typeof(DateTimeFormatInfo)) {
         Console.WriteLine("   Returning an en-US date/time format provider.");
         return new System.Globalization.CultureInfo("en-US").DateTimeFormat;
      }
      else {
         Console.WriteLine("   Requesting a format provider of {0}.", formatType.Name);
         return null;
      }
   }
}

public class Example
{
   public static void Main()
   {
      object[] values = { 103.5d, new DateTime(2010, 12, 26, 14, 34, 0) };
      IFormatProvider provider = new InterceptProvider();
      
      // Convert value to each of the types represented in TypeCode enum.
      foreach (object value in values)
      {
         // Iterate types in TypeCode enum.
         foreach (TypeCode enumType in ((TypeCode[]) Enum.GetValues(typeof(TypeCode))))
         {         
            if (enumType == TypeCode.DBNull || enumType == TypeCode.Empty) continue;
            
            try {
               Console.WriteLine("{0} ({1}) --> {2} ({3}).", 
                                 value, value.GetType().Name,
                                 Convert.ChangeType(value, enumType, provider),
                                 enumType.ToString());
            }
            catch (InvalidCastException) {
               Console.WriteLine("Cannot convert a {0} to a {1}",
                                 value.GetType().Name, enumType.ToString());
            }                     
            catch (OverflowException) {
               Console.WriteLine("Overflow: {0} is out of the range of a {1}",
                                 value, enumType.ToString());
            }
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//    103.5 (Double) --> 103.5 (Object).
//    103.5 (Double) --> True (Boolean).
//    Cannot convert a Double to a Char
//    103.5 (Double) --> 104 (SByte).
//    103.5 (Double) --> 104 (Byte).
//    103.5 (Double) --> 104 (Int16).
//    103.5 (Double) --> 104 (UInt16).
//    103.5 (Double) --> 104 (Int32).
//    103.5 (Double) --> 104 (UInt32).
//    103.5 (Double) --> 104 (Int64).
//    103.5 (Double) --> 104 (UInt64).
//    103.5 (Double) --> 103.5 (Single).
//    103.5 (Double) --> 103.5 (Double).
//    103.5 (Double) --> 103.5 (Decimal).
//    Cannot convert a Double to a DateTime
//       Returning a fr-FR numeric format provider.
//    103.5 (Double) --> 103,5 (String).
//    
//    12/26/2010 2:34:00 PM (DateTime) --> 12/26/2010 2:34:00 PM (Object).
//    Cannot convert a DateTime to a Boolean
//    Cannot convert a DateTime to a Char
//    Cannot convert a DateTime to a SByte
//    Cannot convert a DateTime to a Byte
//    Cannot convert a DateTime to a Int16
//    Cannot convert a DateTime to a UInt16
//    Cannot convert a DateTime to a Int32
//    Cannot convert a DateTime to a UInt32
//    Cannot convert a DateTime to a Int64
//    Cannot convert a DateTime to a UInt64
//    Cannot convert a DateTime to a Single
//    Cannot convert a DateTime to a Double
//    Cannot convert a DateTime to a Decimal
//    12/26/2010 2:34:00 PM (DateTime) --> 12/26/2010 2:34:00 PM (DateTime).
//       Returning an en-US date/time format provider.
//    12/26/2010 2:34:00 PM (DateTime) --> 12/26/2010 2:34:00 PM (String).
// </Snippet1>
