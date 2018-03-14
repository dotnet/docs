
//<Snippet1>
// Example of the BitConverter::ToString( unsigned char[ ] ) method.
using namespace System;

// Display a byte array with a name.
void WriteByteArray( array<unsigned char>^bytes, String^ name )
{
   String^ underLine = "--------------------------------";
   Console::WriteLine( name );
   Console::WriteLine( underLine->Substring( 0, Math::Min( name->Length, underLine->Length ) ) );
   Console::WriteLine( BitConverter::ToString( bytes ) );
   Console::WriteLine();
}

int main()
{
   array<unsigned char>^arrayOne = {0,1,2,4,8,16,32,64,128,255};
   array<unsigned char>^arrayTwo = {32,0,0,42,0,65,0,125,0,197,0,168,3,41,4,172,32};
   array<unsigned char>^arrayThree = {15,0,0,128,16,39,240,216,241,255,127};
   array<unsigned char>^arrayFour = {15,0,0,0,0,16,0,255,3,0,0,202,154,59,255,255,255,255,127};
   Console::WriteLine( "This example of the "
   "BitConverter::ToString( unsigned char[ ] ) \n"
   "method generates the following output.\n" );
   WriteByteArray( arrayOne, "arrayOne" );
   WriteByteArray( arrayTwo, "arrayTwo" );
   WriteByteArray( arrayThree, "arrayThree" );
   WriteByteArray( arrayFour, "arrayFour" );
}

/*
This example of the BitConverter::ToString( unsigned char[ ] )
method generates the following output.

arrayOne
--------
00-01-02-04-08-10-20-40-80-FF

arrayTwo
--------
20-00-00-2A-00-41-00-7D-00-C5-00-A8-03-29-04-AC-20

arrayThree
----------
0F-00-00-80-10-27-F0-D8-F1-FF-7F

arrayFour
---------
0F-00-00-00-00-10-00-FF-03-00-00-CA-9A-3B-FF-FF-FF-FF-7F
*/
//</Snippet1>
