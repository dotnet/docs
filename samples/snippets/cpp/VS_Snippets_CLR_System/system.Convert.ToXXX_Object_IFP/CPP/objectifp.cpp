
//<Snippet1>
using namespace System;
using namespace System::Collections;

// Define the types of averaging available in the class 
// implementing IConvertible.
public enum class AverageType : short
{
   None = 0,
   GeometricMean = 1,
   ArithmeticMean = 2,
   Median = 3
};


// Pass an instance of this class to methods that require an 
// IFormatProvider. The class instance determines the type of 
// average to calculate.
ref class AverageInfo: public IFormatProvider
{
protected:
   AverageType AvgType;

public:

   // Specify the type of averaging in the constructor.
   AverageInfo( AverageType avgType )
   {
      this->AvgType = avgType;
   }


   // This method returns a reference to the containing object 
   // if an object of AverageInfo type is requested. 
   virtual Object^ GetFormat( Type^ argType )
   {
      if ( argType == AverageInfo::typeid)
            return this;
      else
            return (Object^)0;
   }


   property AverageType TypeOfAverage 
   {

      // Use this property to set or get the type of averaging.
      AverageType get()
      {
         return this->AvgType;
      }

      void set( AverageType value )
      {
         this->AvgType = value;
      }

   }

};


