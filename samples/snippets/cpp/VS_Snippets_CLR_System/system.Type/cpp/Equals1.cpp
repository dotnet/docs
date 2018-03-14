// <Snippet3>
using namespace System;

void main()
{
   Int64 number1 = 1635429;
   Int32 number2 = 16203;
   double number3 = 1639.41;
   Int64 number4 = 193685412;
   
   // Get the type of number1.
   Type^ t = number1.GetType();
   
   // Compare types of all objects with number1.
   Console::WriteLine("Type of number1 and number2 are equal: {0}",
                      Object::ReferenceEquals(t, number2.GetType()));
   Console::WriteLine("Type of number1 and number3 are equal: {0}",
                      Object::ReferenceEquals(t, number3.GetType()));
   Console::WriteLine("Type of number1 and number4 are equal: {0}",
                      Object::ReferenceEquals(t, number4.GetType()));
}
// The example displays the following output:
//       Type of number1 and number2 are equal: False
//       Type of number1 and number3 are equal: False
//       Type of number1 and number4 are equal: True
// </Snippet3>

