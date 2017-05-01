
// <Snippet1>
using namespace System;

// Declare an interface.
interface class myIFace{};
public ref class MyIsInterface{};

void main()
{
   try
   {
      // Get the IsInterface attribute for myIFace.
      bool myBool1 = myIFace::typeid->IsInterface;
      
      //Display the IsInterface attribute for myIFace.
      Console::WriteLine( "Is the specified type an interface? {0}.", myBool1 );
      
      // Get the attribute IsInterface for MyIsInterface.
      bool myBool2 = MyIsInterface::typeid->IsInterface;
      
      //Display the IsInterface attribute for MyIsInterface.
      Console::WriteLine( "Is the specified type an interface? {0}.", myBool2 );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nAn exception occurred: {0}.", e->Message );
   }
}
// </Snippet1>
