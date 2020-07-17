

// <Snippet1>
#using <System.EnterpriseServices.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Web::Services::Protocols;

// Define a SOAP header by deriving from the SoapHeader base class.
// The header contains just one string value.
public ref class MyHeader: public SoapHeader
{
public:
   String^ MyValue;
};

public ref class MyWebService
{
public:

   // Member variable to receive the contents of the MyHeader SOAP header.
   MyHeader^ myHeader;

   [WebMethod]
   [SoapHeader("myHeader",Direction=SoapHeaderDirection::InOut)]
   void Hello(){}

};

// </Snippet1>
