#using <System.dll>

using namespace System;
using namespace System::Net;

public ref class Sample
{
private:
   void sampleFunction()
   {
      // <Snippet1>
      WebRequest^ myRequest = WebRequest::Create( "http://www.contoso.com" );
      // </Snippet1>
   }
};
