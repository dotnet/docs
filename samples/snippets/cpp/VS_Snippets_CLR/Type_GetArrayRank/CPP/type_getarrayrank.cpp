
// <Snippet1>
using namespace System;
int main()
{
   try
   {
      array<Int32, 3>^myArray = gcnew array<Int32,3>(3,4,5);
      Type^ myType = myArray->GetType();
      Console::WriteLine( "myArray has {0} dimensions.", myType->GetArrayRank() );
   }
   catch ( NotSupportedException^ e ) 
   {
      Console::WriteLine( "NotSupportedException raised." );
      Console::WriteLine( "Source: {0}", e->Source );
      Console::WriteLine( "Message: {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised." );
      Console::WriteLine( "Source: {0}", e->Source );
      Console::WriteLine( "Message: {0}", e->Message );
   }

}

// </Snippet1>
