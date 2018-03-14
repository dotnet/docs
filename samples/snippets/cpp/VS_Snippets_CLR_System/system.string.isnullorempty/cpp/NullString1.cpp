// <Snippet2>
using namespace System;

void main()
{
   String^ s;
  
   Console::WriteLine("The value of the string is '{0}'", s);

   try {
      Console::WriteLine("String length is {0}", s->Length);
   }
   catch (NullReferenceException^ e) {
      Console::WriteLine(e->Message);
   }   
}
// The example displays the following output:
//     The value of the string is ''
//     Object reference not set to an instance of an object.
// </Snippet2>

void Test()
{
   // <Snippet3>
   String^ s = "";
   Console::WriteLine("The length of '{0}' is {1}.", s, s->Length);
   // The example displays the following output:
   //       The length of '' is 0.      
   // </Snippet3>
}


