// <Snippet3>
using namespace System;
using namespace System::Security;

int main(array<System::String ^> ^args)
{
   // Define the string value to be assigned to the secure string.
   String^ initString = "TestString";
   // Instantiate the secure string.
   SecureString^ testString = gcnew SecureString();
   // Assign the character array to the secure string.
   for each (Char ch in initString)
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
//      The length of the string is 10 characters.
// </Snippet3>
