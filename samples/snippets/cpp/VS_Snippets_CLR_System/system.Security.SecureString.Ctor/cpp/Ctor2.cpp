// <Snippet2>
using namespace System;
using namespace System::Security;

int main(array<System::String ^> ^args)
{
   // Define the string value to assign to a new secure string.
   Char chars[4] = { 't', 'e', 's', 't' };
   // Instantiate the secure string.
   SecureString^ testString = gcnew SecureString();
   // Assign the character array to the secure string.
   for each (Char ch in chars)
   {
      testString->AppendChar(ch);
   }   
   // Display secure string length.
   Console::WriteLine("The length of the string is {0} characters.", 
                        testString->Length);

   delete testString;
   return 0;
}
// The example displays the following output:
//      The length of the string is 4 characters.
// </Snippet2>
