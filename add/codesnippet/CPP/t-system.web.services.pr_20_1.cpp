#using <System.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services::Protocols;

public ref class Example_Headers
{
public:

   [MatchAttribute("TITLE>(.*?)<")]
   String^ Title;

   [MatchAttribute("",Pattern="h1>(.*?)<",IgnoreCase=true)]
   String^ H1;

   [MatchAttribute("H2>((([^<,]*),?)+)<",Group=3,Capture=4)]
   String^ Element;

   [MatchAttribute("H2>((([^<,]*),?){2,})<",Group=3,MaxRepeats=0)]
   array<String^>^ Elements1;

   [MatchAttribute("H2>((([^<,]*),?){2,})<",Group=3,MaxRepeats=1)]
   array<String^>^ Elements2;

   [MatchAttribute("H3 ([^=]*)=([^>]*)",Group=1)]
   String^ Attribute;

   [MatchAttribute("H3 ([^=]*)=([^>]*)",Group=2)]
   String^ Value;
};

public ref class MatchAttribute_Example: public HttpGetClientProtocol
{
public:
   MatchAttribute_Example()
   {
      Url = "http://localhost";
   }

   [HttpMethodAttribute(TextReturnReader::typeid,UrlParameterWriter::typeid)]
   Example_Headers^ GetHeaders()
   {
      return ((Example_Headers^)(Invoke( "GetHeaders", ( Url + "/MyHeaders.html" ),
         gcnew array<Object^>(0) )));
   }

   System::IAsyncResult^ BeginGetHeaders( System::AsyncCallback^ callback,
      Object^ asyncState )
   {
      return BeginInvoke( "GetHeaders", ( Url + "/MyHeaders.html" ),
         gcnew array<Object^>(0), callback, asyncState );
   }

   Example_Headers^ EndGetHeaders( System::IAsyncResult^ asyncResult )
   {
      return (Example_Headers^)(EndInvoke( asyncResult ));
   }
};