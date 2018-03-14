#using <System.dll>

using namespace System;
using namespace System::Net;

public ref class Sample
{
private:
   void sampleFunction()
   {
      // <Snippet1>
      WebProxy^ proxyObject = gcnew WebProxy( "http://proxyserver:80/",true );
      WebRequest^ req = WebRequest::Create( "http://www.contoso.com" );
      req->Proxy = proxyObject;
      // </Snippet1>
   }
};
