// Interceptor2.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet11>
using namespace System;
using namespace System::Globalization;

ref class InterceptProvider : IFormatProvider, ICustomFormatter
{
public:
   virtual Object^ GetFormat(Type^ formatType)
   {
      if (formatType == ICustomFormatter::typeid)   
         return this;
      else
         return nullptr;
   }
   
   virtual String^ Format(String^ format, Object^ obj, IFormatProvider^ provider) 
   {
      // Display information about method call.
      String^ formatString = format != nullptr ? format : "<null>";
      Console::WriteLine("Provider: {0}, Object: {1}, Format String: {2}",
                        provider, obj != nullptr ? obj : "<null>", formatString);
                        
      if (obj == nullptr) return String::Empty;
            
      // If this is a byte and the "R" format string, format it with Roman numerals.
      if (obj->GetType() == Byte::typeid && formatString->ToUpper()->Equals("R")) {
         Byte value = (Byte) obj;
         int remainder;
         int result;
         String^ returnString = String::Empty;

         // Get the hundreds digit(s)
         result = Math::DivRem(value, 100, remainder);
         if (result > 0)  
            returnString = gcnew String('C', result);
         value = (Byte) remainder;
         // Get the 50s digit
         result = Math::DivRem(value, 50, remainder);
         if (result == 1)
            returnString += "L";
         value = (Byte) remainder;
         // Get the tens digit.
         result = Math::DivRem(value, 10, remainder);
         if (result > 0)
            returnString += gcnew String('X', result);
         value = (Byte) remainder; 
         // Get the fives digit.
         result = Math::DivRem(value, 5, remainder);
         if (result > 0)
            returnString += "V";
         value = (Byte) remainder;
         // Add the ones digit.
         if (remainder > 0) 
            returnString += gcnew String('I', remainder);
         
         // Check whether we have too many X characters.
         int pos = returnString->IndexOf("XXXX");
         if (pos >= 0) {
            int xPos = returnString->IndexOf("L"); 
            if ((xPos >= 0) & (xPos == pos - 1))
               returnString = returnString->Replace("LXXXX", "XC");
            else
               returnString = returnString->Replace("XXXX", "XL");   
         }
         // Check whether we have too many I characters
         pos = returnString->IndexOf("IIII");
         if (pos >= 0)
            if (returnString->IndexOf("V") >= 0)
               returnString = returnString->Replace("VIIII", "IX");
            else
               returnString = returnString->Replace("IIII", "IV");    

         return returnString; 
      }   

      // Use default for all other formatting.
      if (obj->GetType() == IFormattable::typeid)
         return ((IFormattable^) obj)->ToString(format, CultureInfo::CurrentCulture);
      else
         return obj->ToString();
   }
};

void main()
{
   int n = 10;
   double value = 16.935;
   DateTime day = DateTime::Now;
   InterceptProvider^ provider = gcnew InterceptProvider();
   Console::WriteLine(String::Format(provider, "{0:N0}: {1:C2} on {2:d}\n", n, value, day));
   Console::WriteLine(String::Format(provider, "{0}: {1:F}\n", "Today: ", 
                                    (DayOfWeek) DateTime::Now.DayOfWeek));
   Console::WriteLine(String::Format(provider, "{0:X}, {1}, {2}\n", 
                                    (Byte) 2, (Byte) 12, (Byte) 199));
   Console::WriteLine(String::Format(provider, "{0:R}, {1:R}, {2:R}\n", 
                                    (Byte) 2, (Byte) 12, (Byte) 199));
}
// The example displays the following output:
//    Provider: InterceptProvider, Object: 10, Format String: N0
//    Provider: InterceptProvider, Object: 16.935, Format String: C2
//    Provider: InterceptProvider, Object: 1/31/2013 6:10:28 PM, Format String: d
//    10: $16.94 on 1/31/2013
//    
//    Provider: InterceptProvider, Object: Today: , Format String: <null>
//    Provider: InterceptProvider, Object: Thursday, Format String: F
//    Today: : Thursday
//    
//    Provider: InterceptProvider, Object: 2, Format String: X
//    Provider: InterceptProvider, Object: 12, Format String: <null>
//    Provider: InterceptProvider, Object: 199, Format String: <null>
//    2, 12, 199
//    
//    Provider: InterceptProvider, Object: 2, Format String: R
//    Provider: InterceptProvider, Object: 12, Format String: R
//    Provider: InterceptProvider, Object: 199, Format String: R
//    II, XII, CXCIX
// </Snippet11>