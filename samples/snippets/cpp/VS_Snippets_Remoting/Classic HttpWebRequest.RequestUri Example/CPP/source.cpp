

#using <System.dll>
#using <System.Web.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Net;
using namespace System::Web;
using namespace System::Web::UI;

public ref class Page1: public Page
{
private:
   void Page_Load( Object^, EventArgs^ )
   {
      HttpWebRequest^ req = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com/" ));
      
      // <Snippet1>
      bool hasChanged = req->RequestUri->Equals( req->Address );
      // </Snippet1>
   }
};
