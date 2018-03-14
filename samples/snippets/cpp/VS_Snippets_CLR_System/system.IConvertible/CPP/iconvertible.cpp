

// <snippet1>
#using <System.dll>

using namespace System;

/// Class that implements IConvertible
ref class Complex: public IConvertible
{
private:
   double x;
   double y;

public:
   Complex( double x, double y )
   {
      this->x = x;
      this->y = y;
   }

   virtual TypeCode GetTypeCode()
   {
      return TypeCode::Object;
   }

   virtual bool ToBoolean( IFormatProvider^ /*provider*/ ) = IConvertible::ToBoolean
   {
      if ( (x != 0.0) || (y != 0.0) )
            return true;
      else
            return false;
   }

   double GetDoubleValue()
   {
      return Math::Sqrt( x * x + y * y );
   }

   virtual Byte ToByte( IFormatProvider^ /*provider*/ ) = IConvertible::ToByte
   {
      return Convert::ToByte( GetDoubleValue() );
   }

   virtual Char ToChar( IFormatProvider^ /*provider*/ ) = IConvertible::ToChar
   {
      return Convert::ToChar( GetDoubleValue() );
   }

   virtual DateTime ToDateTime( IFormatProvider^ /*provider*/ ) = IConvertible::ToDateTime
   {
      return Convert::ToDateTime( GetDoubleValue() );
   }

   virtual Decimal ToDecimal( IFormatProvider^ /*provider*/ ) = IConvertible::ToDecimal
   {
      return Convert::ToDecimal( GetDoubleValue() );
   }

   virtual double ToDouble( IFormatProvider^ /*provider*/ ) = IConvertible::ToDouble
   {
      return GetDoubleValue();
   }

   virtual short ToInt16( IFormatProvider^ /*provider*/ ) = IConvertible::ToInt16
   {
      return Convert::ToInt16( GetDoubleValue() );
   }

   virtual int ToInt32( IFormatProvider^ /*provider*/ ) = IConvertible::ToInt32
   {
      return Convert::ToInt32( GetDoubleValue() );
   }

   virtual Int64 ToInt64( IFormatProvider^ /*provider*/ ) = IConvertible::ToInt64
   {
      return Convert::ToInt64( GetDoubleValue() );
   }

   virtual signed char ToSByte( IFormatProvider^ /*provider*/ ) = IConvertible::ToSByte
   {
      return Convert::ToSByte( GetDoubleValue() );
   }

   virtual float ToSingle( IFormatProvider^ /*provider*/ ) = IConvertible::ToSingle
   {
      return Convert::ToSingle( GetDoubleValue() );
   }

   virtual String^ ToString( IFormatProvider^ /*provider*/ ) = IConvertible::ToString
   {
      return String::Format( "( {0} , {1} )", x, y );
   }

   virtual Object^ ToType( Type^ conversionType, IFormatProvider^ /*provider*/ ) = IConvertible::ToType
   {
      return Convert::ChangeType( GetDoubleValue(), conversionType );
   }

   virtual UInt16 ToUInt16( IFormatProvider^ /*provider*/ ) = IConvertible::ToUInt16
   {
      return Convert::ToUInt16( GetDoubleValue() );
   }

   virtual UInt32 ToUInt32( IFormatProvider^ /*provider*/ ) = IConvertible::ToUInt32
   {
      return Convert::ToUInt32( GetDoubleValue() );
   }

   virtual UInt64 ToUInt64( IFormatProvider^ /*provider*/ ) = IConvertible::ToUInt64
   {
      return Convert::ToUInt64( GetDoubleValue() );
   }

};

void WriteObjectInfo( Object^ testObject )
{
   TypeCode typeCode = Type::GetTypeCode( testObject->GetType() );
   switch ( typeCode )
   {
      case TypeCode::Boolean:
         Console::WriteLine( "Boolean: {0}", testObject );
         break;

      case TypeCode::Double:
         Console::WriteLine( "Double: {0}", testObject );
         break;

      default:
         Console::WriteLine( "{0}: {1}", typeCode, testObject );
         break;
   }
}

int main()
{
   Complex^ testComplex = gcnew Complex( 4,7 );
   WriteObjectInfo( testComplex );
   WriteObjectInfo( Convert::ToBoolean( testComplex ) );
   WriteObjectInfo( Convert::ToDecimal( testComplex ) );
   WriteObjectInfo( Convert::ToString( testComplex ) );
}
// </snippet1>
