
//<Snippet3>
// Example of the BitConverter::GetBytes( float ) method.
using namespace System;

// Convert a float argument to a byte array and display it.
void GetBytesSingle( float argument )
{
   array<Byte>^byteArray = BitConverter::GetBytes( argument );
   Console::WriteLine( "{0,16:E7}{1,20}", argument, BitConverter::ToString( byteArray ) );
}

int main()
{
   Console::WriteLine( "This example of the BitConverter::GetBytes( float ) "
   "\nmethod generates the following output.\n" );
   Console::WriteLine( "{0,16:E7}{1,20}", "float", "byte array" );
   Console::WriteLine( "{0,16:E7}{1,20}", "-----", "----------" );
   
   // Convert float values and display the results.
   GetBytesSingle( 0.0F );
   GetBytesSingle( 1.0F );
   GetBytesSingle( 15.0F );
   GetBytesSingle( 65535.0F );
   GetBytesSingle( 0.00390625F );
   GetBytesSingle( 0.00000000023283064365386962890625F );
   GetBytesSingle( 1.2345E-35F );
   GetBytesSingle( 1.2345671F );
   GetBytesSingle( 1.2345673F );
   GetBytesSingle( 1.2345677F );
   GetBytesSingle( 1.23456789E+35F );
   GetBytesSingle( Single::MinValue );
   GetBytesSingle( Single::MaxValue );
   GetBytesSingle( Single::Epsilon );
   GetBytesSingle( Single::NaN );
   GetBytesSingle( Single::NegativeInfinity );
   GetBytesSingle( Single::PositiveInfinity );
}

/*
This example of the BitConverter::GetBytes( float )
method generates the following output.

           float          byte array
           -----          ----------
  0.0000000E+000         00-00-00-00
  1.0000000E+000         00-00-80-3F
  1.5000000E+001         00-00-70-41
  6.5535000E+004         00-FF-7F-47
  3.9062500E-003         00-00-80-3B
  2.3283064E-010         00-00-80-2F
  1.2345000E-035         49-46-83-05
  1.2345671E+000         4B-06-9E-3F
  1.2345673E+000         4D-06-9E-3F
  1.2345676E+000         50-06-9E-3F
  1.2345679E+035         1E-37-BE-79
 -3.4028235E+038         FF-FF-7F-FF
  3.4028235E+038         FF-FF-7F-7F
  1.4012985E-045         01-00-00-00
             NaN         00-00-C0-FF
       -Infinity         00-00-80-FF
        Infinity         00-00-80-7F
*/
//</Snippet3>
