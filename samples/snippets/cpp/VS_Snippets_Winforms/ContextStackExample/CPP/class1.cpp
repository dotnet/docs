

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::ComponentModel::Design::Serialization;
using namespace System::Windows::Forms;

int main()
{
   //<Snippet2>
   // Create a ContextStack.
   ContextStack^ stack = gcnew ContextStack;
   
   //</Snippet2>
   //<Snippet3>
   // Push ten items on to the stack and output the value of each.
   for ( int number = 0; number < 10; number++ )
   {
      Console::WriteLine( "Value pushed to stack: {0}", number );
      stack->Push( number );
   }
   //</Snippet3>
   
   //<Snippet4>
   // Pop each item off the stack.
   Object^ item = nullptr;
   while ( (item = stack->Pop()) != 0 )
      Console::WriteLine( "Value popped from stack: {0}", item );
   //</Snippet4>
}
//</Snippet1>
