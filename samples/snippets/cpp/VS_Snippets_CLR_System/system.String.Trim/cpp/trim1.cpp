// <Snippet1>
using namespace System;

void main()
{
   array<Char>^ charsToTrim = { L'*', L' ', L'\\' };
   String^ banner = "*** Much Ado About Nothing ***";
   String^ result = banner->Trim(charsToTrim);
   Console::WriteLine("Trimmmed\n   {0}\nto\n   '{1}'", banner, result);
}
// The example displays the following output:
//       Trimmmed
//          *** Much Ado About Nothing ***
//       to
//          'Much Ado About Nothing'
// </Snippet1>
