// Console.ReadKey2.cpp : main project file.

// <Snippet1>
using namespace System;

void main()
{
   ConsoleKeyInfo cki;
   // Prevent example from ending if CTL+C is pressed.
   Console::TreatControlCAsInput = true;

   Console::WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
   Console::WriteLine("Press the Escape (Esc) key to quit: \n");
   do {
      cki = Console::ReadKey(true);
      Console::Write("You pressed ");
      if ((cki.Modifiers & ConsoleModifiers::Alt) != ConsoleModifiers()) Console::Write("ALT+");
      if ((cki.Modifiers & ConsoleModifiers::Shift) != ConsoleModifiers()) Console::Write("SHIFT+");
      if ((cki.Modifiers & ConsoleModifiers::Control) != ConsoleModifiers()) Console::Write("CTL+");
      Console::WriteLine("{0} (character '{1}')", cki.Key, cki.KeyChar);
   } while (cki.Key != ConsoleKey::Escape);
}
// This example displays output similar to the following:
//       Press any combination of CTL, ALT, and SHIFT, and a console key.
//       Press the Escape (Esc) key to quit:
//       
//       You pressed CTL+A (character '☺')
//       You pressed C (character 'c')
//       You pressed CTL+C (character '♥')
//       You pressed K (character 'k')
//       You pressed ALT+I (character 'i')
//       You pressed ALT+U (character 'u')
//       You pressed ALT+SHIFT+H (character 'H')
//       You pressed Escape (character '←')
// </Snippet1>
