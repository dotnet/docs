

#using <System.dll>

using namespace System;
using namespace System::Net;
public ref class Sample
{
public:
   void Method()
   {
      // <Snippet1>
      HttpWebRequest^ myReq = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com/" ));
      // </Snippet1>
   }
};
