
//<snippet1>
using namespace System;
using namespace System::Security;

void main()
{
   bool go = true;
   ConsoleKeyInfo cki;
   String^ m = L"\nEnter your password (up to 15 letters, numbers, and underscores)\n"
               L"Press BACKSPACE to delete the last character entered. " +
               L"\nPress Enter when done, or ESCAPE to quit:";
   SecureString ^ password = gcnew SecureString;
   int top;
   int left;
   
   // The Console.TreatControlCAsInput property prevents CTRL+C from
   // ending this example.
   Console::TreatControlCAsInput = true;

   Console::Clear();
   Console::WriteLine(m);
   
   top = Console::CursorTop;
   left = Console::CursorLeft;

   do {
      cki = Console::ReadKey(true);
      if (cki.Key == ConsoleKey::Escape)
         break;

      if (cki.Key == ConsoleKey::Backspace){
         if (password->Length > 0) {
            Console::SetCursorPosition(left + password->Length - 1, top);
            Console::Write(' ');
            Console::SetCursorPosition(left + password->Length - 1, top);
            password->RemoveAt(password->Length - 1);
         }
      }
      else {
         if ((password->Length < 15) &&
             (Char::IsLetterOrDigit( cki.KeyChar ) ||
              cki.KeyChar == '_') ) {
            password->AppendChar( cki.KeyChar );
            Console::SetCursorPosition( left + password->Length - 1, top );
            Console::Write("*");
         }
      }
   } while (cki.Key != ConsoleKey::Enter & password->Length < 15);

   // Make the password read-only to prevent modification.
   password->MakeReadOnly();
   // Dispose of the SecureString instance.
   delete password;

}
// The example displays output like the following:
//    Enter your password (up to 15 letters, numbers, and underscores)
//    Press BACKSPACE to delete the last character entered.
//    Press Enter when done, or ESCAPE to quit:
//    ************
//</snippet1>
