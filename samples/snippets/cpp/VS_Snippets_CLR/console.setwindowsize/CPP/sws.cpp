
//<snippet1>
// This example demonstrates the Console.SetWindowSize method,
//                           the Console.WindowWidth property, 
//                       and the Console.WindowHeight property.
using namespace System;
int main()
{
   int origWidth;
   int width;
   int origHeight;
   int height;
   String^ m1 = "The current window width is {0}, and the "
   "current window height is {1}.";
   String^ m2 = "The new window width is {0}, and the new "
   "window height is {1}.";
   String^ m4 = "  (Press any key to continue...)";
   
   //
   // Step 1: Get the current window dimensions.
   //
   origWidth = Console::WindowWidth;
   origHeight = Console::WindowHeight;
   Console::WriteLine( m1, Console::WindowWidth, Console::WindowHeight );
   Console::WriteLine( m4 );
   Console::ReadKey( true );
   
   //
   // Step 2: Cut the window to 1/4 its original size.
   //
   width = origWidth / 2;
   height = origHeight / 2;
   Console::SetWindowSize( width, height );
   Console::WriteLine( m2, Console::WindowWidth, Console::WindowHeight );
   Console::WriteLine( m4 );
   Console::ReadKey( true );
   
   //
   // Step 3: Restore the window to its original size.
   //
   Console::SetWindowSize( origWidth, origHeight );
   Console::WriteLine( m1, Console::WindowWidth, Console::WindowHeight );
}

/*
This example produces the following results:

The current window width is 85, and the current window height is 43.
  (Press any key to continue...)
The new window width is 42, and the new window height is 21.
  (Press any key to continue...)
The current window width is 85, and the current window height is 43.

*/
//</snippet1>
