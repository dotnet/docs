

//<Snippet1>
#using <System.Web.Services.dll>
#using <System.Xml.dll>
#using <System.dll>

using namespace System::Diagnostics;
using namespace System::Xml::Serialization;
using namespace System;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;

public ref class MyMath: public System::Web::Services::Protocols::HttpPostClientProtocol
{
public:

   [System::Diagnostics::DebuggerStepThroughAttribute]
   MyMath()
   {
      this->Url = "http://www.contoso.com/math.asmx";
   }

   [System::Diagnostics::DebuggerStepThroughAttribute]
   [System::Web::Services::Protocols::HttpMethodAttribute(System::Web::Services::Protocols::XmlReturnReader::typeid,
   System::Web::Services::Protocols::HtmlFormParameterWriter::typeid)]
   [returnvalue:System::Xml::Serialization::XmlRootAttribute("snippet1>",Namespace="http://www.contoso.com/",IsNullable=false)]
   int Add( String^ num1, String^ num2 )
   {
      array<Object^>^temp2 = {num1,num2};
      return  *dynamic_cast<int^>(this->Invoke( "Add", (String::Concat( this->Url, "/Add" )), temp2 ));
   }

   [System::Diagnostics::DebuggerStepThroughAttribute]
   System::IAsyncResult^ BeginAdd( String^ num1, String^ num2, System::AsyncCallback^ callback, Object^ asyncState )
   {
      array<Object^>^temp3 = {num1,num2};
      return this->BeginInvoke( "Add", (this->Url + "/Add" ), temp3, callback, asyncState );
   }

   [System::Diagnostics::DebuggerStepThroughAttribute]
   int EndAdd( System::IAsyncResult^ asyncResult )
   {
      return  *dynamic_cast<int^>(this->EndInvoke( asyncResult ));
   }
};
//</Snippet1>
