void main()
{     
   Temperature^ cool = gcnew Temperature(5);
   array<Type^>^ targetTypes = gcnew array<Type^> { SByte::typeid, Int16::typeid, Int32::typeid,
                                                    Int64::typeid, Byte::typeid, UInt16::typeid,
                                                    UInt32::typeid, UInt64::typeid, Decimal::typeid,
                                                    Single::typeid, Double::typeid, String::typeid };
   CultureInfo^ provider = gcnew CultureInfo("fr-FR");
      
   for each (Type^ targetType in targetTypes)
   {
      try {
         Object^ value = Convert::ChangeType(cool, targetType, provider);
         Console::WriteLine("Converted {0} {1} to {2} {3}.",
                           cool->GetType()->Name, cool->ToString(),
                           targetType->Name, value);
      }
      catch (InvalidCastException^) {
         Console::WriteLine("Unsupported {0} --> {1} conversion.",
                           cool->GetType()->Name, targetType->Name);
      }                     
      catch (OverflowException^) {
         Console::WriteLine("{0} is out of range of the {1} type.",
                           cool, targetType->Name);
      }
   }
}
// The example dosplays the following output:
//       Converted Temperature 5.00�C to SByte 5.
//       Converted Temperature 5.00�C to Int16 5.
//       Converted Temperature 5.00�C to Int32 5.
//       Converted Temperature 5.00�C to Int64 5.
//       Converted Temperature 5.00�C to Byte 5.
//       Converted Temperature 5.00�C to UInt16 5.
//       Converted Temperature 5.00�C to UInt32 5.
//       Converted Temperature 5.00�C to UInt64 5.
//       Converted Temperature 5.00�C to Decimal 5.
//       Converted Temperature 5.00�C to Single 5.
//       Converted Temperature 5.00�C to Double 5.
//       Converted Temperature 5.00�C to String 5,00�C.