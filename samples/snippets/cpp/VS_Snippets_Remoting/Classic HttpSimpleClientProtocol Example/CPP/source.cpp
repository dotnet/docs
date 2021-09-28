

// <Snippet1>
#using <System.EnterpriseServices.dll>
#using <System.Web.Services.dll>

using namespace System::Web::Services;
using namespace System;
public ref class Math
{
public:

   [WebMethod]
   int Add( int num1, int num2 )
   {
      return num1 + num2;
   }

};

// </Snippet1>
