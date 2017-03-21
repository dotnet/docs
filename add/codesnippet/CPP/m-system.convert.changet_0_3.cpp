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
      return m_Temp.ToString("N2") + "�C";
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
      return m_Temp.ToString("N2", provider) + "�C";
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