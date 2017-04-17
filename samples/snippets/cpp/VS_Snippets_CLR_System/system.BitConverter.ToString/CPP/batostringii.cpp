
//<Snippet2>
// Example of some BitConverter::ToString( ) method overloads.
using namespace System;

// Display a byte array, using multiple lines if necessary.
void WriteMultiLineByteArray( array<unsigned char>^bytes, String^ name )
{
   const int rowSize = 20;
   String^ underLine = "--------------------------------";
   int iter;
   Console::WriteLine( name );
   Console::WriteLine( underLine->Substring( 0, Math::Min( name->Length, underLine->Length ) ) );
   for ( iter = 0; iter < bytes->Length - rowSize; iter += rowSize )
   {
      Console::Write( BitConverter::ToString( bytes, iter, rowSize ) );
      Console::WriteLine( "-" );

   }
   Console::WriteLine( BitConverter::ToString( bytes, iter ) );
   Console::WriteLine();
}

int main()
{
   array<unsigned char>^arrayOne = {0,0,0,0,128,63,0,0,112,65,0,255,127,71,0,0,128,59,0,0,128,47,73,70,131,5,75,6,158,63,77,6,158,63,80,6,158,63,30,55,190,121,255,255,127,255,255,127,127,1,0,0,0,192,255,0,0,128,255,0,0,128,127};
   array<unsigned char>^arrayTwo = {255,255,255,0,0,20,0,33,0,0,0,1,0,0,0,100,167,179,182,224,13,0,202,154,59,0,143,91,0,170,170,170,170,170,170,0,0,232,137,4,35,199,138,255,232,244,255,252,205,255,255,129};
   array<unsigned char>^arrayThree = {0,222,0,0,0,224,111,64,0,0,224,255,255,255,239,65,0,0,131,0,0,0,112,63,0,143,0,100,0,0,240,61,223,136,30,28,254,116,170,1,250,89,140,66,202,192,243,63,251,89,140,66,202,192,243,63,252,89,140,66,202,192,243,63,82,211,187,188,232,126,255,255,255,244,255,239,127,1,0,0,0,10,17,0,0,248,255,0,88,0,91,0,0,240,255,0,0,240,157};
   Console::WriteLine( "This example of the\n"
   "  BitConverter::ToString( unsigned char[ ], int ) and \n"
   "  BitConverter::ToString( unsigned char[ ], int, int ) \n"
   "methods generates the following output.\n" );
   WriteMultiLineByteArray( arrayOne, "arrayOne" );
   WriteMultiLineByteArray( arrayTwo, "arrayTwo" );
   WriteMultiLineByteArray( arrayThree, "arrayThree" );
}

/*
This example of the
  BitConverter::ToString( unsigned char[ ], int ) and
  BitConverter::ToString( unsigned char[ ], int, int )
methods generates the following output.

arrayOne
--------
00-00-00-00-80-3F-00-00-70-41-00-FF-7F-47-00-00-80-3B-00-00-
80-2F-49-46-83-05-4B-06-9E-3F-4D-06-9E-3F-50-06-9E-3F-1E-37-
BE-79-FF-FF-7F-FF-FF-7F-7F-01-00-00-00-C0-FF-00-00-80-FF-00-
00-80-7F

arrayTwo
--------
FF-FF-FF-00-00-14-00-21-00-00-00-01-00-00-00-64-A7-B3-B6-E0-
0D-00-CA-9A-3B-00-8F-5B-00-AA-AA-AA-AA-AA-AA-00-00-E8-89-04-
23-C7-8A-FF-E8-F4-FF-FC-CD-FF-FF-81

arrayThree
----------
00-DE-00-00-00-E0-6F-40-00-00-E0-FF-FF-FF-EF-41-00-00-83-00-
00-00-70-3F-00-8F-00-64-00-00-F0-3D-DF-88-1E-1C-FE-74-AA-01-
FA-59-8C-42-CA-C0-F3-3F-FB-59-8C-42-CA-C0-F3-3F-FC-59-8C-42-
CA-C0-F3-3F-52-D3-BB-BC-E8-7E-FF-FF-FF-F4-FF-EF-7F-01-00-00-
00-0A-11-00-00-F8-FF-00-58-00-5B-00-00-F0-FF-00-00-F0-9D
*/
//</Snippet2>
