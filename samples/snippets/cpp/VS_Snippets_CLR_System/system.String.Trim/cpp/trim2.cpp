// <Snippet2>
using namespace System;

void main()
{
   Console::Write("Enter your first name: ");
   String^ firstName = Console::ReadLine();
   
   Console::Write("Enter your middle name or initial: ");
   String^ middleName = Console::ReadLine();
   
   Console::Write("Enter your last name: ");
   String^ lastName = Console::ReadLine();
   
   Console::WriteLine();
   Console::WriteLine("You entered '{0}', '{1}', and '{2}'.",
                      firstName, middleName, lastName);
   
   String^ name = ((firstName->Trim() + " " + middleName->Trim())->Trim() + " " +
                  lastName->Trim())->Trim();
   Console::WriteLine("The result is " + name + ".");
}
// The following is possible output from this example:
//       Enter your first name:    John
//       Enter your middle name or initial:
//       Enter your last name:    Doe
//       
//       You entered '   John  ', '', and '   Doe'.
//       The result is John Doe.
// </Snippet2>
