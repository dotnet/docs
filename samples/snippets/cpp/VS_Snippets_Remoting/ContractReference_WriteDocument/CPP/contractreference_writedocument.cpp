/*
The following example demonstrates the 'WriteDocument' method of
'ContractReference' class. It creates a 'ContactReference' and a 'FileStream' Object*.
Then it gets the 'ServiceDescription' Object* corresponding to the 'test.wsdl' file.
Using the 'WriteDocument' method, the 'ServiceDescription' Object* is written into the
file stream.
Note: The 'TestInput_cpp::wsdl' file should exist in the same folder.
*/

#using <System.dll>
#using <System.Web.Services.dll>
#using <System.xML.DLL>

using namespace System;
using namespace System::Web::Services::Discovery;
using namespace System::IO;
using namespace System::Web::Services::Description;

int main()
{
   try
   {
// <Snippet1>
      ContractReference^ myContractReference = gcnew ContractReference;
      FileStream^ myFileStream = gcnew FileStream( "TestOutput_cpp.wsdl",
         FileMode::OpenOrCreate,FileAccess::Write );
      
      // Get the ServiceDescription for the test .wsdl file.
      ServiceDescription^ myServiceDescription =
         ServiceDescription::Read( "TestInput_cpp.wsdl" );
      
      // Write the ServiceDescription into the file stream.
      myContractReference->WriteDocument( myServiceDescription, myFileStream );
      Console::WriteLine( "ServiceDescription is written "
         + "into the file stream successfully." );
      Console::WriteLine( "The number of bytes written into the file stream: {0}",
         myFileStream->Length );
      myFileStream->Close();
// </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised: {0}", e->Message );
   }
}