// This class encapsulates an array of double values and implements 
// the IConvertible interface. Most of the IConvertible methods 
// return an average of the array elements in one of three types: 
// arithmetic mean, geometric mean, or median. 
ref class DataSet: public IConvertible
{
private:
   static Object^ null = nullptr;

protected:
   ArrayList^ data;
   AverageInfo^ defaultProvider;

   // This method unboxes a boxed double.
   double UnBoxDouble( Object^ obj )
   {
      return  *static_cast<double^>(obj);
   }


public:

   // Construct the object and add an initial list of values.
   // Create a default format provider.
   DataSet( ... array<Double>^values )
   {
      data = gcnew ArrayList( (Array^)values );
      defaultProvider = gcnew AverageInfo( AverageType::ArithmeticMean );
   }


   // Add additional values with this method.
   int Add( double value )
   {
      data->Add( value );
      return data->Count;
   }


   property double Item[ int ]
   {

      // Get, set, and add values with this indexer property.
      double get( int index )
      {
         if ( index >= 0 && index < data->Count )
                  return UnBoxDouble( data[ index ] );
         else
                  throw gcnew InvalidOperationException( "[DataSet.get] Index out of range." );
      }

      void set( int index, double value )
      {
         if ( index >= 0 && index < data->Count )
                  data[ index ] = value;
         else
         if ( index == data->Count )
                  data->Add( value );
         else
                  throw gcnew InvalidOperationException( "[DataSet.set] Index out of range." );
      }

   }

   property int Count 
   {

      // This property returns the number of elements in the object.
      int get()
      {
         return data->Count;
      }

   }

protected:

   // This method calculates the average of the object's elements.
   double Average( AverageType avgType )
   {
      double SumProd;
      if ( data->Count == 0 )
            return 0.0;

      switch ( avgType )
      {
         case AverageType::GeometricMean:
            SumProd = 1.0;
            for ( int Index = 0; Index < data->Count; Index++ )
               SumProd *= UnBoxDouble( data[ Index ] );
            
            // This calculation will not fail with negative 
            // elements.
            return Math::Sign( SumProd ) * Math::Pow( Math::Abs( SumProd ), 1.0 / data->Count );

         case AverageType::ArithmeticMean:
            SumProd = 0.0;
            for ( int Index = 0; Index < data->Count; Index++ )
               SumProd += UnBoxDouble( data[ Index ] );
            return SumProd / data->Count;

         case AverageType::Median:
            if ( data->Count % 2 == 0 )
                        return (UnBoxDouble( data[ data->Count / 2 ] ) + UnBoxDouble( data[ data->Count / 2 - 1 ] )) / 2.0;
            else
                        return UnBoxDouble( data[ data->Count / 2 ] );

         default:
            return 0.0;
      }
   }


   // Get the AverageInfo object from the caller's format provider,
   // or use the local default.
   AverageInfo^ GetAverageInfo( IFormatProvider^ provider )
   {
      AverageInfo^ avgInfo = nullptr;
      if ( provider != nullptr )
            avgInfo = static_cast<AverageInfo^>(provider->GetFormat( AverageInfo::typeid ));

      if ( avgInfo == nullptr )
            return defaultProvider;
      else
            return avgInfo;
   }


   // Calculate the average and limit the range.
   double CalcNLimitAverage( double min, double max, IFormatProvider^ provider )
   {
      
      // Get the format provider and calculate the average.
      AverageInfo^ avgInfo = GetAverageInfo( provider );
      double avg = Average( avgInfo->TypeOfAverage );
      
      // Limit the range, based on the minimum and maximum values 
      // for the type.
      return avg > max ? max : avg < min ? min : avg;
   }


public:

   // The following elements are required by IConvertible.
   // None of these conversion functions throw exceptions. When
   // the data is out of range for the type, the appropriate
   // MinValue or MaxValue is used.
   virtual TypeCode GetTypeCode()
   {
      return TypeCode::Object;
   }

   virtual bool ToBoolean( IFormatProvider^ provider )
   {
      
      // ToBoolean is false if the dataset is empty.
      if ( data->Count <= 0 )
            return false;
      // For median averaging, ToBoolean is true if any 
      // non-discarded elements are nonzero.
      else
      
      // For median averaging, ToBoolean is true if any 
      // non-discarded elements are nonzero.
      if ( AverageType::Median == GetAverageInfo( provider )->TypeOfAverage )
      {
         if ( data->Count % 2 == 0 )
                  return (UnBoxDouble( data[ data->Count / 2 ] ) != 0.0 || UnBoxDouble( data[ data->Count / 2 - 1 ] ) != 0.0);
         else
                  return UnBoxDouble( data[ data->Count / 2 ] ) != 0.0;
      }
      // For arithmetic or geometric mean averaging, ToBoolean is 
      // true if any element of the dataset is nonzero.  
      else
      {
         for ( int Index = 0; Index < data->Count; Index++ )
            if ( UnBoxDouble( data[ Index ] ) != 0.0 )
                        return true;
         return false;
      }
   }

   virtual Byte ToByte( IFormatProvider^ provider )
   {
      return Convert::ToByte( CalcNLimitAverage( Byte::MinValue, Byte::MaxValue, provider ) );
   }

   virtual Char ToChar( IFormatProvider^ provider )
   {
      return Convert::ToChar( Convert::ToUInt16( CalcNLimitAverage( Char::MinValue, Char::MaxValue, provider ) ) );
   }


   // Convert to DateTime by adding the calculated average as 
   // seconds to the current date and time. A valid DateTime is 
   // always returned.
   virtual DateTime ToDateTime( IFormatProvider^ provider )
   {
      double seconds = Average( GetAverageInfo( provider )->TypeOfAverage );
      try
      {
         return DateTime::Now.AddSeconds( seconds );
      }
      catch ( ArgumentOutOfRangeException^ ) 
      {
         return seconds < 0.0 ? DateTime::MinValue : DateTime::MaxValue;
      }

   }

   virtual Decimal ToDecimal( IFormatProvider^ provider )
   {
      
      // The Double conversion rounds Decimal.MinValue and 
      // Decimal.MaxValue to invalid Decimal values, so the 
      // following limits must be used.
      return Convert::ToDecimal( CalcNLimitAverage(  -79228162514264330000000000000.0, 79228162514264330000000000000.0, provider ) );
   }

   virtual double ToDouble( IFormatProvider^ provider )
   {
      return Average( GetAverageInfo( provider )->TypeOfAverage );
   }

   virtual short ToInt16( IFormatProvider^ provider )
   {
      return Convert::ToInt16( CalcNLimitAverage( Int16::MinValue, Int16::MaxValue, provider ) );
   }

   virtual int ToInt32( IFormatProvider^ provider )
   {
      return Convert::ToInt32( CalcNLimitAverage( Int32::MinValue, Int32::MaxValue, provider ) );
   }

   virtual __int64 ToInt64( IFormatProvider^ provider )
   {
      
      // The Double conversion rounds Int64.MinValue and 
      // Int64.MaxValue to invalid Int64 values, so the following 
      // limits must be used.
      return Convert::ToInt64( CalcNLimitAverage(  -9223372036854775000, 9223372036854775000, provider ) );
   }

   virtual signed char ToSByte( IFormatProvider^ provider )
   {
      return Convert::ToSByte( CalcNLimitAverage( SByte::MinValue, SByte::MaxValue, provider ) );
   }

   virtual float ToSingle( IFormatProvider^ provider )
   {
      return Convert::ToSingle( CalcNLimitAverage( Single::MinValue, Single::MaxValue, provider ) );
   }

   virtual UInt16 ToUInt16( IFormatProvider^ provider )
   {
      return Convert::ToUInt16( CalcNLimitAverage( UInt16::MinValue, UInt16::MaxValue, provider ) );
   }

   virtual UInt32 ToUInt32( IFormatProvider^ provider )
   {
      return Convert::ToUInt32( CalcNLimitAverage( UInt32::MinValue, UInt32::MaxValue, provider ) );
   }

   virtual UInt64 ToUInt64( IFormatProvider^ provider )
   {
      
      // The Double conversion rounds UInt64.MaxValue to an invalid
      // UInt64 value, so the following limit must be used.
      return Convert::ToUInt64( CalcNLimitAverage( 0, 18446744073709550000.0, provider ) );
   }

   virtual Object^ ToType( Type^ conversionType, IFormatProvider^ provider )
   {
      return Convert::ChangeType( Average( GetAverageInfo( provider )->TypeOfAverage ), conversionType );
   }

   virtual String^ ToString( IFormatProvider^ provider )
   {
      AverageType avgType = GetAverageInfo( provider )->TypeOfAverage;
      return String::Format( "( {0}: {1:G10} )", avgType, Average( avgType ) );
   }

};


