// System.web.Services.Discovery.DiscoveryClientProtocol.Download(string,string)

/*
The following example demonstrates the usage of the 'Download' method
of the class 'DiscoveryClientProtocol'. The input to the program is
a discovery file 'MathService_cs.vsdisco'. It generates a 'Stream'
instance of the discovery file 'MathService_cs.vsdisco' from the
'Download' method of 'DiscoveryClientPrototocol' and prints out
the 'contentType' and length in bytes of the discoverydocument.
*/

#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Discovery;
using namespace System::Collections;
using namespace System::IO;

int main()
{
// <Snippet1>
   String^ myDiscoFile = "http://localhost/MathService_cs.vsdisco";
   String^ myEncoding = "";
   DiscoveryClientProtocol^ myDiscoveryClientProtocol =
      gcnew DiscoveryClientProtocol;

   Stream^ myStream = myDiscoveryClientProtocol->Download(
      myDiscoFile, myEncoding );
   Console::WriteLine( "The length of the stream in bytes: {0}",
      myStream->Length );
   Console::WriteLine( "The MIME encoding of the downloaded " +
      "discovery document: {0}", myEncoding );
   myStream->Close();
// </Snippet1>
}
