// Convert.ChangeType00.cpp : main project file.

// <Snippet1>
using namespace System;
using namespace System::Globalization;

ref class InterceptProvider : IFormatProvider
{
public: 
   virtual Object^ GetFormat(Type^ formatType) 
   {
      CultureInfo^ culture;
      if (formatType == NumberFormatInfo::typeid) {
         Console::WriteLine("   Returning a fr-FR numeric format provider.");
         
         culture = gcnew CultureInfo("fr-FR");
         return culture->NumberFormat;
      }  
      else if (formatType == DateTimeFormatInfo::typeid) {
         Console::WriteLine("   Returning an en-US date/time format provider.");
         culture = gcnew CultureInfo("en-US");
         return culture->DateTimeFormat;
      }
      else {
         Console::WriteLine("   Requesting a format provider of {0}.", formatType->Name);
         return nullptr;
      }
   }
};

void main()
{
   array<Object^>^ values = gcnew array<Object^> { 103.5, gcnew DateTime(2010, 12, 26, 14, 34, 0) };
   IFormatProvider^ provider = gcnew InterceptProvider();
      
   // Convert value to each of the types represented in TypeCode enum.
   for each (Object^ value in values)
   {
      // Iterate types in TypeCode enum.
      for each (TypeCode enumType in (array<TypeCode>^) Enum::GetValues(TypeCode::typeid))
      {         
         if (enumType == TypeCode::DBNull || enumType == TypeCode::Empty) continue;
            
         try {
            Console::WriteLine("{0} ({1}) --> {2} ({3}).", 
                              value, value->GetType()->Name,
                              Convert::ChangeType(value, enumType, provider),
                              enumType.ToString());
         }
         catch (InvalidCastException^ e) {
            Console::WriteLine("Cannot convert a {0} to a {1}",
                              value->GetType()->Name, enumType.ToString());
         }                     
         catch (OverflowException^ e) {
            Console::WriteLine("Overflow: {0} is out of the range of a {1}",
                              value, enumType.ToString());
         }
      }
      Console::WriteLine();
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
