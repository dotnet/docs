

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
      // <Snippet1>
      HttpWebRequest^ HttpWReq = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com" ));
      HttpWebResponse^ HttpWResp = dynamic_cast<HttpWebResponse^>(HttpWReq->GetResponse());
      
      // Insert code that uses the response object.
      HttpWResp->Close();
      // </Snippet1>
   }
};
