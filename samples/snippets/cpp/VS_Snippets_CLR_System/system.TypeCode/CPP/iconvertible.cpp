
// <snippet1>
using namespace System;

/// Class that implements IConvertible*
public ref class Complex: public IConvertible
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

   virtual bool ToBoolean( IFormatProvider^ provider )
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

   virtual Byte ToByte( IFormatProvider^ provider )
   {
      return Convert::ToByte( GetDoubleValue() );
   }

   virtual Char ToChar( IFormatProvider^ provider )
   {
      return Convert::ToChar( GetDoubleValue() );
   }

   virtual DateTime ToDateTime( IFormatProvider^ provider )
   {
      return Convert::ToDateTime( GetDoubleValue() );
   }

   virtual Decimal ToDecimal( IFormatProvider^ provider )
   {
      return Convert::ToDecimal( GetDoubleValue() );
   }

   virtual double ToDouble( IFormatProvider^ provider )
   {
      return GetDoubleValue();
   }

   virtual short ToInt16( IFormatProvider^ provider )
   {
      return Convert::ToInt16( GetDoubleValue() );
   }

   virtual int ToInt32( IFormatProvider^ provider )
   {
      return Convert::ToInt32( GetDoubleValue() );
   }

   virtual Int64 ToInt64( IFormatProvider^ provider )
   {
      return Convert::ToInt64( GetDoubleValue() );
   }

   virtual signed char ToSByte( IFormatProvider^ provider )
   {
      return Convert::ToSByte( GetDoubleValue() );
   }

   virtual float ToSingle( IFormatProvider^ provider )
   {
      return Convert::ToSingle( GetDoubleValue() );
   }

   virtual String^ ToString( IFormatProvider^ provider )
   {
      return x.ToString() +  ", " + y.ToString();
   }

   virtual Object^ ToType( Type^ conversionType, IFormatProvider^ provider )
   {
      return Convert::ChangeType( GetDoubleValue(), conversionType );
   }

   virtual UInt16 ToUInt16( IFormatProvider^ provider )
   {
      return Convert::ToUInt16( GetDoubleValue() );
   }

   virtual UInt32 ToUInt32( IFormatProvider^ provider )
   {
      return Convert::ToUInt32( GetDoubleValue() );
   }

   virtual UInt64 ToUInt64( IFormatProvider^ provider )
   {
      return Convert::ToUInt64( GetDoubleValue() );
   }
};


// <snippet2>
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
// </snippet2>

void main()
{
   Complex^ testComplex = gcnew Complex( 4,7 );
   WriteObjectInfo( testComplex );
   WriteObjectInfo( Convert::ToBoolean( testComplex ) );
   WriteObjectInfo( Convert::ToDecimal( testComplex ) );
   WriteObjectInfo( Convert::ToString( testComplex ) );
}

/*
This code example produces the following results:

Object: ConsoleApplication2.Complex
Boolean: True
Decimal: 8.06225774829855
String: ( 4 , 7 )

*/
// </snippet1>
