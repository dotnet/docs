// <Snippet1>
using namespace System;
using namespace System::Security;

int main(array<System::String ^> ^args)
{
   SecureString^ testString;
   // Define the string value to assign to a new secure string.
   Char chars[4] = { 't', 'e', 's', 't' };
   // Instantiate a new secure string.
   Char* pChars = &chars[0];

   testString = gcnew SecureString(pChars, sizeof(chars)/sizeof(chars[0]));

   // Display secure string length.
   Console::WriteLine("The length of the string is {0} characters.", 
                        testString->Length);
   delete testString;
   return 0;
}
// The example displays the following output:
//      The length of the string is 4 characters.
// </Snippet1>
