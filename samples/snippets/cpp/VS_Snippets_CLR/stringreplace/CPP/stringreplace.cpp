
//<snippet1>
using namespace System;
int main()
{
   String^ errString = "This docment uses 3 other docments to docment the docmentation";
   Console::WriteLine( "The original string is:\n'{0}'\n", errString );

   // Correct the spelling of S"document".
   String^ correctString = errString->Replace( "docment", "document" );
   Console::WriteLine( "After correcting the string, the result is:\n'{0}'", correctString );
}
//
// This code example produces the following output:
//
// The original string is:
// 'This docment uses 3 other docments to docment the docmentation'
//
// After correcting the string, the result is:
// 'This document uses 3 other documents to document the documentation'
//
//</snippet1>
