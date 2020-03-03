
//<snippet1>
// This example demonstrates the Console.BufferHeight and 
//                               Console.BufferWidth properties.
using namespace System;
int main()
{
   Console::WriteLine( "The current buffer height is {0} rows.", Console::BufferHeight );
   Console::WriteLine( "The current buffer width is {0} columns.", Console::BufferWidth );
}

/*
This example produces the following results:

The current buffer height is 300 rows.
The current buffer width is 85 columns.
*/
//</snippet1>
