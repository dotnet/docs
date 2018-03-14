

#using <System.Web.Services.dll>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Xml::Serialization;
using namespace System::Web::Services::Protocols;

// <Snippet2>
namespace MyMath
{
   [XmlRootAttribute("snippet1>",Namespace="http://MyMath/",IsNullable=false)]
   public ref class Math: public HttpGetClientProtocol
   {
   public:
      Math()
      {
         this->Url = "http://www.contoso.com/math.asmx";
      }

      [HttpMethodAttribute(System::Web::Services::Protocols::XmlReturnReader::typeid,
      System::Web::Services::Protocols::UrlParameterWriter::typeid)]
      int Add( String^ num1, String^ num2 )
      {
         array<Object^>^temp0 = {num1,num2};
         return  *dynamic_cast<int^>(this->Invoke( "Add", String::Concat( this->Url, "/Add" ), temp0 ));
      }

      IAsyncResult^ BeginAdd( String^ num1, String^ num2, AsyncCallback^ callback, Object^ asyncState )
      {
         array<Object^>^temp1 = {num1,num2};
         return this->BeginInvoke( "Add", String::Concat( this->Url, "/Add" ), temp1, callback, asyncState );
      }

      int EndAdd( IAsyncResult^ asyncResult )
      {
         return  *dynamic_cast<int^>(this->EndInvoke( asyncResult ));
      }
   };
}
// </Snippet2>
