#using <System.Web.Services.dll>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Xml::Serialization;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;

int main(){}

// This class derives from System::Web::Services::Protocols.WebClientProtocol
// as if the user is implemented his own protocol.
// It demonstrates the use of WebClientProtocol's constructor.

// <Snippet1>
[System::Web::Services::WebServiceBindingAttribute(Name="Service1Soap",
   Namespace="http://tempuri.org/")]
ref class TempConvertService: public System::Web::Services::Protocols::WebClientProtocol
{
public:
   TempConvertService() : WebClientProtocol()
   {
      // Rest of class initialization.
   }
   // </Snippet1>
};
