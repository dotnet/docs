// System.web.Services.Discovery.DiscoveryClientProtocol.Errors

/*
The following example demonstrates the usage of the 'Errors' property
of the class 'DiscoveryClientProtocol'. The input to the program is
a discovery file 'MathService_cs.vsdisco', which holds reference 
related to 'MathService_cs.asmx' web service. The program is 
excecuted first time with existence of the file 
'MathService_cs.asmx' in the location as specified in the discovery
file. The file 'MathService_cs.asmx' is removed from the referred 
location in a way to simulate a scenario wherein the file related 
to web service is missing, and the program is excecuted the second time
to show the exception occuring.
*/

#using <System.Web.Services.dll>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Discovery;
using namespace System::Collections;

int main()
{
   
// <Snippet1>
   String^ myDiscoFile = "http://localhost/MathService_cs.vsdisco";
   String^ myUrlKey = "http://localhost/MathService_cs.asmx?wsdl";
   DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
   
   // Get the discovery document.
   DiscoveryDocument^ myDiscoveryDocument = myDiscoveryClientProtocol->Discover( myDiscoFile );
   IEnumerator^ myEnumerator = myDiscoveryDocument->References->GetEnumerator();
   while ( myEnumerator->MoveNext() )
   {
      ContractReference^ myContractReference = dynamic_cast<ContractReference^>(myEnumerator->Current);
      
      // Get the DiscoveryClientProtocol from the ContractReference.
      myDiscoveryClientProtocol = myContractReference->ClientProtocol;
      myDiscoveryClientProtocol->ResolveAll();
      DiscoveryExceptionDictionary^ myExceptionDictionary = myDiscoveryClientProtocol->Errors;
      if ( myExceptionDictionary->Contains( myUrlKey ) )
      {
         Console::WriteLine( "System generated exceptions." );
         
         // Get the exception from the DiscoveryExceptionDictionary.
         Exception^ myException = myExceptionDictionary[ myUrlKey ];
         Console::WriteLine( " Source : {0}", myException->Source );
         Console::WriteLine( " Exception : {0}", myException->Message );
      }
   }
}
// </Snippet1>