// Display a DataSet with three different format providers.
void DisplayDataSet( DataSet^ ds )
{
   IFormatProvider^ null = nullptr;
   String^ fmt = "{0,-12}{1,20}{2,20}{3,20}";
   AverageInfo^ median = gcnew AverageInfo( AverageType::Median );
   AverageInfo^ geMean = gcnew AverageInfo( AverageType::GeometricMean );
   
   // Display the dataset elements.
   if ( ds->Count > 0 )
   {
      Console::Write( "\nDataSet: [{0}", ds->Item[ 0 ] );
      for ( int iX = 1; iX < ds->Count; iX++ )
         Console::Write( ", {0}", ds->Item[ iX ] );
      Console::WriteLine( "]\n" );
   }

   Console::WriteLine( fmt, "Convert::", "Default", "Geometric Mean", "Median" );
   Console::WriteLine( fmt, "---------", "-------", "--------------", "------" );
   Console::WriteLine( fmt, "ToBoolean", Convert::ToBoolean( ds, null ), Convert::ToBoolean( ds, geMean ), Convert::ToBoolean( ds, median ) );
   Console::WriteLine( fmt, "ToByte", Convert::ToByte( ds, null ), Convert::ToByte( ds, geMean ), Convert::ToByte( ds, median ) );
   Console::WriteLine( fmt, "ToChar", Convert::ToChar( ds, null ), Convert::ToChar( ds, geMean ), Convert::ToChar( ds, median ) );
   Console::WriteLine( "{0,-12}{1,20:yyyy-MM-dd HH:mm:ss}"
   "{2,20:yyyy-MM-dd HH:mm:ss}{3,20:yyyy-MM-dd HH:mm:ss}", "ToDateTime", Convert::ToDateTime( ds, null ), Convert::ToDateTime( ds, geMean ), Convert::ToDateTime( ds, median ) );
   Console::WriteLine( fmt, "ToDecimal", Convert::ToDecimal( ds, null ), Convert::ToDecimal( ds, geMean ), Convert::ToDecimal( ds, median ) );
   Console::WriteLine( fmt, "ToDouble", Convert::ToDouble( ds, null ), Convert::ToDouble( ds, geMean ), Convert::ToDouble( ds, median ) );
   Console::WriteLine( fmt, "ToInt16", Convert::ToInt16( ds, null ), Convert::ToInt16( ds, geMean ), Convert::ToInt16( ds, median ) );
   Console::WriteLine( fmt, "ToInt32", Convert::ToInt32( ds, null ), Convert::ToInt32( ds, geMean ), Convert::ToInt32( ds, median ) );
   Console::WriteLine( fmt, "ToInt64", Convert::ToInt64( ds, null ), Convert::ToInt64( ds, geMean ), Convert::ToInt64( ds, median ) );
   Console::WriteLine( fmt, "ToSByte", Convert::ToSByte( ds, null ), Convert::ToSByte( ds, geMean ), Convert::ToSByte( ds, median ) );
   Console::WriteLine( fmt, "ToSingle", Convert::ToSingle( ds, null ), Convert::ToSingle( ds, geMean ), Convert::ToSingle( ds, median ) );
   Console::WriteLine( fmt, "ToUInt16", Convert::ToUInt16( ds, null ), Convert::ToUInt16( ds, geMean ), Convert::ToUInt16( ds, median ) );
   Console::WriteLine( fmt, "ToUInt32", Convert::ToUInt32( ds, null ), Convert::ToUInt32( ds, geMean ), Convert::ToUInt32( ds, median ) );
   Console::WriteLine( fmt, "ToUInt64", Convert::ToUInt64( ds, null ), Convert::ToUInt64( ds, geMean ), Convert::ToUInt64( ds, median ) );
}

