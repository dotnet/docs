

#using <System.EnterpriseServices.dll>
#using <System.Web.Services.dll>
#using <System.Web.dll>

using namespace System;
using namespace System::Web;
using namespace System::Web::Services;
using namespace System::Web::Services::Protocols;

// <Snippet1>
public ref class MyHeader: public SoapHeader
{
public:
   String^ MyValue;
};

public ref class MyWebService
{
public:
   MyHeader^ myHeader;

   [WebMethod]
   [SoapHeader("myHeader",
   Direction=SoapHeaderDirection::InOut|SoapHeaderDirection::Fault)]
   void MySoapHeaderReceivingMethod()
   {
      
      // Set myHeader->MyValue to some value.
   }

};

// </Snippet1>
