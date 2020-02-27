

#using <System.Web.Services.dll>
#using <System.Xml.dll>
#using <System.dll>
#using <System.Web.dll>

using namespace System;
using namespace System::Web;
using namespace System::Web::UI;
using namespace System::Net;

namespace MyMath
{
using namespace System::Xml::Serialization;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;
   public ref class Math: public SoapHttpClientProtocol
   {
   public:
      int Add( int num1, int num2 )
      {
         return num1 + num2;
      }
   };
}

public ref class Page1: public Page
{
private:
   void Page_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // <Snippet1>
      MyMath::Math^ math = gcnew MyMath::Math;

      // Set the proxy server to proxyserver, set the port to 80, and specify to bypass the proxy server
      // for local addresses.
      IWebProxy^ proxyObject = gcnew WebProxy( "http://proxyserver:80",true );
      math->Proxy = proxyObject;

      // Call the Add XML Web service method.
      int total = math->Add( 8, 5 );

      // </Snippet1>
   }
};

int main(){}
