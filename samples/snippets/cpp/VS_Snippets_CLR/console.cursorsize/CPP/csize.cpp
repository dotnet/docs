
//<snippet1>
// This example demonstrates the Console.CursorSize property.
using namespace System;
int main()
{
   String^ m0 = "This example increments the cursor size from 1% to 100%:\n";
   String^ m1 = "Cursor size = {0}%. (Press any key to continue...)";
   array<Int32>^sizes = {1,10,20,30,40,50,60,70,80,90,100};
   int saveCursorSize;
   
   //
   saveCursorSize = Console::CursorSize;
   Console::WriteLine( m0 );
   System::Collections::IEnumerator^ myEnum = sizes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      int size =  *safe_cast<Int32^>(myEnum->Current);
      Console::CursorSize = size;
      Console::WriteLine( m1, size );
      Console::ReadKey();
   }

   Console::CursorSize = saveCursorSize;
}

/*
This example produces the following results:

This example increments the cursor size from 1% to 100%:

Cursor size = 1%. (Press any key to continue...)
Cursor size = 10%. (Press any key to continue...)
Cursor size = 20%. (Press any key to continue...)
Cursor size = 30%. (Press any key to continue...)
Cursor size = 40%. (Press any key to continue...)
Cursor size = 50%. (Press any key to continue...)
Cursor size = 60%. (Press any key to continue...)
Cursor size = 70%. (Press any key to continue...)
Cursor size = 80%. (Press any key to continue...)
Cursor size = 90%. (Press any key to continue...)
Cursor size = 100%. (Press any key to continue...)

*/
//</snippet1>
