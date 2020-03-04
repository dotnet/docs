
//<Snippet2>
// Example of the Decimal( int, int, int, bool, unsigned char ) 
// constructor.
using namespace System;

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Create a Decimal object and display its value.
void CreateDecimal( int low, int mid, int high, bool isNeg, unsigned char scale )
{
   
   // Format the constructor for display.
   array<Object^>^boxedParams = gcnew array<Object^>(5);
   boxedParams[ 0 ] = low;
   boxedParams[ 1 ] = mid;
   boxedParams[ 2 ] = high;
   boxedParams[ 3 ] = isNeg;
   boxedParams[ 4 ] = scale;
   String^ ctor = String::Format( "Decimal( {0}, {1}, {2}, {3}, {4} )", boxedParams );
   String^ valOrExc;
   try
   {
      
      // Construct the Decimal value.
      Decimal decimalNum = Decimal(low,mid,high,isNeg,scale);
      
      // Format and save the Decimal value.
      valOrExc = decimalNum.ToString();
   }
   catch ( Exception^ ex ) 
   {
      
      // Save the exception type if an exception was thrown.
      valOrExc = GetExceptionType( ex );
   }

   
   // Display the constructor and Decimal value or exception.
   int ctorLen = 76 - valOrExc->Length;
   
   // Display the data on one line if it will fit.
   if ( ctorLen > ctor->Length )
      Console::WriteLine( "{0}{1}", ctor->PadRight( ctorLen ), valOrExc );
   // Otherwise, display the data on two lines.
   else
   {
      Console::WriteLine( "{0}", ctor );
      Console::WriteLine( "{0,76}", valOrExc );
   }
}

int main()
{
   Console::WriteLine( "This example of the Decimal( int, int, "
   "int, bool, unsigned char ) \nconstructor "
   "generates the following output.\n" );
   Console::WriteLine( "{0,-38}{1,38}", "Constructor", "Value or Exception" );
   Console::WriteLine( "{0,-38}{1,38}", "-----------", "------------------" );
   
   // Construct Decimal objects from double values.
   CreateDecimal( 0, 0, 0, false, 0 );
   CreateDecimal( 0, 0, 0, false, 27 );
   CreateDecimal( 0, 0, 0, true, 0 );
   CreateDecimal( 1000000000, 0, 0, false, 0 );
   CreateDecimal( 0, 1000000000, 0, false, 0 );
   CreateDecimal( 0, 0, 1000000000, false, 0 );
   CreateDecimal( 1000000000, 1000000000, 1000000000, false, 0 );
   CreateDecimal(  -1, -1, -1, false, 0 );
   CreateDecimal(  -1, -1, -1, true, 0 );
   CreateDecimal(  -1, -1, -1, false, 15 );
   CreateDecimal(  -1, -1, -1, false, 28 );
   CreateDecimal(  -1, -1, -1, false, 29 );
   CreateDecimal( Int32::MaxValue, 0, 0, false, 18 );
   CreateDecimal( Int32::MaxValue, 0, 0, false, 28 );
   CreateDecimal( Int32::MaxValue, 0, 0, true, 28 );
}

/*
This example of the Decimal( int, int, int, bool, unsigned char )
constructor generates the following output.

Constructor                                               Value or Exception
-----------                                               ------------------
Decimal( 0, 0, 0, False, 0 )                                               0
Decimal( 0, 0, 0, False, 27 )                                              0
Decimal( 0, 0, 0, True, 0 )                                                0
Decimal( 1000000000, 0, 0, False, 0 )                             1000000000
Decimal( 0, 1000000000, 0, False, 0 )                    4294967296000000000
Decimal( 0, 0, 1000000000, False, 0 )          18446744073709551616000000000
Decimal( 1000000000, 1000000000, 1000000000, False, 0 )
                                               18446744078004518913000000000
Decimal( -1, -1, -1, False, 0 )                79228162514264337593543950335
Decimal( -1, -1, -1, True, 0 )                -79228162514264337593543950335
Decimal( -1, -1, -1, False, 15 )              79228162514264.337593543950335
Decimal( -1, -1, -1, False, 28 )              7.9228162514264337593543950335
Decimal( -1, -1, -1, False, 29 )                 ArgumentOutOfRangeException
Decimal( 2147483647, 0, 0, False, 18 )                  0.000000002147483647
Decimal( 2147483647, 0, 0, False, 28 )        0.0000000000000000002147483647
Decimal( 2147483647, 0, 0, True, 28 )        -0.0000000000000000002147483647
*/
//</Snippet2>
