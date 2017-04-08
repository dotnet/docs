// Convert.ChangeType03.cpp : main project file.

// <Snippet3>
using namespace System;
using namespace System::Globalization;

public ref class Temperature : IConvertible
{
private:
   Decimal m_Temp;

public:
   Temperature(Decimal temperature)
   {
      m_Temp = temperature;
   }
   
   property Decimal Celsius {
      Decimal get() { return m_Temp; }
   }
   
   property Decimal Kelvin {
      Decimal get() { return m_Temp + (Decimal) 273.15; }
   }
   
   property Decimal Fahrenheit {
      Decimal get() { return Math::Round((Decimal) (m_Temp * 9 / 5 + 32), 2); }
   }
   
   virtual String^ ToString()
   override {
      return m_Temp.ToString("N2") + "°C";
   }

   // IConvertible implementations.
   virtual TypeCode GetTypeCode()
   {
      return TypeCode::Object;
   }
   
   virtual bool ToBoolean(IFormatProvider^ provider) 
   {
      if (m_Temp == 0)
         return false;
      else
         return true;
   } 
   
   virtual Byte ToByte(IFormatProvider^ provider)
   {
      if (m_Temp < Byte::MinValue || m_Temp > Byte::MaxValue)
         throw gcnew OverflowException(String::Format("{0} is out of range of the Byte type.", 
                                                   m_Temp));
      else
         return Decimal::ToByte(m_Temp);
   }
   
   virtual Char ToChar(IFormatProvider^ provider)
   {
      throw gcnew InvalidCastException("Temperature to Char conversion is not supported.");
   } 
   
   virtual DateTime ToDateTime(IFormatProvider^ provider)
   {
      throw gcnew InvalidCastException("Temperature to DateTime conversion is not supported.");
   }
   
   virtual Decimal ToDecimal(IFormatProvider^ provider)
   {
      return m_Temp;
   }
   
   virtual Double ToDouble(IFormatProvider^ provider)
   {
      return Decimal::ToDouble(m_Temp);
   }   
   
   virtual Int16 ToInt16(IFormatProvider^ provider)
   {
      if (m_Temp < Int16::MinValue || m_Temp > Int16::MaxValue)
         throw gcnew OverflowException(String::Format("{0} is out of range of the Int16 type.",
                                                   m_Temp));
      else
         return Decimal::ToInt16(m_Temp);
   }
   
   virtual Int32 ToInt32(IFormatProvider^ provider)
      {
      if (m_Temp < Int32::MinValue || m_Temp > Int32::MaxValue)
         throw gcnew OverflowException(String::Format("{0} is out of range of the Int32 type.",
                                                   m_Temp));
      else
         return Decimal::ToInt32(m_Temp);
   }
   
   virtual Int64 ToInt64(IFormatProvider^ provider)
   {
      if (m_Temp < Int64::MinValue || m_Temp > Int64::MaxValue)
         throw gcnew OverflowException(String::Format("{0} is out of range of the Int64 type.",
                                                   m_Temp));
      else
         return Decimal::ToInt64(m_Temp);
   }
   
   virtual SByte ToSByte(IFormatProvider^ provider)
   {
      if (m_Temp < SByte::MinValue || m_Temp > SByte::MaxValue)
         throw gcnew OverflowException(String::Format("{0} is out of range of the SByte type.",
                                                   m_Temp));
      else
         return Decimal::ToSByte(m_Temp);
   }

   virtual Single ToSingle(IFormatProvider^ provider)
   {
      return Decimal::ToSingle(m_Temp);
   }

   virtual String^ ToString(IFormatProvider^ provider)
   {
      return m_Temp.ToString("N2", provider) + "°C";
   }
   
   virtual Object^ ToType(Type^ conversionType, IFormatProvider^ provider)
   {
      switch (Type::GetTypeCode(conversionType))
      {
      case TypeCode::Boolean: 
            return ToBoolean(nullptr);
      case TypeCode::Byte:
            return ToByte(nullptr);
      case TypeCode::Char:
            return ToChar(nullptr);
      case TypeCode::DateTime:
            return ToDateTime(nullptr);
      case TypeCode::Decimal:
            return ToDecimal(nullptr);
      case TypeCode::Double:
            return ToDouble(nullptr);
      case TypeCode::Int16:
            return ToInt16(nullptr);
      case TypeCode::Int32:
            return ToInt32(nullptr);
      case TypeCode::Int64:
            return ToInt64(nullptr);
      case TypeCode::Object:
            if (Temperature::typeid->Equals(conversionType))
               return this;
            else
               throw gcnew InvalidCastException(String::Format("Conversion to a {0} is not supported.",
                                                            conversionType->Name));
      case TypeCode::SByte:
            return ToSByte(nullptr);
      case TypeCode::Single:
            return ToSingle(nullptr);
      case TypeCode::String:
            return ToString(provider);
      case TypeCode::UInt16:
            return ToUInt16(nullptr);
      case TypeCode::UInt32:
            return ToUInt32(nullptr);
      case TypeCode::UInt64:
            return ToUInt64(nullptr);   
         default:
            throw gcnew InvalidCastException(String::Format("Conversion to {0} is not supported.", conversionType->Name));   
      }
   }
   
   virtual UInt16 ToUInt16(IFormatProvider^ provider)
   {
      if (m_Temp < UInt16::MinValue || m_Temp > UInt16::MaxValue)
         throw gcnew OverflowException(String::Format("{0} is out of range of the UInt16 type.",
                                                   m_Temp));
      else
         return Decimal::ToUInt16(m_Temp);
   }

   virtual UInt32 ToUInt32(IFormatProvider^ provider)
   {
      if (m_Temp < UInt32::MinValue || m_Temp > UInt32::MaxValue)
         throw gcnew OverflowException(String::Format("{0} is out of range of the UInt32 type.",
                                                   m_Temp));
      else
         return Decimal::ToUInt32(m_Temp);
   }
   
   virtual UInt64 ToUInt64(IFormatProvider^ provider)
   {
      if (m_Temp < UInt64::MinValue || m_Temp > UInt64::MaxValue)
         throw gcnew OverflowException(String::Format("{0} is out of range of the UInt64 type.",
                                                   m_Temp));
      else
         return Decimal::ToUInt64(m_Temp);
   }
};
// </Snippet3>

// <Snippet4>
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
//       Converted Temperature 5.00°C to SByte 5.
//       Converted Temperature 5.00°C to Int16 5.
//       Converted Temperature 5.00°C to Int32 5.
//       Converted Temperature 5.00°C to Int64 5.
//       Converted Temperature 5.00°C to Byte 5.
//       Converted Temperature 5.00°C to UInt16 5.
//       Converted Temperature 5.00°C to UInt32 5.
//       Converted Temperature 5.00°C to UInt64 5.
//       Converted Temperature 5.00°C to Decimal 5.
//       Converted Temperature 5.00°C to Single 5.
//       Converted Temperature 5.00°C to Double 5.
//       Converted Temperature 5.00°C to String 5,00°C.
// </Snippet4>
