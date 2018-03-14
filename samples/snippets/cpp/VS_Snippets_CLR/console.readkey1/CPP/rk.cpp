// Console.ReadKey.cpp : main project file.

// <Snippet1>
using namespace System;

void main()
{
   ConsoleKeyInfo cki;
   // Prevent example from ending if CTL+C is pressed.
   Console::TreatControlCAsInput = true;

   Console::WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
   Console::WriteLine("Press the Escape (Esc) key to quit: \n");
   do 
   {
      cki = Console::ReadKey();
      Console::Write(" --- You pressed ");
      if((cki.Modifiers & ConsoleModifiers::Alt) != ConsoleModifiers()) Console::Write("ALT+");
      if((cki.Modifiers & ConsoleModifiers::Shift) != ConsoleModifiers()) Console::Write("SHIFT+");
      if((cki.Modifiers & ConsoleModifiers::Control) != ConsoleModifiers()) Console::Write("CTL+");
      Console::WriteLine(cki.Key.ToString());
   } while (cki.Key != ConsoleKey::Escape);
}
// This example displays output similar to the following:
//       Press any combination of CTL, ALT, and SHIFT, and a console key.
//       Press the Escape (Esc) key to quit:
//       
//       a --- You pressed A 
//       k --- You pressed ALT+K 
//       ► --- You pressed CTL+P 
//         --- You pressed RightArrow 
//       R --- You pressed SHIFT+R 
//                --- You pressed CTL+I 
//       j --- You pressed ALT+J 
//       O --- You pressed SHIFT+O 
//       § --- You pressed CTL+U }
// </Snippet1>