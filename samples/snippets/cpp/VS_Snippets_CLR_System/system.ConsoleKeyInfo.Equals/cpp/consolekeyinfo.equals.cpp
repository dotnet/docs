// ConsoleKeyInfo.Equals.cpp : main project file.

// ConsoleKeyInfo.Equals(Object)

// <Snippet1>
using namespace System;
using namespace System::Text;

static String^ KeyCombination(ConsoleKeyInfo sourceCki);

void main()
{
   String^ k1 = "\nEnter a key ......... ";
   String^ k2 = "\nEnter another key ... ";
   String^ key1 = "";
   String^ key2 = "";
   String^ areKeysEqual = "The {0} and {1} keys are {2}equal.";
   String^ equalValue = "";
   String^ prompt = "Press the escape key (ESC) to quit, " + 
                    "or any other key to continue.";
   ConsoleKeyInfo cki1;
   ConsoleKeyInfo cki2;
   //
   // The Console.TreatControlCAsInput property prevents this example from
   // ending if you press CTL+C, however all other operating system keys and 
   // shortcuts, such as ALT+TAB or the Windows Logo key, are still in effect. 
   //
    Console::TreatControlCAsInput = true;

   // Request that the user enter two key presses. A key press and any 
   // combination shift, CTRL, and ALT modifier keys is permitted.
   do 
   {
      Console::Write(k1);
      cki1 = Console::ReadKey(false);
      Console::Write(k2);
      cki2 = Console::ReadKey(false);
      Console::WriteLine();

      key1 = KeyCombination(cki1);
      key2 = KeyCombination(cki2);
      if (cki1.Equals(cki2))
         equalValue = "";
      else
         equalValue = "not ";
      
      Console::WriteLine(areKeysEqual, key1, key2, equalValue);

      Console::WriteLine(prompt);
      cki1 = Console::ReadKey(true);
   } while (cki1.Key != ConsoleKey::Escape);
// Note: This example requires the Escape (Esc) key.
}

// The KeyCombination() method creates a string that specifies what 
// key and what combination of shift, CTRL, and ALT modifier keys 
// were pressed simultaneously.

static String^ KeyCombination(ConsoleKeyInfo sourceCki)
{
   StringBuilder^ sb = gcnew StringBuilder();
   sb->Length = 0;
   String^ keyCombo;
   if (sourceCki.Modifiers != ConsoleModifiers())
   {
   if ((sourceCki.Modifiers & ConsoleModifiers::Alt) != ConsoleModifiers())
      sb->Append("ALT+");
   if ((sourceCki.Modifiers & ConsoleModifiers::Shift) != ConsoleModifiers())
      sb->Append("SHIFT+");
   if ((sourceCki.Modifiers & ConsoleModifiers::Control) != ConsoleModifiers())
      sb->Append("CTL+");
   }
   sb->Append(sourceCki.Key.ToString());
   keyCombo = sb->ToString();
   return keyCombo;
}
/*
This example produces results similar to the following output:

Enter a key ......... a
Enter another key ... a
The A and A keys are equal.
Press the escape key (ESC) to quit, or any other key to continue.

Enter a key ......... a
Enter another key ... A
The A and SHIFT+A keys are not equal.
Press the escape key (ESC) to quit, or any other key to continue.

Enter a key ......... S
Enter another key ...
The ALT+SHIFT+S and ALT+CTL+F keys are not equal.
Press the escape key (ESC) to quit, or any other key to continue.

Enter a key .........
Enter another key ...
The UpArrow and UpArrow keys are equal.
Press the escape key (ESC) to quit, or any other key to continue.

*/
// </Snippet1>
