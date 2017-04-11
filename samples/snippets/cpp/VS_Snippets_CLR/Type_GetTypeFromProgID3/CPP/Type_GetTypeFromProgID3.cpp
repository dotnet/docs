
// <Snippet1>
using namespace System;
int main()
{
   try
   {
      
      // Use the ProgID localhost\HKEY_CLASSES_ROOT\DirControl::DirList.1.
      String^ theProgramID = "DirControl.DirList.1";
      
      // Use the server name localhost.
      String^ theServer = "localhost";
      
      // Make a call to the method to get the type information for the given ProgID.
      Type^ myType = Type::GetTypeFromProgID( theProgramID, theServer );
      if ( myType == nullptr )
      {
         throw gcnew Exception( "Invalid ProgID or Server." );
      }
      Console::WriteLine( "GUID for ProgID DirControl.DirList.1 is {0}.", myType->GUID );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "An exception occurred." );
      Console::WriteLine( "Source: {0}", e->Source );
      Console::WriteLine( "Message: {0}", e->Message );
   }

}

// </Snippet1>