int main()
{
   Console::WriteLine( "This example of the "
   "Convert::To<Type>( Object*, IFormatProvider* ) methods "
   "\ngenerates the following output. The example "
   "displays the values \nreturned by the methods, "
   "using several IFormatProvider objects.\n" );
   
   // To call a [ParamArray] method in C++, you cannot just
   // list the parameters, you need to build an array.
   array<Double>^dataElem = gcnew array<Double>(6);
   dataElem[ 0 ] = 10.5;
   dataElem[ 1 ] = 22.2;
   dataElem[ 2 ] = 45.9;
   dataElem[ 3 ] = 88.7;
   dataElem[ 4 ] = 156.05;
   dataElem[ 5 ] = 297.6;
   DataSet^ ds1 = gcnew DataSet( dataElem );
   DisplayDataSet( ds1 );
   dataElem = gcnew array<Double>(5);
   dataElem[ 0 ] = 359999.95;
   dataElem[ 1 ] = 425000;
   dataElem[ 2 ] = 499999.5;
   dataElem[ 3 ] = 775000;
   dataElem[ 4 ] = 1695000;
   DataSet^ ds2 = gcnew DataSet( dataElem );
   DisplayDataSet( ds2 );
}

/*
This example of the Convert::To<Type>( Object*, IFormatProvider* ) methods
generates the following output. The example displays the values
returned by the methods, using several IFormatProvider objects.

DataSet: [10.5, 22.2, 45.9, 88.7, 156.05, 297.6]

Convert::                Default      Geometric Mean              Median
---------                -------      --------------              ------
ToBoolean                   True                True                True
ToByte                       103                  59                  67
ToChar                         g                   ;                   C
ToDateTime   2003-05-13 15:30:23 2003-05-13 15:29:39 2003-05-13 15:29:47
ToDecimal       103.491666666667    59.4332135445164                67.3
ToDouble        103.491666666667    59.4332135445164                67.3
ToInt16                      103                  59                  67
ToInt32                      103                  59                  67
ToInt64                      103                  59                  67
ToSByte                      103                  59                  67
ToSingle                103.4917            59.43321                67.3
ToUInt16                     103                  59                  67
ToUInt32                     103                  59                  67
ToUInt64                     103                  59                  67

DataSet: [359999.95, 425000, 499999.5, 775000, 1695000]

Convert::                Default      Geometric Mean              Median
---------                -------      --------------              ------
ToBoolean                   True                True                True
ToByte                       255                 255                 255
ToChar                         ?                   ?                   ?
ToDateTime   2003-05-22 08:05:19 2003-05-20 22:54:57 2003-05-19 10:21:59
ToDecimal              750999.89    631577.237188435            499999.5
ToDouble               750999.89    631577.237188435            499999.5
ToInt16                    32767               32767               32767
ToInt32                   751000              631577              500000
ToInt64                   751000              631577              500000
ToSByte                      127                 127                 127
ToSingle                750999.9            631577.3            499999.5
ToUInt16                   65535               65535               65535
ToUInt32                  751000              631577              500000
ToUInt64                  751000              631577              500000
*/
//</Snippet1>
