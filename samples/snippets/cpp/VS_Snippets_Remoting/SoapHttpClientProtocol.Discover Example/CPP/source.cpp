

//<Snippet1>
#using <System.Web.Services.dll>
#using <System.Xml.dll>
#using <System.dll>

using namespace System::Diagnostics;
using namespace System::Xml::Serialization;
using namespace System;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;

namespace MyMath
{

   [System::Web::Services::WebServiceBindingAttribute(Name="MathSoap",Namespace="http://tempuri.org/")]
   public ref class Math: public System::Web::Services::Protocols::SoapHttpClientProtocol
   {
   public:

      [System::Diagnostics::DebuggerStepThroughAttribute]
      Math()
      {
         this->Url = "http://www.contoso.com/math.asmx";
      }


      [System::Diagnostics::DebuggerStepThroughAttribute]
      [System::Web::Services::Protocols::SoapDocumentMethodAttribute("http://tempuri.org/Add",
      Use=System::Web::Services::Description::SoapBindingUse::Literal,
      ParameterStyle=System::Web::Services::Protocols::SoapParameterStyle::Wrapped)]
      int Add( int num1, int num2 )
      {
         array<Object^>^temp0 = {num1,num2};
         array<Object^>^results = this->Invoke( "Add", temp0 );
         return  *dynamic_cast<int^>(results[ 0 ]);
      }


      [System::Diagnostics::DebuggerStepThroughAttribute]
      System::IAsyncResult^ BeginAdd( int num1, int num2, System::AsyncCallback^ callback, Object^ asyncState )
      {
         array<Object^>^temp1 = {num1,num2};
         return this->BeginInvoke( "Add", temp1, callback, asyncState );
      }


      [System::Diagnostics::DebuggerStepThroughAttribute]
      int EndAdd( System::IAsyncResult^ asyncResult )
      {
         array<Object^>^results = this->EndInvoke( asyncResult );
         return  *dynamic_cast<int^>(results[ 0 ]);
      }

   };

}

//</Snippet1>
