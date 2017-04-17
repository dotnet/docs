// ConsoleKey.cpp : main project file.


// <Snippet1>
using namespace System;
using namespace System::Text;

void main()
{
   ConsoleKeyInfo input;
   do {
      Console::WriteLine("Press a key, together with Alt, Ctrl, or Shift.");
      Console::WriteLine("Press Esc to exit.");
      input = Console::ReadKey(true);

      StringBuilder^ output = gcnew StringBuilder(
                     String::Format("You pressed {0}", input.Key.ToString()));
      bool modifiers = false;

      if ((input.Modifiers & ConsoleModifiers::Alt) == ConsoleModifiers::Alt) {
         output->Append(", together with " + ConsoleModifiers::Alt.ToString());
         modifiers = true;
      }
      if ((input.Modifiers & ConsoleModifiers::Control) == ConsoleModifiers::Control)
      {
         if (modifiers) {
            output->Append(" and ");
         }   
         else {
            output->Append(", together with ");
            modifiers = true;
         }
         output->Append(ConsoleModifiers::Control.ToString());
      }
      if ((input.Modifiers & ConsoleModifiers::Shift) == ConsoleModifiers::Shift)
      {
         if (modifiers) {
            output->Append(" and ");
         }   
         else {
            output->Append(", together with ");
            modifiers = true;
         }
         output->Append(ConsoleModifiers::Shift.ToString());
      }
      output->Append(".");                  
      Console::WriteLine(output->ToString());
      Console::WriteLine();
   } while (input.Key != ConsoleKey::Escape);
}
// The output from a sample console session might appear as follows:
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed D.
//       
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed X, along with Shift.
//       
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed L, along with Control and Shift.
//       
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed P, along with Alt and Control and Shift.
//       
//       Press a key, along with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed Escape. 
// </Snippet1>

