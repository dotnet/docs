

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::ComponentModel;
using namespace System::Runtime::InteropServices;
ref class MyTypeSequential1{};


[StructLayoutAttribute(LayoutKind::Sequential)]
ref class MyTypeSequential2{};

int main()
{
   try
   {
      
      // Create an instance of myTypeSeq1.
      MyTypeSequential1^ myObj1 = gcnew MyTypeSequential1;
      
      // Check for and display the SequentialLayout attribute.
      Console::WriteLine( "\nThe object myObj1 has IsLayoutSequential: {0}.", myObj1->GetType()->IsLayoutSequential );
      
      // Create an instance of 'myTypeSeq2' class.
      MyTypeSequential2^ myObj2 = gcnew MyTypeSequential2;
      
      // Check for and display the SequentialLayout attribute.
      Console::WriteLine( "\nThe object myObj2 has IsLayoutSequential: {0}.", myObj2->GetType()->IsLayoutSequential );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nAn exception occurred: {0}", e->Message );
   }

}

// </Snippet1>
