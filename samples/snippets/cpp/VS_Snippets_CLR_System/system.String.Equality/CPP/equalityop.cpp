
//<snippet1>
// Example for the String Equality operator.
using namespace System;
void CompareAndDisplay( String^ Comparand )
{
   String^ Lower = "abcd";
   Console::WriteLine( "\"{0}\" == \"{1}\" ?  {2}", Lower, Comparand, Lower == Comparand );
}

int main()
{
   Console::WriteLine( "This example of the String Equality operator\n"
   "generates the following output.\n" );
   CompareAndDisplay( "ijkl" );
   CompareAndDisplay( "ABCD" );
   CompareAndDisplay( "abcd" );
}

/*
This example of the String Equality operator 
generates the following output.

"abcd" == "ijkl" ?  False
"abcd" == "ABCD" ?  False
"abcd" == "abcd" ?  True
*/
//</snippet1>
