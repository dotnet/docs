//<Snippet1>
using namespace System;

void main()
{
     // Define an array of Char values.
     array<Char>^ values = { L'\0', L' ', L'*', L'A', L'a', 
                             L'{', L'Æ' };

     // Convert each Char value to a Decimal.
     for each (wchar_t value in values) {
        Decimal decValue = value;
        Console::WriteLine("'{0}' ({1}) --> {2} ({3})", value,
                           value.GetType()->Name, decValue,
                           decValue.GetType()->Name); 
     }    
}
// This example displays the following output:
//       ' ' (Decimal) --> 0 (Decimal)
//       ' ' (Decimal) --> 32 (Decimal)
//       '*' (Decimal) --> 42 (Decimal)
//       'A' (Decimal) --> 65 (Decimal)
//       'a' (Decimal) --> 97 (Decimal)
//       '{' (Decimal) --> 123 (Decimal)
//       'A' (Decimal) --> 195 (Decimal)
// </Snippet1>
