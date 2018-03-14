//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
int main()
{
   
   // Create a request for the Web page at www.contoso.com.
   WebRequest^ request = WebRequest::Create( L"http://www.contoso.com" );
   
   // This application doesn't want they proxy to be used so it sets
   // the global proxy to an empy proxy.
   IWebProxy^ myProxy = GlobalProxySelection::GetEmptyWebProxy();
   
   // Get the response.
   WebResponse^ response = request->GetResponse();
   
   // Display the response to the console.
   Stream^ stream = response->GetResponseStream();
   StreamReader^ reader = gcnew StreamReader( stream );
   Console::WriteLine( reader->ReadToEnd() );
   
   // Clean up.
   reader->Close();
   stream->Close();
   response->Close();
   return 0;
}
//</snippet1>
