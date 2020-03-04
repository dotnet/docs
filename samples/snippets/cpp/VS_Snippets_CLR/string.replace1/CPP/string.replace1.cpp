
//<snippet1>
using namespace System;
int main()
{
   String^ str = "1 2 3 4 5 6 7 8 9";
   Console::WriteLine( "Original string: \"{0}\"", str );
   Console::WriteLine( "CSV string:      \"{0}\"", str->Replace( ' ', ',' ) );
}

//
// This example produces the following output:
// Original string: "1 2 3 4 5 6 7 8 9"
// CSV string:      "1,2,3,4,5,6,7,8,9"
//
//</snippet1>
