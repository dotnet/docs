
// <Snippet1>
using namespace System;
using namespace System::Globalization;
String^ PrintArraySet( array<Int32>^myArr )
{
   String^ myStr = nullptr;
   myStr = myArr[ 0 ].ToString();
   for ( int i = 1; i < myArr->Length; i++ )
      myStr = String::Concat( myStr, ", ", myArr[ i ].ToString() );
   return myStr;
}

int main()
{
   
   // Creates a new NumberFormatinfo.
   NumberFormatInfo^ myNfi = gcnew NumberFormatInfo;
   
   // Takes a long value.
   Int64 myInt = 123456789012345;
   
   // Displays the value with default formatting.
   Console::WriteLine( "Default  \t\t:\t{0}", myInt.ToString( "N", myNfi ) );
   
   // Displays the value with three elements in the GroupSize array.
   array<Int32>^newInts1 = {2,3,4};
   myNfi->NumberGroupSizes = newInts1;
   Console::WriteLine( "Grouping ( {0} )\t:\t{1}", PrintArraySet( myNfi->NumberGroupSizes ), myInt.ToString( "N", myNfi ) );
   
   // Displays the value with zero as the last element in the GroupSize array.
   array<Int32>^newInts2 = {2,4,0};
   myNfi->NumberGroupSizes = newInts2;
   Console::WriteLine( "Grouping ( {0} )\t:\t{1}", PrintArraySet( myNfi->NumberGroupSizes ), myInt.ToString( "N", myNfi ) );
}

/*
This code produces the following output. 

Default               :       123, 456, 789, 012, 345.00
Grouping (2, 3, 4)    :       12, 3456, 7890, 123, 45.00
Grouping (2, 4, 0)    :       123456789, 0123, 45.00
*/
// </Snippet1>
