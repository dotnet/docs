/*
   This program is used as a client of the client proxy class.
*/

// System.Web.Services.Protocols.MatchAttribute
// System.Web.Services.Protocols.MatchAttribute.MatchAttribute(string)
// System.Web.Services.Protocols.MatchAttribute.IgnoreCase
// System.Web.Services.Protocols.MatchAttribute.Pattern
// System.Web.Services.Protocols.MatchAttribute.Capture
// System.Web.Services.Protocols.MatchAttribute.Group
// System.Web.Services.Protocols.MatchAttribute.MaxRepeats

/*
   The following example demonstrates the constructor and 'IgnoreCase',
   'Pattern', 'Capture', 'Group', 'MaxRepeats' properties of the
   'MatchAttribute' class. This example shows a simple proxy that
   parses the contents of a .html file which has been returned in
   response to a web request. The web request which is a HTTP-GET
   request is done behind the scenes in the 'Invoke' method of
   'HttpGetClientProtocol'. The .html file returned in response is
   parsed with the help of 'MatchAttribute' class and the contents
   are available in the 'Headers' instance returned by 'GetHeaders'
   method.
*/

// <Snippet1>
#using <System.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services::Protocols;

// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
// <Snippet6>
// <Snippet7>
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
// </Snippet7>
// </Snippet6>
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>

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
// </Snippet1>

public ref class SvcClient
{
public:
   static void main()
   {
      Example_Headers^ myHeaders;
      MatchAttribute_Example^ mySample = gcnew MatchAttribute_Example;
      myHeaders = mySample->GetHeaders();

      Console::WriteLine( "\nThe Title html tag content is : {0}",
         myHeaders->Title );

      Console::WriteLine( "\nThe H1 html tag content is : {0}",
         myHeaders->H1 );

      Console::WriteLine( "\nThe fifth element in H2 html tag content is : {0}",
         myHeaders->Element );

      Console::WriteLine( "\nThe elements in the H2 html tag are :" +
         " (MaxRepeats = 0)" );
      for ( int i = 0; i < myHeaders->Elements1->Length; i++ )
      {
         Console::WriteLine( myHeaders->Elements1[ i ] );
      }

      Console::WriteLine( "\nThe elements in the H2 html tag are :" + 
         " (MaxRepeats = 1)" );
      for ( int i = 0; i < myHeaders->Elements2->Length; i++ )
      {
         Console::WriteLine( myHeaders->Elements2[ i ] );
      }

      Console::WriteLine( "\nThe H3 html tag has attribute : {0} = {1}",
         myHeaders->Attribute, myHeaders->Value );
   }
};

int main()
{
   SvcClient::main();
}

